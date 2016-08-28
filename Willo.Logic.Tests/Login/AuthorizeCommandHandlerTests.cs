using HyperMock.Universal;
using HyperMock.Universal.Verification;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var api = Mock.Create<ITrello>();
            api.Setup(a => a.Authorize(Param.IsAny<ApplicationKey>(), Param.IsAny<AuthorizationToken>())).Returns(Task.CompletedTask);
            var handler = new AuthorizeCommandHandler(api);

            handler.Handle(new AuthorizeCommand(token)).Wait();

            api.Verify(a => a.Authorize(Param.IsAny<ApplicationKey>(), Param.IsAny<AuthorizationToken>()), Occurred.Once());
        }
    }
}
