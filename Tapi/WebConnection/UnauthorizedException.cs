using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.WebConnection
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("You need to call 'Authorize' before attempting to to make requests to the Trello api.")
        {

        }
    }
}
