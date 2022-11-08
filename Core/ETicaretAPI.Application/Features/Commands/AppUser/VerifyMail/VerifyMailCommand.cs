using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.AppUser.VerifyMail
{
    public class VerifyMailCommand:IRequest<bool>
    {
        public string id { get; set; }
        public string code { get; set; }
    }
}
