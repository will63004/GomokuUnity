using GameCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

namespace GameCoreTests.Game
{
    [TestFixture()]
    public class GomokuTests
    {
        private int Size { get; set; } = 30;
        private Gomoku gomoku;

        [SetUp]
        public void SetUp()
        {
            gomoku = new Gomoku(Size);
        }

        [Test()]
        public void CreateCheckerboard()
        {
            Assert.AreEqual(gomoku.Size, Size);
        }

        [Test]
        public void AddOneBlackPiece()
        {
            Coordinate coordinate = new Coordinate(0, 0);            
            gomoku.NextTurn(coordinate);

            ePieceColor expected = gomoku.GetPieceColor(coordinate);
            Assert.AreEqual(expected, ePieceColor.Black);
            Assert.AreEqual(gomoku.CurTurn, ePieceColor.White);
        }

        //[TestCase(0, 0, TestName = "AddSamePosition(0,0)")]
        //[TestCase(1, 1, TestName = "AddSamePosition(1,1)")]
        //public void AddSamePosition(int x, int y)
        //{
        //    Coordinate coordinate = new Coordinate(x, y);
        //    gomoku.NextTurn(coordinate);
        //    bool second = gomoku.NextTurn(ePieceColor.White, coordinate);

        //    Assert.AreEqual(first, true);
        //    Assert.AreEqual(second, false);
        //}

        [Test]
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
