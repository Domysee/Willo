using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic.Infrastructure;

namespace Willo.Logic.Errors
{
    public class RequestFailedError : IError
    {
        public string Message => "There was an error in the network request. Are you sure you have Internet connection?";
    }
}
