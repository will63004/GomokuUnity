using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameCore.Game.Tests
{
    [TestClass()]
    public class GomokuTests
    {
        private int Size { get; set; } = 30;
        private Gomoku gomoku;

        [TestInitialize]
        public void SetUp()
        {
            gomoku = new Gomoku(Size);
        }

        [TestMethod()]
        public void CreateCheckerboard()
        {
            Assert.AreEqual(gomoku.Size, Size);
        }

        [TestMethod]
        public void AddOneBlackPiece()
        {
            Coordinate coordinate = new Coordinate(0, 0);
            gomoku.NextTurn(coordinate);

            ePieceColor expected = gomoku.GetPieceColor(coordinate);
            Assert.AreEqual(expected, ePieceColor.Black);
            Assert.AreEqual(gomoku.CurTurn, ePieceColor.White);
        }

        [DataTestMethod]
        [DataRow(0, 0, DisplayName = "AddSamePosition(0,0)")]
        [DataRow(1, 1, DisplayName = "AddSamePosition(1,1)")]
        public void AddSamePosition(int x, int y)
        {
            Coordinate coordinate = new Coordinate(x, y);
            gomoku.NextTurn(coordinate);
            
            Assert.ThrowsException<Exception>(() => gomoku.NextTurn(coordinate));
        }

        [TestMethod]
        public void CheckWhoWin()
        {
            gomoku.NextTurn(new Coordinate(0, 0))
                  .NextTurn(new Coordinate(0, 1))
                  .NextTurn(new Coordinate(1, 0))
                  .NextTurn(new Coordinate(1, 1))
                  .NextTurn(new Coordinate(2, 0))
                  .NextTurn(new Coordinate(2, 1))
                  .NextTurn(new Coordinate(3, 0))
                  .NextTurn(new Coordinate(3, 1))
                  .NextTurn(new Coordinate(4, 0));

            Assert.AreEqual(gomoku.Winner, ePieceColor.Black);
        }
    }
}
