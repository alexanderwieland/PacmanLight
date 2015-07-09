using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pacman
{
    class Punkt
    {
        int x;
        int y;
        bool caught = false;

        public Punkt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool CAUGHT
        {
            get
            {
                return caught;
            }
            set
            {
                if (value == true)
                {
                    
                }
                caught = value;
            }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

    }
}
