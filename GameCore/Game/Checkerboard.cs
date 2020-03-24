using System;

namespace GameCore.Game
{
    public class Checkerboard
    {
        private ePieceColor[,] board;

        public Checkerboard(int size)
        {
            Size = size;
            board = new ePieceColor[size, size];
        }

        public int Size { get; private set; }

        internal void UpdatePiece(ePieceColor color, Coordinate coordinate)
        {
            if (isValidCoordinate(ref coordinate))
                board[coordinate.X, coordinate.Y] = color;
        }

        internal ePieceColor GetPieceColor(Coordinate coordinate)
        {
            if (isValidCoordinate(ref coordinate))
                return board[coordinate.X, coordinate.Y];
            else
                throw new Exception("輸入非法座標");
        }
        internal bool isValidCoordinate(ref Coordinate coordinate)
        {
            return coordinate.X >= 0
                            && coordinate.X <= Size
                            && coordinate.Y >= 0
                            && coordinate.Y <= Size;
        }
    }
}