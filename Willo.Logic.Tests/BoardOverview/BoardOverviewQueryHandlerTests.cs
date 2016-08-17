using HyperMock.Universal;
using HyperMock.Universal.Verification;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi;
using Tapi.TrelloEntities;
using Tapi.TrelloEntities.Board;
using Willo.Logic.BoardOverview;

namespace Willo.Logic.Tests.BoardOverview
{
    [TestClass]
    public class BoardOverviewQueryHandlerTests
    {
        [TestMethod]
        public void ShouldQueryAllBoards()
        {
            var boards = Mock.Create<IBoards>();
            boards.Setup(b => b.GetAll(Param.IsAny<MemberId>(), Param.IsAny<BoardProperties>())).Returns(Task.FromResult(Enumerable.Empty<Board>()));
            var api = Mock.Create<ITrello>();
            api.SetupGet(a => a.Boards).Returns(boards);
            var handler = new BoardOverviewQueryHandler(api);

            handler.Handle(new BoardOverviewQuery()).Wait();

            boards.Verify(b => b.GetAll(Param.IsAny<MemberId>(), Param.IsAny<BoardProperties>()), Occurred.Once());
        }

        [TestMethod]
        public void ShouldQueryAllBoardsWithAuthorizedUser()
        {
            var boards = Mock.Create<IBoards>();
            boards.Setup(b => b.GetAll(MemberId.AuthorizedUser, Param.IsAny<BoardProperties>())).Returns(Task.FromResult(Enumerable.Empty<Board>()));
            var api = Mock.Create<ITrello>();
            api.SetupGet(a => a.Boards).Returns(boards);
            var handler = new BoardOverviewQueryHandler(api);

            handler.Handle(new BoardOverviewQuery()).Wait();

            boards.Verify(b => b.GetAll(MemberId.AuthorizedUser, Param.IsAny<BoardProperties>()), Occurred.Once());
        }
    }
}
