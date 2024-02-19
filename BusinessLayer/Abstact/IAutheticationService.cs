using EntitiesLayer.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstact
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(RegisterDto registerDto);
        Task<bool> ValidateUser(LoginDto loginDto);
        Task<TokenResponseDto> CreateToken();
    }
}
