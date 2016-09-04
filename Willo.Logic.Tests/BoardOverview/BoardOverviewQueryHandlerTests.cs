using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Tapi;
using Tapi.TrelloEntities;
using Tapi.TrelloEntities.Board;
using Willo.Logic.Components.BoardOverview;

namespace Willo.Logic.Tests.BoardOverview
{
    [TestClass]
    public class BoardOverviewQueryHandlerTests
    {
        [TestMethod]
        public void ShouldQueryAllBoards()
        {
            var boardsMock = new Mock<IBoards>();
            boardsMock.Setup(b => b.GetAll(It.IsAny<MemberId>(), It.IsAny<BoardProperties>())).Returns(Task.FromResult(Enumerable.Empty<Board>()));
            var apiMock = new Mock<ITrello>();
            apiMock.SetupGet(a => a.Boards).Returns(boardsMock.Object);
            var handler = new BoardOverviewQueryHandler(apiMock.Object);

            handler.Handle(new BoardOverviewQuery()).Wait();
            
            boardsMock.Verify(b => b.GetAll(It.IsAny<MemberId>(), It.IsAny<BoardProperties>()), Times.Once());
        }

        [TestMethod]
        public void ShouldQueryAllBoardsWithAuthorizedUser()
        {
            var boardsMock = new Mock<IBoards>();
            boardsMock.Setup(b => b.GetAll(MemberId.AuthorizedUser, It.IsAny<BoardProperties>())).Returns(Task.FromResult(Enumerable.Empty<Board>()));
            var apiMock = new Mock<ITrello>();
            apiMock.SetupGet(a => a.Boards).Returns(boardsMock.Object);
            var handler = new BoardOverviewQueryHandler(apiMock.Object);

            handler.Handle(new BoardOverviewQuery()).Wait();

            boardsMock.Verify(b => b.GetAll(MemberId.AuthorizedUser, It.IsAny<BoardProperties>()), Times.Once());
        }
    }
}
