using System;

namespace Tapi.WebConnection
{
    internal class RequestFailedException : Exception
    {
        public RequestFailedException(string url) : base($"The request to {url} failed")
        {
        }
    }
}