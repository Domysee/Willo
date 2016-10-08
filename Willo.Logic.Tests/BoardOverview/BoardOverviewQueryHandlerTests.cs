using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tapi;
using Tapi.TrelloEntities;
using Tapi.TrelloEntities.Board;
using Tapi.TrelloEntities.Member;
using Tapi.WebConnection;
using Willo.Logic.Components.BoardOverview;
using Willo.Logic.Errors;
using Willo.Logic.Infrastructure;

namespace Willo.Logic.Tests.BoardOverview
{
    [TestClass]
    public class BoardOverviewQueryHandlerTests
    {
        [TestMethod]
        public void ShouldQueryAllBoards()
        {
            var boardsMock = new Mock<IBoards>();
            boardsMock.Setup(b => b.GetAll(It.IsAny<MemberId>(), It.IsAny<BoardOverviewQueryParameters>())).Returns(Task.FromResult(Enumerable.Empty<Board>()));
            var apiMock = new Mock<ITrello>();
            apiMock.SetupGet(a => a.Boards).Returns(boardsMock.Object);
            var handler = new BoardOverviewQueryHandler(apiMock.Object);

            var result = handler.Handle(new BoardOverviewQuery()).Result;

            result.State.Should().Be(ResultState.Success);
            boardsMock.Verify(b => b.GetAll(It.IsAny<MemberId>(), It.IsAny<BoardOverviewQueryParameters>()), Times.Once());
        }

        [TestMethod]
        public void ShouldQueryAllBoardsWithAuthorizedUser()
        {
            var boardsMock = new Mock<IBoards>();
            boardsMock.Setup(b => b.GetAll(MemberId.AuthorizedUser, It.IsAny<BoardOverviewQueryParameters>())).Returns(Task.FromResult(Enumerable.Empty<Board>()));
            var apiMock = new Mock<ITrello>();
            apiMock.SetupGet(a => a.Boards).Returns(boardsMock.Object);
            var handler = new BoardOverviewQueryHandler(apiMock.Object);

            var result = handler.Handle(new BoardOverviewQuery()).Result;

            result.State.Should().Be(ResultState.Success);
            boardsMock.Verify(b => b.GetAll(MemberId.AuthorizedUser, It.IsAny<BoardOverviewQueryParameters>()), Times.Once());
        }

        [TestMethod]
        public void ShouldReturnAuthorizationDeniedErrorIfAuthorizationDeniedxceptionIsThrown()
        {
            var boardsMock = new Mock<IBoards>();
            boardsMock.Setup(b => b.GetAll(It.IsAny<MemberId>(), It.IsAny<BoardOverviewQueryParameters>())).Throws<AuthorizationDeniedException>();
            var apiMock = new Mock<ITrello>();
            apiMock.SetupGet(a => a.Boards).Returns(boardsMock.Object);
            var handler = new BoardOverviewQueryHandler(apiMock.Object);

            var result = handler.Handle(new BoardOverviewQuery()).Result;

            result.State.Should().Be(ResultState.Failure);
            result.Errors.Should().Contain(error => error is AuthorizationDeniedError);
        }

        [TestMethod]
        public void ShouldReturnRequestFailedErrorIfRequestFailedxceptionIsThrown()
        {
            var boardsMock = new Mock<IBoards>();
            boardsMock.Setup(b => b.GetAll(It.IsAny<MemberId>(), It.IsAny<BoardOverviewQueryParameters>())).Throws<RequestFailedException>();
            var apiMock = new Mock<ITrello>();
            apiMock.SetupGet(a => a.Boards).Returns(boardsMock.Object);
            var handler = new BoardOverviewQueryHandler(apiMock.Object);

            var result = handler.Handle(new BoardOverviewQuery()).Result;

            result.State.Should().Be(ResultState.Failure);
            result.Errors.Should().Contain(error => error is RequestFailedError);
        }
    }
}
