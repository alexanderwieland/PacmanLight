using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pacman
{
    class Raster
    {
        int height;
        int width;
        bool full = false;
        
        List<Linie> linienliste = new List<Linie>();

        public Raster(int height, int width)
        {
            this.height = height - 20; //400
            this.width = width -20;    //680
           
        }

        public void Draw(Graphics g)
        {
            Inizalise();

            foreach (Linie l in linienliste)
            {
                l.Draw(g);
            }
            
            
        }

        private void Inizalise()
        {
            if (full == false)
            {

                for (int i = 20; i <= width; i += 40)
                {
                    Linie l = new Linie(i, 20, i, height-20);
                    linienliste.Add(l);
                }
                for (int j = 20; j <= height; j += 40)
                {
                    Linie l = new Linie(20, j, width-20, j);
                    linienliste.Add(l);
                }
                full = true;
            }

            
           
        }
    }
}
