using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.Authorization;
using Tapi.WebConnection;

namespace Tapi.Tests
{
    public class TestData
    {
        public static readonly string TestApplicationName = "Test";
        public static readonly string TestApplicationKeyString = "appkeyappkeyappkeyappkeyappkey11";
        public static readonly ApplicationKey TestApplicationKey = TestApplicationKeyString;
        public static readonly string TestAuthorizationTokenString = "authorizationtokenauthorizationtokenauthorizationtoken1234567890";
        public static readonly AuthorizationToken TestAuthorizationToken = TestAuthorizationTokenString;
    }
}
