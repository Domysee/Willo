using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tapi.WebConnection;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tapi.Tests.UnitTests
{
    [TestClass]
    public class WebConnnectionTests
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

        [TestMethod]
        public void CreatingDoesNotThrow()
        {
            Action create = () => { var x = new TrelloWebClient(); };

            create.ShouldNotThrow();
        }

        [TestMethod]
        public void AuthorizeDoesNotThrow()
        {
            var client = new TrelloWebClient();
            Action authorize = () => { client.Authorize(TestData.TestApplicationKey, TestData.TestAuthorizationToken); };

            authorize.ShouldNotThrow();
        }

        [TestMethod]
        public void GetShouldThrowUnauthorizedExceptionIfClientIsNotAuthorized()
        {
            var testUrl = "http://www.url.com";
            var client = new TrelloWebClient();
            Action get = () => { client.Get(testUrl).Wait(); };
            Action genericGet = () => { client.Get<JObject>(testUrl).Wait(); };

            get.ShouldThrow<UnauthorizedException>();
            genericGet.ShouldThrow<UnauthorizedException>();
        }
    }
}
