using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class RegisterVM
    {
        public string? Name { get; init; }
        public string? Surname { get; init; }
        [Required(ErrorMessage = "Kullanıcı adı giriniz")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Şifreyi giriniz")]
        public string? Password { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string Roles { get; init; } = "User";
    }
}
