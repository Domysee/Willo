using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Willo.Logic.Components.Login;
using Moq;
using Willo.Logic.Infrastructure;

namespace Willo.Logic.Tests
{
    [TestClass]
    public class QueryHandlerStoreTests
    {
        [TestMethod]
        public void RegisterShouldNotThrowIfCalledWithNonNullHandler()
        {
            var store = new QueryHandlerStore();
            var handlerMock = new Mock<IQueryHandler<AuthorizationUrlQuery, string>>();
            Action action = () => { store.Register(handlerMock.Object); };

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
            var handlerMock = new Mock<IQueryHandler<AuthorizationUrlQuery, string>>();
            Action action = () => { store.Unregister(handlerMock.Object); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterShouldNotThrowIfCalledWithRegisteredHandler()
        {
            var store = new QueryHandlerStore();
            var handlerMock = new Mock<IQueryHandler<AuthorizationUrlQuery, string>>();
            store.Register(handlerMock.Object);
            Action action = () => { store.Unregister(handlerMock.Object); };

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
            var addHandlerMock = new Mock<IQueryHandler<AuthorizationUrlQuery, string>>();
            store.Register(addHandlerMock.Object);

            var returnHandler = store.Get(new AuthorizationUrlQuery());
            returnHandler.Should().NotBeNull();
        }

        [TestMethod]
        public void UnregisterShouldRemoveHandler()
        {
            var store = new QueryHandlerStore();
            var handlerMock = new Mock<IQueryHandler<AuthorizationUrlQuery, string>>();
            store.Register(handlerMock.Object);
            store.Unregister(handlerMock.Object);

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
