using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Willo.Logic.Components.Login;
using Moq;

namespace Willo.Logic.Tests
{
    [TestClass]
    public class CommandHandlerStoreTests
    {
        [TestMethod]
        public void RegisterShouldNotThrowIfCalledWithNonNullHandler()
        {
            var store = new CommandHandlerStore();
            var handlerMock = new Mock<ICommandHandler<AuthorizeCommand>>();
            Action action = () => { store.Register(handlerMock.Object); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void RegisterShouldThrowIfCalledWithNullHandler()
        {
            var store = new CommandHandlerStore();
            Action action = () => { store.Register<AuthorizeCommand>(null); };

            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void UnregisterShouldNotThrowIfCalledWithNotRegisteredHandler()
        {
            var store = new CommandHandlerStore();
            var handlerMock = new Mock<ICommandHandler<AuthorizeCommand>>();
            Action action = () => { store.Unregister(handlerMock.Object); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterShouldNotThrowIfCalledWithRegisteredHandler()
        {
            var store = new CommandHandlerStore();
            var handlerMock = new Mock<ICommandHandler<AuthorizeCommand>>();
            store.Register(handlerMock.Object);
            Action action = () => { store.Unregister(handlerMock.Object); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterShouldThrowIfCalledWithNullHandler()
        {
            var store = new CommandHandlerStore();
            Action action = () => { store.Unregister<AuthorizeCommand>(null); };

            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void RegisterShouldAddHandler()
        {
            var store = new CommandHandlerStore();
            var addHandlerMock = new Mock<ICommandHandler<AuthorizeCommand>>();
            store.Register(addHandlerMock.Object);

            var returnHandler = store.Get(new AuthorizeCommand("authorizationtokenauthorizationtokenauthorizationtoken1234567890"));
            returnHandler.Should().NotBeNull();
        }

        [TestMethod]
        public void UnregisterShouldRemoveHandler()
        {
            var store = new CommandHandlerStore();
            var handlerMock = new Mock<ICommandHandler<AuthorizeCommand>>();
            store.Register(handlerMock.Object);
            store.Unregister(handlerMock.Object);

            var returnHandler = store.Get(new AuthorizeCommand("authorizationtokenauthorizationtokenauthorizationtoken1234567890"));
            returnHandler.Should().BeNull();
        }

        [TestMethod]
        public void GetShouldReturnNullIfNoHandlerIsRegistered()
        {
            var store = new CommandHandlerStore();

            var handler = store.Get(new AuthorizeCommand("authorizationtokenauthorizationtokenauthorizationtoken1234567890"));

            handler.Should().BeNull();
        }
    }
}
