using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.Authorization;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Tapi.Tests.UnitTests
{
    [TestClass]
    public class AuthorizationTests
    {
        [TestMethod]
        public void ApplicationKeyThrowsExceptionOnCreatingWithInvalidString()
        {
            var invalidKey = "#$^%$%&^$%";
            Action createKey = () => { var x = (ApplicationKey)invalidKey; };

            createKey.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void ApplicationKeyThrowsExceptionOnCreatingWithTooLongString()
        {
            var invalidKey = "abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890abcdefghijklmnopqrstuvwxyz1234567890";
            Action createKey = () => { var x = (ApplicationKey)invalidKey; };

            createKey.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void ApplicationKeyThrowsExceptionOnCreatingWithShortLongString()
        {
            var invalidKey = "abcdef";
            Action createKey = () => { var x = (ApplicationKey)invalidKey; };

            createKey.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void AuthorizationUrlShouldContainKey()
        {
            var authorizationUrl = new AuthorizationUrlCreator().Create(TestData.TestApplicationKey, TestData.TestApplicationName, AuthorizationScope.ReadOnly, AuthorizationExpiration.Never);

            authorizationUrl.Should().Contain("key");
            authorizationUrl.Should().Contain((string)TestData.TestApplicationKey);
        }

        [TestMethod]
        public void AuthorizationUrlShouldContainName()
        {
            var authorizationUrl = new AuthorizationUrlCreator().Create(TestData.TestApplicationKey, TestData.TestApplicationName, AuthorizationScope.ReadOnly, AuthorizationExpiration.Never);

            authorizationUrl.Should().Contain("name");
            authorizationUrl.Should().Contain(TestData.TestApplicationName);
        }

        [TestMethod]
        public void AuthorizationUrlShouldContainScope()
        {
            var scope = AuthorizationScope.ReadOnly;
            var authorizationUrl = new AuthorizationUrlCreator().Create(TestData.TestApplicationKey, TestData.TestApplicationName, scope, AuthorizationExpiration.Never);

            authorizationUrl.Should().Contain("scope");
            authorizationUrl.Should().Contain((string)scope);
        }

        [TestMethod]
        public void AuthorizationUrlShouldContainExpiration()
        {
            var expiration = AuthorizationExpiration.Never;
            var authorizationUrl = new AuthorizationUrlCreator().Create(TestData.TestApplicationKey, TestData.TestApplicationName, AuthorizationScope.ReadOnly, expiration);

            authorizationUrl.Should().Contain("expiration");
            authorizationUrl.Should().Contain((string)expiration);
        }
    }
}
