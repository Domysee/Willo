using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Board;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tapi.WebConnection;

namespace Tapi.Tests.UnitTests.TrelloEntities.Board
{
[TestClass]
    public class BoardsTest
    {
        [TestMethod]
        public void GetAllShouldThrowExceptionIfMemberIdIsNull()
        {
            var boards = new Boards(new TrelloWebClient());
            Action getAll = () => { boards.GetAll(null).Wait(); };

            getAll.ShouldThrow<ArgumentNullException>();
        }
    }
}
