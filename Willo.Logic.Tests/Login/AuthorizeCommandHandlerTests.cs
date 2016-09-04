using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using Tapi;
using Tapi.Authorization;
using Tapi.WebConnection;
using Willo.Logic.Components.Login;

namespace Willo.Logic.Tests.Login
{
    [TestClass]
    public class AuthorizeCommandHandlerTests
    {
        [TestMethod]
        public void ShouldAuthorizeApi()
        {
            var token = "authorizationtokenauthorizationtokenauthorizationtoken1234567890";
            var apiMock = new Mock<ITrello>();
            apiMock.Setup(a => a.Authorize(It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>())).Returns(Task.CompletedTask);
            var handler = new AuthorizeCommandHandler(apiMock.Object);

            handler.Handle(new AuthorizeCommand(token)).Wait();

            apiMock.Verify(a => a.Authorize(It.IsAny<ApplicationKey>(), It.IsAny<AuthorizationToken>()), Times.Once());
        }
    }
}
