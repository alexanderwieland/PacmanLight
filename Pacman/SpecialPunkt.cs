using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    class SpecialPunkt:Punkt
    {
        int x;
        int y;
        
        
        

        public SpecialPunkt(int x, int y):base(x,y)
        {
            this.x = x;
            this.y = y;
         
            
        }


    }
}
