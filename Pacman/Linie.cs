using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pacman
{
    class Linie
    {
        int x1, x2, y1, y2;
        Color color = Color.Red;

        public Linie(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
       
            
        }

        public void Draw(Graphics g)
        {
            g.DrawLine(new Pen(color), x1, y1, x2, y2);
        }
    }
}
