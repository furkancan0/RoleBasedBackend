using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Services
{
    public interface ITokenHandler
    {
        Task<DTOs.Token> CreateAccessTokenAsync(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
