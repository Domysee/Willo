using FluentAssertions;
using HyperMock.Universal;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic.Components.Login;

namespace Willo.Logic.Tests
{
    [TestClass]
    public class QueryHandlerStoreTests
    {
        [TestMethod]
        public void RegisterShouldNotThrowIfCalledWithNonNullHandler()
        {
            var store = new QueryHandlerStore();
            var handler = Mock.Create<IQueryHandler<AuthorizationUrlQuery, string>>();
            Action action = () => { store.Register(handler); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void RegisterShouldThrowIfCalledWithNullHandler()
        {
            var store = new QueryHandlerStore();
            Action action = () => { store.Register<AuthorizationUrlQuery, string>(null); };

            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void UnregisterShouldNotThrowIfCalledWithNotRegisteredHandler()
        {
            var store = new QueryHandlerStore();
            var handler = Mock.Create<IQueryHandler<AuthorizationUrlQuery, string>>();
            Action action = () => { store.Unregister(handler); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterShouldNotThrowIfCalledWithRegisteredHandler()
        {
            var store = new QueryHandlerStore();
            var handler = Mock.Create<IQueryHandler<AuthorizationUrlQuery, string>>();
            store.Register(handler);
            Action action = () => { store.Unregister(handler); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterShouldThrowIfCalledWithNullHandler()
        {
            var store = new QueryHandlerStore();
            Action action = () => { store.Unregister<AuthorizationUrlQuery, string>(null); };

            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void RegisterShouldAddHandler()
        {
            var store = new QueryHandlerStore();
            var addHandler = Mock.Create<IQueryHandler<AuthorizationUrlQuery, string>>();
            store.Register(addHandler);

            var returnHandler = store.Get(new AuthorizationUrlQuery());
            returnHandler.Should().NotBeNull();
        }

        [TestMethod]
        public void UnregisterShouldRemoveHandler()
        {
            var store = new QueryHandlerStore();
            var handler = Mock.Create<IQueryHandler<AuthorizationUrlQuery, string>>();
            store.Register(handler);
            store.Unregister(handler);

            var returnHandler = store.Get(new AuthorizationUrlQuery());
            returnHandler.Should().BeNull();
        }

        [TestMethod]
        public void GetShouldReturnNullIfNoHandlerIsRegistered()
        {
            var store = new QueryHandlerStore();

            var handler = store.Get(new AuthorizationUrlQuery());

            handler.Should().BeNull();
        }
    }
}
