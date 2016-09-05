using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tapi.WebConnection;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tapi.Tests.UnitTests.WebConnection
{
    [TestClass]
    public class AuthorizationTokenTests
    {
        [TestMethod]
        public void AuthorizationTokenThrowsExceptionOnCreatingWithInvalidString()
        {
            var invalidToken = "#$^%$%&^$%";
            Action createToken = () => { var x = (AuthorizationToken)invalidToken; };

            createToken.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void AuthorizationTokenThrowsExceptionOnCreatingWithTooLongString()
        {
            var invalidToken = "abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890";
            Action createToken = () => { var x = (AuthorizationToken)invalidToken; };

            createToken.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void AuthorizationTokenThrowsExceptionOnCreatingWithTooshortString()
        {
            var invalidToken = "abcdef";
            Action createToken = () => { var x = (AuthorizationToken)invalidToken; };

            createToken.ShouldThrow<ArgumentException>();
        }
    }
}
