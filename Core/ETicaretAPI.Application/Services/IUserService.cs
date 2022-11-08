using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.ViewModels.Users;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Services
{
    public interface IUserService
    {
        Task<CreateUserViewModel> CreateAsync(CreateUser model);

        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);

        Task GenerateVerifyTokenAsnyc(string email);
        Task<bool> VerifyTokenAsnyc(string id, string code);
    }
}
