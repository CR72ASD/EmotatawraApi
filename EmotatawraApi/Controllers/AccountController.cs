using DataBase.Entity.Identity;
using ElmotatawraApi.Dto;
using Methods.InterFaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElmotatawraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenServices _tokenServices;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenServices tokenServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
        }

        [HttpPost("Register Student")]
        public async Task<ActionResult<UserDto>> RegisterStudent(RegisterStudentDto studentDto)
        {
            var user = new AppUser()
            {
                NationalId = studentDto.NationalId,
                FristName = studentDto.FristName,
                LastName = studentDto.LastName,
                ThirdName = studentDto.ThirdName,
                FouthName = studentDto.FouthName,
                Password = studentDto.Password,
                PhoneNumber = studentDto.Phone,
                Gender = studentDto.Gender
            };
            var result = await _userManager.CreateAsync(user, studentDto.Password);
            if (!result.Succeeded) return Unauthorized(400);
            return new UserDto
            {
                NationalId = studentDto.NationalId,
                Password = studentDto.Password,
                Token = await _tokenServices.CreateToken(user, _userManager)
            };
        }

        [HttpPost("Login Student")]
        public async Task<ActionResult<UserDto>> LoginStudent(LoginStudentDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.NationalId);
            if (user is null) 
                return Unauthorized(401);
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded) 
                return Unauthorized(401);
            return new UserDto
            {
                NationalId = login.NationalId,
                Password = login.Password,
                Token = await _tokenServices.CreateToken(user,_userManager)
            };
        }

        [HttpPost("Register Instractor")]
        public async Task<ActionResult<UserDto>> RegisterInstractor(RegisterInstractorDto instractorDto)
        {
            var user = new AppUser()
            {
                NationalId = instractorDto.NationalId,
                FristName = instractorDto.FristName,
                LastName = instractorDto.LastName,
                ThirdName = instractorDto.ThirdName,
                FouthName = instractorDto.FouthName,
                Password = instractorDto.Password,
                PhoneNumber = instractorDto.Phone,
                Gender = instractorDto.Gender,
                IsActive = IsActive.Instractor
            };
            var result = await _userManager.CreateAsync(user, instractorDto.Password);
            if (!result.Succeeded) return Unauthorized(400);
            return new UserDto 
            { 
                NationalId = instractorDto.NationalId,
                Password = instractorDto.Password, 
                Token = await _tokenServices.CreateToken(user, _userManager) 
            };
        }

        [HttpPost("Login Instractor")]
        public async Task<ActionResult<UserDto>> LoginInstractor(LoginInstractorDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.NationalId);
            if (user == null) return Unauthorized(401);
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded) return Unauthorized(401);
            return new UserDto 
            { 
                NationalId = login.NationalId, 
                Password = login.Password, 
                Token = await _tokenServices.CreateToken(user, _userManager) 
            };
        }
    }
}
