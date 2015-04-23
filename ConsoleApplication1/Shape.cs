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

        public bool MoveLeft()
        {
            return true;
        }

        public bool MoveRight()
        {
            return true;
        }

        public bool Rotate()
        {
            if (IsBox) return true;
            return true;
        }

        public bool Drop()
        {
            return true;
        }

        public abstract void DrawShape();

    }
}
