using ETicaretAPI.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.AppUser.VerifyMail
{
    public class VerifyMailCommandHandler : IRequestHandler<VerifyMailCommand, bool>
    {
        IUserService _userService;

        public VerifyMailCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<bool> Handle(VerifyMailCommand request, CancellationToken cancellationToken)
        {
            _userService.VerifyTokenAsnyc(request.id, request.code);
            return Task.FromResult(true);
        }
    }
}
