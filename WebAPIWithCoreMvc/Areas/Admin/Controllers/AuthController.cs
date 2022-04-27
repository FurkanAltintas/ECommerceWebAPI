﻿using Entities.Dtos.AuthDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IAuthApiService _authApiService;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthApiService authApiService, IHttpContextAccessor httpContextAccessor)
        {
            _authApiService = authApiService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDto
            {
                UserName = "furkanaltintas",
                Password = "12345",
                IsRememberMe = true
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _authApiService.LoginAsync(loginDto);
            if (user.Success)
            {
                _httpContextAccessor.HttpContext.Session.SetString("token", user.Data.Token);
                var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                userClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString()));
                userClaims.AddClaim(new Claim(ClaimTypes.Name, user.Data.UserName));
                var claimPrincipal = new ClaimsPrincipal(userClaims);
                var authProperties = new AuthenticationProperties() { IsPersistent = loginDto.IsRememberMe };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, authProperties);
                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
            }
            return View(loginDto);
        }
    }
}