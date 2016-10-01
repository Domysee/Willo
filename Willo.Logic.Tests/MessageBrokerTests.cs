using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Willo.Logic.Components.Login;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using System.Linq;
using Willo.Logic.Infrastructure;

namespace Willo.Logic.Tests
{
    [TestClass]
    public class MessageBrokerTests
    {
        [TestMethod]
        public void RegisterQueryHandlerShouldNotThrowIfCalledWithNonNullHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            var handlerMock = new Mock<IQueryHandler<AuthorizationUrlQuery, string>>();
            Action action = () => { broker.RegisterHandler(handlerMock.Object); };

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
            var handlerMock = new Mock<IQueryHandler<AuthorizationUrlQuery, string>>();
            Action action = () => { broker.UnregisterHandler(handlerMock.Object); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterQueryHandlerShouldNotThrowIfCalledWithRegisteredHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            var handlerMock = new Mock<IQueryHandler<AuthorizationUrlQuery, string>>();
            broker.RegisterHandler(handlerMock.Object);
            Action action = () => { broker.UnregisterHandler(handlerMock.Object); };

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
            var handlerMock = new Mock<ICommandHandler<AuthorizeCommand>>();
            Action action = () => { broker.RegisterHandler(handlerMock.Object); };

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
            var handlerMock = new Mock<ICommandHandler<AuthorizeCommand>>();
            Action action = () => { broker.UnregisterHandler(handlerMock.Object); };

            action.ShouldNotThrow();
        }

        [TestMethod]
        public void UnregisterCommandHandlerShouldNotThrowIfCalledWithRegisteredHandler()
        {
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            var handlerMock = new Mock<ICommandHandler<AuthorizeCommand>>();
            broker.RegisterHandler(handlerMock.Object);
            Action action = () => { broker.UnregisterHandler(handlerMock.Object); };

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
            var returnValue = QueryResult<string>.CreateSuccess("Return");
            var query = new AuthorizationUrlQuery();
            var handlerMock = new Mock<IQueryHandler<AuthorizationUrlQuery, string>>();
            handlerMock.Setup(h => h.Handle((IQuery)query)).Returns(Task.FromResult<object>(returnValue));
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            broker.RegisterHandler(handlerMock.Object);

            var result = broker.Query(query);
            var stringResult = result.Result;

            handlerMock.Verify(h => h.Handle(It.IsAny<IQuery>()), Times.Once());
            stringResult.Should().Be(returnValue);
        }

        [TestMethod]
        public void CommandShouldExecuteHandler()
        {
            var command = new AuthorizeCommand("authorizationtokenauthorizationtokenauthorizationtoken1234567890");
            var handlerMock = new Mock<ICommandHandler<AuthorizeCommand>>();
            var broker = new MessageBroker(new QueryHandlerStore(), new CommandHandlerStore());
            broker.RegisterHandler(handlerMock.Object);

            broker.Command(command).Wait();

            handlerMock.Verify(h => h.Handle(It.IsAny<ICommand>()), Times.Once());
        }
    }
}
