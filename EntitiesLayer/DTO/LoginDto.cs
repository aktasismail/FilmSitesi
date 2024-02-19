using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lüten şifreyi giriniz")]
        public string Password { get; set; }
    }
}
