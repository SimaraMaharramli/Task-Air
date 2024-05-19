using AirGroup.Service.DTOS.AccountDtos;

namespace AirGroup.Service.Interfaces
{
    public interface ICurrentUser
    {
        CurrentUserDto GetCurrentUser();
    }
}
