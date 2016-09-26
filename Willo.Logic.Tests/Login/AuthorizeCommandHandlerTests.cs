using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using Tapi;
using Tapi.Authorization;
using Tapi.Tests;
using Tapi.WebConnection;
using Willo.Logic.Components.Login;
using Willo.Logic.Errors;

namespace Willo.Logic.Tests.Login
{
    [TestClass]
    public class AuthorizeCommandHandlerTests
    {
        [TestMethod]
        public void ShouldAuthorizeApi()
        {
            var apiMock = new Mock<ITrello>();
            apiMock.Setup(a => a.Authorize(It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>())).Returns(Task.CompletedTask);
            var handler = new AuthorizeCommandHandler(apiMock.Object);

            handler.Handle(new AuthorizeCommand(TestData.TestAuthorizationToken)).Wait();

            apiMock.Verify(a => a.Authorize(It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>()), Times.Once());
        }

        [DataTestMethod]
        [DataRow(typeof(AuthorizationDeniedException), typeof(AuthorizationDeniedError))]
        [DataRow(typeof(RequestFailedException), typeof(RequestFailedError))]
        [DataRow(typeof(NetworkException), typeof(NetworkError))]
        public void ShouldReturnCorrectErrorOnException(Type exceptionType, Type errorType)
        {
            var apiMock = new Mock<ITrello>();
            apiMock.Setup(a => a.Authorize(It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>()))
                .Throws((Exception)Activator.CreateInstance(exceptionType));
            var handler = new AuthorizeCommandHandler(apiMock.Object);

            var errors = handler.Handle(new AuthorizeCommand(TestData.TestAuthorizationToken)).Result.Errors;

            errors.Should().Contain(e => e.GetType() == errorType);
        }

        [TestMethod]
        public void ShouldOnlyHandleSpecificExceptions()
        {
            var apiMock = new Mock<ITrello>();
            apiMock.Setup(a => a.Authorize(It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>()))
                .Throws<Exception>();
            var handler = new AuthorizeCommandHandler(apiMock.Object);

            Action handle = () => handler.Handle(new AuthorizeCommand(TestData.TestAuthorizationToken)).Wait();

            handle.ShouldThrow<Exception>();
        }
    }
}
