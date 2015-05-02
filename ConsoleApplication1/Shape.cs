using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        protected  int BucketPositionLeft;
        protected  int BucketPositionTop;
        protected readonly int BucketHight;
        protected readonly int BucketWidth;

        protected Shape(int bucketPositionLeft, int bucketPositionTop, int bucketHight, int bucketWidht)
        {
            this.BucketPositionLeft = bucketPositionLeft;
            this.BucketPositionTop = bucketPositionTop;
            this.BucketHight = bucketHight;
            this.BucketWidth = bucketWidht;
        }

        public bool MoveLeft(int currentCursorLeft, int currentCursorTop, bool[,] bucketStatus)
        {
            /******
             * Look at from here.
             * working on the moveing object. Get the idea!!!! 
             */
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

        public bool MoveDown(int currentCursorLeft, int currentCursorTop, bool[,] bucketStatus)
        {
            return true;
        }
        /**
         * Erase the object in the bucket for.
         */
        public void Erase()
        {
            for (int i = 0; i < ShapeArrayRow; i++)
            {
                Console.SetCursorPosition(i + BucketPositionLeft, BucketPositionTop);
                Console.Write(new string(' ', ShapeArrayCol - 1));
            }
        }

        public void DrawShape(int currentCursorLeft, int currentCursorTop)
        {
            // Save the current cursor poisiton where the box will be drawn.
            // This will help to erase the object.
            this.BucketPositionLeft = currentCursorLeft;
            this.BucketPositionTop = currentCursorTop;

            // Iterate over the object array to draw the object.
            for (int i = 0; i < ShapeArrya.GetLength(0); i++)
            {
                Console.SetCursorPosition(currentCursorLeft, currentCursorTop + i);
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < ShapeArrya.GetLength(1); j++)
                {
                    Console.Write(ShapeArrya[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
