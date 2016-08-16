using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using HyperMock.Universal;
using Willo.Logic.Login;
using System.Threading.Tasks;
using FluentAssertions;
using HyperMock.Universal.Verification;

namespace Willo.Logic.Tests
{
    [TestClass]
    public class MessageBrokerTests
    {
        [TestMethod]
        public void RegisterQueryHandlerShouldNotThrowIfCalledWithNonNullHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            var handler = Mock.Create<IQueryHandler<AuthorizationUrlQuery, string>>();
            Action action = () => { broker.RegisterHandler(handler); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void RegisterQueryHandlerShouldThrowIfCalledWithNullHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            Action action = () => { broker.RegisterHandler<AuthorizationUrlQuery, string>(null); };

            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void UnregisterQueryHandlerShouldNotThrowIfCalledWithNotRegisteredHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            var handler = Mock.Create<IQueryHandler<AuthorizationUrlQuery, string>>();
            Action action = () => { broker.UnregisterHandler(handler); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterQueryHandlerShouldNotThrowIfCalledWithRegisteredHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            var handler = Mock.Create<IQueryHandler<AuthorizationUrlQuery, string>>();
            broker.RegisterHandler(handler);
            Action action = () => { broker.UnregisterHandler(handler); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterQueryHandlerShouldThrowIfCalledWithNullHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            Action action = () => { broker.UnregisterHandler<AuthorizationUrlQuery, string>(null); };

            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void RegisterCommandHandlerShouldNotThrowIfCalledWithNonNullHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            var handler = Mock.Create<ICommandHandler<AuthorizeCommand>>();
            Action action = () => { broker.RegisterHandler(handler); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void RegisterCommandHandlerShouldThrowIfCalledWithNullHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            Action action = () => { broker.RegisterHandler<AuthorizeCommand>(null); };

            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void UnregisterCommandHandlerShouldNotThrowIfCalledWithNotRegisteredHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            var handler = Mock.Create<ICommandHandler<AuthorizeCommand>>();
            Action action = () => { broker.UnregisterHandler(handler); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterCommandHandlerShouldNotThrowIfCalledWithRegisteredHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            var handler = Mock.Create<ICommandHandler<AuthorizeCommand>>();
            broker.RegisterHandler(handler);
            Action action = () => { broker.UnregisterHandler(handler); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterCommandHandlerShouldThrowIfCalledWithNullHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            Action action = () => { broker.UnregisterHandler<AuthorizeCommand>(null); };

            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void QueryShouldExecuteHandler()
        {
            var returnValue = "Return";
            var query = new AuthorizationUrlQuery();
            var handler = Mock.Create<IQueryHandler<AuthorizationUrlQuery, string>>();
            handler.Setup(h => h.Handle((IQuery)query)).Returns(Task.FromResult<object>(returnValue));
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            broker.RegisterHandler(handler);

            var result = broker.Query(query);
            var stringResult = result.Result;

            handler.Verify(h => h.Handle(query), Occurred.Once());
            stringResult.Should().Be(returnValue);
        }

        [TestMethod]
        public void CommandShouldExecuteHandler()
        {
            var command = new AuthorizeCommand("authorizationtokenauthorizationtokenauthorizationtoken1234567890");
            var handler = Mock.Create<ICommandHandler<AuthorizeCommand>>();
            handler.Setup(h => h.Handle(command));
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            broker.RegisterHandler(handler);

            var result = broker.Command(command);

            handler.Verify(h => h.Handle(command), Occurred.Once());
        }
    }
}
