using AirGroup.Domain.Entity;
using AirGroup.Domain.Entity;
using AirGroup.Service.DTOS.AccountDtos;
using AirGroup.Service.Enums;
using AirGroup.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.AppUser;
using System;
using System.Threading.Tasks;


namespace Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;
        public AccountController(IAccountService accountService, IWebHostEnvironment env, UserManager<AppUser> userManager,Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            _accountService = accountService;
            _env = env;
            _userManager = userManager;
            _roleManager = roleManager;

        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserDto registerDto)
        {
            //await _service.Register(registerDto);
            return Ok(await _accountService.Register(registerDto));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            return Ok( await _accountService.Login(loginDto));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("CreateRoles")]
        public async Task<IActionResult> CreateRoles()
        {
            foreach (var role in Enum.GetValues(typeof(DefinedUSerRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                    return Ok("tamam");
                }
            }
            return Ok("null");

        }



    }
}