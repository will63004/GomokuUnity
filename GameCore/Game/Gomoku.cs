using System;

namespace GameCore.Game
{
    public class Gomoku
    {
        public int Size => board.Size;
        private Checkerboard board;
        public ePieceColor CurTurn { get; private set; } = ePieceColor.Black;
        public ePieceColor Winner { get; set; }

        public Gomoku(int size)
        {
            board = new Checkerboard(size);
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public Gomoku NextTurn(Coordinate coordinate)
        {
            if (board.GetPieceColor(coordinate) != ePieceColor.None)
                throw new Exception("錯誤座標");

            board.UpdatePiece(CurTurn, coordinate);

            Winner = CalculateWinner(coordinate, CurTurn);

            switch (CurTurn)
            {
                case ePieceColor.Black:
                    CurTurn = ePieceColor.White;
                    break;
                case ePieceColor.White:
                    CurTurn = ePieceColor.Black;
                    break;
                default:
                    throw new Exception("只能放入黑白子");
            }

            return this;
        }

        private ePieceColor CalculateWinner(Coordinate coordinate, ePieceColor curTurn)
        {
            int x = coordinate.X;
            int y = coordinate.Y;
            for (int a = x - 4; a <= x + 4; a++)//判斷橫
                if (GetPieceColorAndCheck(a, y) == curTurn && GetPieceColorAndCheck(a + 1, y) == curTurn && GetPieceColorAndCheck(a + 2, y) == curTurn && GetPieceColorAndCheck(a + 3, y) == curTurn && GetPieceColorAndCheck(a + 4, y) == curTurn)
                    return curTurn;
            for (int b = y - 4; b <= y + 4; b++)//判斷豎
                if (GetPieceColorAndCheck(x, b) == curTurn && GetPieceColorAndCheck(x, b + 1) == curTurn && GetPieceColorAndCheck(x, b + 2) == curTurn && GetPieceColorAndCheck(x, b + 3) == curTurn && GetPieceColorAndCheck(x, b + 4) == curTurn)
                    return curTurn;
            for (int a = x - 4, b = y - 4; a <= x + 4; a++, b++)//判斷右斜
                if (GetPieceColorAndCheck(a, b) == curTurn && GetPieceColorAndCheck(a + 1, b + 1) == curTurn && GetPieceColorAndCheck(a + 2, b + 2) == curTurn && GetPieceColorAndCheck(a + 3, b + 3) == curTurn && GetPieceColorAndCheck(a + 4, b + 4) == curTurn)
                    return curTurn;
            for (int a = x - 4, b = y + 4; a <= x + 4; a++, b--)//判斷左斜
                if (GetPieceColorAndCheck(a, b) == curTurn && GetPieceColorAndCheck(a + 1, b - 1) == curTurn && GetPieceColorAndCheck(a + 2, b - 2) == curTurn && GetPieceColorAndCheck(a + 3, b - 3) == curTurn && GetPieceColorAndCheck(a + 4, b - 4) == curTurn)
                    return curTurn;

            return ePieceColor.None;
        }

        public ePieceColor GetPieceColorAndCheck(int x, int y)
        {
            Coordinate coordinate = new Coordinate(x, y);
            if (board.isValidCoordinate(ref coordinate))
                return GetPieceColor(coordinate);
            else
                return ePieceColor.NonValid;
        }
        public ePieceColor GetPieceColor(Coordinate coordinate)
        {
            return board.GetPieceColor(coordinate);
        }
    }
}