using AirGroup.Domain.Entity;
using AirGroup.Service.DTOS.AccountDtos;
using AirGroup.Service.Enums;
using AirGroup.Service.Interfaces;
using AirGroup.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.DTOs.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirGroup.Service.Services
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AccountService(UserManager<AppUser> userManager,
                                 IMapper mapper,
                                 ITokenService tokenService
                                )
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Register(RegisterUserDto consumer)
        {
            var userExists = await _userManager.FindByNameAsync(consumer.PhoneNumber);

            if (userExists != null)
            {
                    throw new Exception("User already exists and is confirmed.");
            }

            var user = CreateUserFromDto(consumer);
            await _userManager.CreateAsync(user, consumer.PassWord);
            await _userManager.AddToRoleAsync(user, DefinedUSerRoles.User.ToString());
            var userRoles = await _userManager.GetRolesAsync(user);

            return _tokenService.GenerateJwtToken(user.Email,user.UserName, userRoles);
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null) return null;

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) return null;

            var roles = await _userManager.GetRolesAsync(user);

            string token = _tokenService.GenerateJwtToken(user.Email, user.UserName, (List<string>)roles);

            return token;
        }
    


        private AppUser CreateUserFromDto(RegisterUserDto consumer)
        {
            var user = _mapper.Map<AppUser>(consumer);
            user.UserName = consumer.PhoneNumber;
            user.NormalizedEmail = consumer.Email.ToUpper();
            return user;
        }
    }
}
