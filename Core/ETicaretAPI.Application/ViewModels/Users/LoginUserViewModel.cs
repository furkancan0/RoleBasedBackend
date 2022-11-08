using ETicaretAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.ViewModels.Users
{
    public class LoginUserViewModel
    {
        public Token Token { get; set; }
        public string Message { get; set; }
    }
}
