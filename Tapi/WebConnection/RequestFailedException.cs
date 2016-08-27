using System;

namespace Tapi.WebConnection
{
    public class RequestFailedException : Exception
    {
        public RequestFailedException(string url) : base($"The request to {url} failed")
        {
        }
    }
}