using AirGroup.Service.DTOS.AccountDtos;
using ServiceLayer.DTOs.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirGroup.Service.Interfaces
{
    public interface IAccountService
    {
        Task<string> Register(RegisterUserDto consumer);
        Task<string> Login(LoginDto loginDto);
    }
}
