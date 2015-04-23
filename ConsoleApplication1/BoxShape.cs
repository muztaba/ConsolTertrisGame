using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BoxShape : Shape
    {
        public override void DrawShape()
        {
            Init();

            for (int i = 0; i < ShapeArrya.GetLength(0); i++)
            {
                for (int j = 0; j < ShapeArrya.GetLength(1); j++)
                {
                    Console.Write(ShapeArrya[i, j]);
                }
                Console.WriteLine();
            }
        }

        private void Init()
        {
            ShapeArrya = new char[,] { { 'x', 'x'}, { 'x', 'x' } };
        }

        private void SetBool(bool t)
        {
            IsBox = t;
        }

    }
}
