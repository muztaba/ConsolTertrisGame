using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class Shape : IObjectOperation
    {
        protected char[,] ShapeArrya;
        protected bool IsBox;
        protected int ShapeArrayRow;
        protected int ShapeArrayCol;

        protected readonly int BucketPositionLeft;
        protected readonly int BucketPositionTop;
        protected readonly int BucketHight;
        protected readonly int BucketWidth;
        public bool MoveLeft(int currentCursorLeft, int currentCursorTop, bool[,] bucketStatus)
        {

            return true;
        }

        public bool MoveRight(int currentCursorLeft, int currentCursorTop, bool[,] bucketStatus)
        {
            return true;
        }

        public bool Rotate(bool[,] bucketStatus)
        {
            if (IsBox) return true;
            return true;
        }

        public bool Drop(int currentCursorLeft, int currentCursorTop, bool[,] bucketStatus)
        {
            return true;
        }

        public void DrawShape(int currentCursorLeft, int currentCursorTop)
        {
            for (int i = 0; i < ShapeArrya.GetLength(0); i++)
            {
                Console.SetCursorPosition(currentCursorLeft, currentCursorTop + i);
                for (int j = 0; j < ShapeArrya.GetLength(1); j++)
                {
                    Console.Write(ShapeArrya[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
