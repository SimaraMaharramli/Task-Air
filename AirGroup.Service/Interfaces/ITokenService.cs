using System.Collections.Generic;

namespace AirGroup.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(string email,string name, IList<string> roles);
    }
}
