using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    interface IObjectOperation
    {
        bool MoveLeft();
        bool MoveRight();
        bool Rotate();
        bool Drop();

        void DrawShape();

    }
}
