using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    class AllePunkte
    {
         
        public delegate void HitPointHandler(Punkt p);
        public event HitPointHandler HitPoint;
        
        public delegate void WinHandler();
        public event WinHandler Won;

        List<Punkt> points = new List<Punkt>(); 
        

        public AllePunkte()
        {
            FillList();
        }

        public void DrawPunkte(Graphics g)
        {
            foreach (Punkt p in points)
            {
                if (p.CAUGHT == false)
                {
                    if (p == points[27] || p == points[55])
                    {
                        g.DrawEllipse(new Pen(Color.Yellow), p.X-4, p.Y-4, 16, 16);
                        g.FillEllipse(new SolidBrush(Color.LimeGreen), p.X-4, p.Y-4, 16, 16);
                    }
                    else
                    {
                        g.DrawEllipse(new Pen(Color.Yellow), p.X, p.Y, 4, 4);
                        g.FillEllipse(new SolidBrush(Color.LimeGreen), p.X, p.Y, 4, 4);
                    }
                }
            }
        }

        public void CheckPoint(Pacman pacman)
        {
            foreach (Punkt p in points)
            {
                if (p.CAUGHT == false)
                {
                    //if (new Point(p.X + 2, p.Y + 2) == new Point(pacman.X + 15, pacman.Y + 15))
                    if(new Rectangle(p.X,p.Y,4,4).IntersectsWith(new Rectangle(pacman.X,pacman.Y,25,25)))
                    {
                        p.CAUGHT = true;
                        HitPoint(p);
                        if (points.Count == 0)
                        {
                            Won();
                        }
                    }
                    

                }

            }

        }

        private void FillList()
        {
            bool zähler = false;

            for (int x = 18; x <= 660; x += 40)
            {
                if ((x + 22) % 40 == 0)
                {
                    zähler = true;
                }
                else
                {
                    zähler = false;
                }
                for (int y = 18; y <= 380; y += 40)
                {
                    if (zähler == true || (y + 22) % 40 == 0)
                    {
                        Punkt p = new Punkt(x, y);
                        points.Add(p);
                    }
                }




            }
            points[27] = new SpecialPunkt(points[27].X, points[27].Y);
            points[55] = new SpecialPunkt(points[55].X, points[55].Y);
            points.RemoveAt(0);
        }
    }
}
