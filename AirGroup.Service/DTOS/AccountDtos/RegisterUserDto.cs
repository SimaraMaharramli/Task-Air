

using System.ComponentModel.DataAnnotations;

namespace AirGroup.Service.DTOS.AccountDtos
{
    public class RegisterUserDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string PassWord { get; set; }

    }
}
