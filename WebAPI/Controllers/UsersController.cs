using Business.Abstract;
using Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _userService.GetListAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetList(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> GetList([FromBody] UserAddDto userAddDto)
        {
            var result = await _userService.AddAsync(userAddDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userUpdateDto)
        {
            var result = await _userService.UpdateAsync(userUpdateDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result.Data)
                return Ok(result);
            return BadRequest();
        }

        //[AllowAnonymous] // Dışarıdan herkes bu methoda erişebilecek.
        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> Authenticate([FromBody] UserForLoginDto userForLoginDto)
        //{
        //    var result = await _userService.Authenticate(userForLoginDto);
        //    if (result != null) return Ok(result);
        //    return BadRequest();
        //}
    }
}