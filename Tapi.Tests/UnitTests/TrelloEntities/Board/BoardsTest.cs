using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.TrelloEntities.Board;
using Xunit;

namespace Tapi.Tests.UnitTests.TrelloEntities.Board
{
    public class BoardsTest
    {
        [Fact]
        public void GetAllShouldThrowExceptionIfMemberIdIsNull()
        {
            var boards = new Boards(new WebConnection.TrelloWebClient());
            Action getAll = () => { boards.GetAll(null).Wait(); };

            getAll.ShouldThrow<ArgumentNullException>();
        }
    }
}
