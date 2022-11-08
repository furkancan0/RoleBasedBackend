using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.ViewModels.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.AppUser.RefreshToken
{
    public class RefreshTokenCommand:IRequest<LoginUserViewModel>
    {
        public string RefreshToken { get; set; }
    }
}
