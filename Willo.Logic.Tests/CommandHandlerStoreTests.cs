using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperMock.Universal;
using FluentAssertions;
using Willo.Logic.Login;

namespace Willo.Logic.Tests
{
    [TestClass]
    public class CommandHandlerStoreTests
    {
        [TestMethod]
        public void RegisterShouldNotThrowIfCalledWithNonNullHandler()
        {
            var store = new CommandHandlerStore();
            var handler = Mock.Create<ICommandHandler<AuthorizeCommand>>();
            Action action = () => { store.Register(handler); };

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
            var handler = Mock.Create<ICommandHandler<AuthorizeCommand>>();
            Action action = () => { store.Unregister(handler); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterShouldNotThrowIfCalledWithRegisteredHandler()
        {
            var store = new CommandHandlerStore();
            var handler = Mock.Create<ICommandHandler<AuthorizeCommand>>();
            store.Register(handler);
            Action action = () => { store.Unregister(handler); };

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
            var addHandler = Mock.Create<ICommandHandler<AuthorizeCommand>>();
            store.Register(addHandler);

            var returnHandler = store.Get(new AuthorizeCommand("authorizationtokenauthorizationtokenauthorizationtoken1234567890"));
            returnHandler.Should().NotBeNull();
        }

        [TestMethod]
        public void UnregisterShouldRemoveHandler()
        {
            var store = new CommandHandlerStore();
            var handler = Mock.Create<ICommandHandler<AuthorizeCommand>>();
            store.Register(handler);
            store.Unregister(handler);

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
