using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface IObjectOperation
    {
        bool MoveLeft(int currentCursorLeft, int currentCursorTop, bool[,] bucketStatus);
        bool MoveRight(int currentCursorLeft, int currentCursorTop, bool[,] bucketStatus);
        bool Rotate(bool[,] bucketStatus);
        bool Drop(int currentCursorLeft, int currentCursorTop, bool[,] bucketStatus);

        void DrawShape(int currentCursorLeft, int currentCursorTop);
        bool MoveDown(int currentCursorLeft, int currentCursorTop, bool[,] bucketStatus);
    }
}
