using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tapi.Authorization;
using Tapi.WebConnection;

namespace Tapi.Tests.UnitTests.WebConnection
{
    [TestClass]
    public class TrelloWebClientTests
    {
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

        [TestMethod]
        public void CheckAuthorizationParametersShouldReturnTrueIfTestRequestSucceeds()
        {
            var webRequestHandlerMock = new Mock<IWebRequestHandler>();
            webRequestHandlerMock.Setup(w => w.Get(It.IsAny<string>(), It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>())).ReturnsAsync("Result");
            var client = new TrelloWebClient(webRequestHandlerMock.Object);

            var result = client.CheckAuthorizationParameters(TestData.TestApplicationKey, TestData.TestAuthorizationToken).Result;

            result.Should().BeTrue();
        }

        [TestMethod]
        public void CheckAuthorizationParametersShouldReturnFalseIfTestRequestDoesntSucceed()
        {
            var webRequestHandlerMock = new Mock<IWebRequestHandler>();
            webRequestHandlerMock.Setup(w => w.Get(It.IsAny<string>(), It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>())).Throws<AuthorizationDeniedException>();
            var client = new TrelloWebClient(webRequestHandlerMock.Object);

            var result = client.CheckAuthorizationParameters(TestData.TestApplicationKey, TestData.TestAuthorizationToken).Result;

            result.Should().BeFalse();
        }

        [TestMethod]
        public void AuthorizeShouldSetAuthorizedIfAuthorizationParametersAreValid()
        {
            var webRequestHandlerMock = new Mock<IWebRequestHandler>();
            webRequestHandlerMock.Setup(w => w.Get(It.IsAny<string>(), It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>())).ReturnsAsync("Result");
            var client = new TrelloWebClient(webRequestHandlerMock.Object);

            client.Authorize(TestData.TestApplicationKey, TestData.TestAuthorizationToken).Wait();

            client.IsAuthorized.Should().BeTrue();
        }

        [TestMethod]
        public void AuthorizeShouldThrowIfAuthorizationParametersAreInvalid()
        {
            var webRequestHandlerMock = new Mock<IWebRequestHandler>();
            webRequestHandlerMock.Setup(w => w.Get(It.IsAny<string>(), It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>())).Throws<AuthorizationDeniedException>();
            var client = new TrelloWebClient(webRequestHandlerMock.Object);

            Action a = () => client.Authorize(TestData.TestApplicationKey, TestData.TestAuthorizationToken).Wait();

            a.ShouldThrow<AuthorizationDeniedException>();
        }

        [TestMethod]
        public void GetShouldThrowIfUnauthorized()
        {
            var client = new TrelloWebClient();

            Action a = () => client.Get("testurl").Wait();

            a.ShouldThrow<UnauthorizedException>();
        }

        [TestMethod]
        public void GetShouldThrowIfAuthorizationIsInvalid()
        {
            var webRequestHandlerMock = new Mock<IWebRequestHandler>();
            webRequestHandlerMock.SetupSequence(w => w.Get(It.IsAny<string>(), It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>())).ReturnsAsync("result").Throws<AuthorizationDeniedException>();
            var client = new TrelloWebClient(webRequestHandlerMock.Object);
            client.Authorize(TestData.TestApplicationKey, TestData.TestAuthorizationToken).Wait();

            Action a = () => client.Get("testurl").Wait();

            a.ShouldThrow<AuthorizationDeniedException>();
        }

        [TestMethod]
        public void GetShouldSucceedIfReturnedValueIsValidJson()
        {
            var webRequestHandlerMock = new Mock<IWebRequestHandler>();
            webRequestHandlerMock.Setup(w => w.Get(It.IsAny<string>(), It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>())).ReturnsAsync("{a:'a'}");
            var client = new TrelloWebClient(webRequestHandlerMock.Object);
            client.Authorize(TestData.TestApplicationKey, TestData.TestAuthorizationToken).Wait();

            Action a = () => client.Get("testurl").Wait();

            a.ShouldNotThrow();
        }
    }
}
