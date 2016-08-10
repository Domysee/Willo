using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.Authorization;
using Xunit;
using FluentAssertions;

namespace Tapi.Tests.UnitTests
{
    public class AuthorizationTests
    {
        [Fact]
        public void ApplicationKeyThrowsExceptionOnCreatingWithInvalidString()
        {
            var invalidKey = "#$^%$%&^$%";
            Action createKey = () => { var x = (ApplicationKey)invalidKey; };

            createKey.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void AuthorizationUrlShouldContainKey()
        {
            var authorizationUrl = Authorize.GetAuthorizationUrl(TestData.TestApplicationKey, TestData.TestApplicationName, AuthorizationScope.ReadOnly, AuthorizationExpiration.Never);

            authorizationUrl.Should().Contain("key");
        }

        [Fact]
        public void AuthorizationUrlShouldContainName()
        {
            var authorizationUrl = Authorize.GetAuthorizationUrl(TestData.TestApplicationKey, TestData.TestApplicationName, AuthorizationScope.ReadOnly, AuthorizationExpiration.Never);

            authorizationUrl.Should().Contain("name");
        }

        [Fact]
        public void AuthorizationUrlShouldContainScope()
        {
            var authorizationUrl = Authorize.GetAuthorizationUrl(TestData.TestApplicationKey, TestData.TestApplicationName, AuthorizationScope.ReadOnly, AuthorizationExpiration.Never);

            authorizationUrl.Should().Contain("scope");
        }

        [Fact]
        public void AuthorizationUrlShouldContainExpiration()
        {
            var authorizationUrl = Authorize.GetAuthorizationUrl(TestData.TestApplicationKey, TestData.TestApplicationName, AuthorizationScope.ReadOnly, AuthorizationExpiration.Never);

            authorizationUrl.Should().Contain("expiration");
        }
    }
}
