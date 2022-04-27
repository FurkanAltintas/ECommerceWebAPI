using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using WebAPIWithCoreMvc.ViewModels;

namespace WebAPIWithCoreMvc.Controllers
{
    public class UserController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7066/api/";
        #endregion

        #region Constructor
        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion

        #region Methods
        public async Task<IActionResult> Index()
        {
            //var client = _httpClientFactory.CreateClient(); (IHttpClientFactory için.)
            var users = await _httpClient.GetFromJsonAsync<List<UserDetailDto>>(url + "Users");
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.GenderList = GenderFill();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddViewModel userAddViewModel)
        {
            UserAddDto userAddDto = new()
            {
                FirstName = userAddViewModel.FirstName,
                Gender = userAddViewModel.GenderId == 1 ? true : false,
                Address = userAddViewModel.Address,
                DateOfBirth = userAddViewModel.DateOfBirth,
                Email = userAddViewModel.Email,
                LastName = userAddViewModel.LastName,
                Password = userAddViewModel.Password,
                UserName = userAddViewModel.UserName
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Users", userAddDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(userAddViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.GenderList = GenderFill();
            var user = await _httpClient.GetFromJsonAsync<UserDto>(url + $"Users/{id}");
            UserUpdateViewModel userUpdateViewModel = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                GenderId = user.Gender == true ? 1 : 2,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address
            };
            return View(userUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateViewModel userUpdateViewModel, int id)
        {
            UserUpdateDto userUpdateDto = new()
            {
                Id = id,
                FirstName = userUpdateViewModel.FirstName,
                LastName = userUpdateViewModel.LastName,
                UserName = userUpdateViewModel.UserName,
                Email = userUpdateViewModel.Email,
                Password = userUpdateViewModel.Password,
                Gender = userUpdateViewModel.GenderId == 1 ? true : false,
                DateOfBirth = userUpdateViewModel.DateOfBirth,
                Address = userUpdateViewModel.Address
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Users", userUpdateDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.GenderList = GenderFill();
            return View(userUpdateViewModel);
        }
        #endregion

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _httpClient.GetFromJsonAsync<UserDto>(url + $"Users/{id}");
            if (user != null)
            {
                HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync(url + $"Users/{id}");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), "User");
                }
            }
            return NotFound();
        }

        private dynamic GenderFill()
        {
            List<Gender> genders = new();
            genders.Add(new() { Id = 1, Name = "Erkek" });
            genders.Add(new() { Id = 2, Name = "Kadın" });
            return genders;
        }

        private class Gender
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}