using Microsoft.AspNetCore.Http;
using AirGroup.Service.DTOS.AccountDtos;
using System.Security.Claims;
using AirGroup.Service.Interfaces;

namespace AirGroup.Service.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUserDto GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userId = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            return new CurrentUserDto { UserId = userId};
        }
    }
}
