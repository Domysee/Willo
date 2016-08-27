using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic.Components.Login;

namespace Willo.Logic.Tests.Login
{
    [TestClass]
    public class IsAuthorizationTokenQueryHandlerTests
    {
        [TestMethod]
        public void ShouldReturnFalseIfTokenContainsInvalidCharacters()
        {
            var invalidToken = "#$^%$%&^$%";
            var query = new IsAuthorizationTokenQuery(invalidToken);
            var handler = new IsAuthorizationTokenQueryHandler();

            var result = handler.Handle(query).Result;

            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnFalseIfTokenIsTooLong()
        {
            var invalidToken = "abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890";
            var query = new IsAuthorizationTokenQuery(invalidToken);
            var handler = new IsAuthorizationTokenQueryHandler();

            var result = handler.Handle(query).Result;

            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnFalseIfTokenIsTooShort()
        {
            var invalidToken = "abcdef";
            var query = new IsAuthorizationTokenQuery(invalidToken);
            var handler = new IsAuthorizationTokenQueryHandler();

            var result = handler.Handle(query).Result;

            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfTokenIsValid()
        {
            var validToken = "authorizationtokenauthorizationtokenauthorizationtoken1234567890";
            var query = new IsAuthorizationTokenQuery(validToken);
            var handler = new IsAuthorizationTokenQueryHandler();

            var result = handler.Handle(query).Result;

            result.Should().BeTrue();
        }
    }
}
