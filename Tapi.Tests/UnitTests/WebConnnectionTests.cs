using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Tapi.WebConnection;
using Newtonsoft.Json.Linq;

namespace Tapi.Tests.UnitTests
{
    public class WebConnnectionTests
    {
        [Fact]
        public void AuthorizationTokenThrowsExceptionOnCreatingWithInvalidString()
        {
            var invalidToken = "#$^%$%&^$%";
            Action createToken = () => { var x = (AuthorizationToken)invalidToken; };

            createToken.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void CreatingDoesNotThrow()
        {
            Action create = () => { var x = new TrelloWebClient(); };

            create.ShouldNotThrow();
        }

        [Fact]
        public void AuthorizeDoesNotThrow()
        {
            var client = new TrelloWebClient();
            Action authorize = () => { client.Authorize(TestData.TestApplicationKey, TestData.TestAuthorizationToken); };

            authorize.ShouldNotThrow();
        }

        [Fact]
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
