using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Authorize] // Token yok ise giriş yapamıyacak
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserApiService _userApiService;

        public UserController(IUserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userApiService.GetListAsync();
            return View(users);
        }
    }
}