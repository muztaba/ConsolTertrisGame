using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BoxShape : Shape
    {
        public BoxShape(int bucketPositionLeft, int bucketPositionTop, int bucketHight, int bucketWidht)
        {
            
            /*
             * Init method initialize the shape array with the object 
             * in the very beginning of the object creation.
             */
            Init();
            /******
             * Look at from here.
             * I am trying to init the bucket variable in to the shape class throw the constructor.
             * Also working in the Move method . 
             */


        }

        private void Init()
        {
            ShapeArrya = new char[,] { { 'x', 'x' }, { 'x', 'x' } };
            ShapeArrayRow = ShapeArrya.GetLength(0);
            ShapeArrayCol = ShapeArrya.GetLength(1);
        }

        private void SetBool(bool t)
        {
            IsBox = t;
        }

    }
}
