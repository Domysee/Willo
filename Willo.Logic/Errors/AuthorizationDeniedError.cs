using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic.Infrastructure;

namespace Willo.Logic.Errors
{
    public class AuthorizationDeniedError : IError
    {
        public string Message => "The authorization parameters were denied. Please authorize Willo again.";
    }
}
