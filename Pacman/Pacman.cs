using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pacman
{
    class Pacman
    {        
        int x = 5;
        int y=5;
        int startangle = 45;
        int grenzwert = 45;
        int nullwert = 0;
        int endangle = 270;
        bool closing = true;
        bool onhorizontalline = true;
        bool onvertikalline = true;
        int schrittweite = 2;

        Direction currentdirection = Direction.RIGHT;
        Direction nextdirection = Direction.RIGHT;

        public Pacman()
        {

        }

        public bool ONHORIZONTALLINE
        {
            get
            {
                return onhorizontalline;
            }
            set
            {
                onhorizontalline = value;
            }
        }
        
        public bool ONVERTIKALLINE
        {
            get
            {
                return onvertikalline;
            }
            set
            {
                onvertikalline = value; 
            }
        }

        public enum Direction
        { UP,DOWN,LEFT,RIGHT }

        public void Dir(Direction pressesdir)                       // Setzt die nächste Direction
        {            
                nextdirection = pressesdir;
        }

        private void Omnomnom()
        {
            if (closing)
            {
                startangle-=5;
                endangle = endangle + 10;
            }
            else
            {
                startangle+=5;
                endangle = endangle - 10;
            }

            if (startangle == grenzwert)
                closing = true;
            else if (startangle == nullwert)
                closing = false;
        }                                  // Kümmert sich um das Öffnen  und Schließen des PAcmans  (Omnomomom = Insider)

        public void Draw(Graphics g)                                // Malt den Pacman
        {
            SolidBrush b = new SolidBrush(Color.Yellow);

            g.FillPie(b, x, y, 30, 30, startangle, endangle);
            
        }                            

        public void Move( )                                         // Bewegt den Pacman
        {
            if (nextdirection != currentdirection && onhorizontalline == true && onvertikalline == true)            // Prüft ob sich der Pacman in 
            {                                                                                                       // die nextdirection bewegen darf
                currentdirection = nextdirection;

                if (closing == false && onhorizontalline == true && onvertikalline == true)     // Die 2 if's verhindern das beim längeren drücken einer taste der
                    closing = true;                                                             // Mund immer geschlossen bzw offen ist.

                if (onhorizontalline == true && onvertikalline == true)
                {
                    switch (currentdirection)                                          // Gibt dem Pacman die richtige Blickrichtung
                    {

                        case Direction.DOWN:
                            startangle = 130;
                            endangle = 270;
                            grenzwert = 135;
                            nullwert = 90;
                            break;

                        case Direction.UP:
                            startangle = 315;
                            endangle = 270;
                            grenzwert = 315;
                            nullwert = 270;
                            break;

                        case Direction.LEFT:
                            startangle = 225;
                            endangle = 270;
                            grenzwert = 225;
                            nullwert = 180;
                            break;

                        case Direction.RIGHT:
                            startangle = 45;
                            endangle = 270;
                            grenzwert = 45;
                            nullwert = 0;
                            break;
                    }
                }
                
            }

            switch (currentdirection)                               // Entscheidet wohin der Pacman fährt
            {
                case Direction.RIGHT:
                    
                    if(x<645)
                    {
                        x = x + schrittweite;
                    }
                    if ((x - 5) % 40 == 0)
                    {                        
                        onvertikalline = true;
                        onhorizontalline = true;
                    }
                    else
                    {
                        onvertikalline = false;
                        onhorizontalline = true;
                    }
                    
                    

                    break;

                case Direction.LEFT:
                    if (x > 5)
                    {
                        x = x - schrittweite;
                    }
                    if ((x - 5) % 40 == 0)
                    {
                        
                        y = y - ((y - 5) % 40);
                        onvertikalline = true;
                        onhorizontalline = true;
                    }
                    else
                    {
                        onvertikalline = false;
                        onhorizontalline = true;
                    }
                    currentdirection = Direction.LEFT;
                    break;

                case Direction.UP:
                    if (y > 5)
                    {
                        y = y - schrittweite;
                    }
                    if ((y - 5) % 40 ==0)
                    {
                        
                        onhorizontalline = true;
                        onvertikalline = true;
                    }
                    else
                    {
                        onvertikalline = true;
                        onhorizontalline = false;
                    }
                    currentdirection = Direction.UP;
                    break;

                case Direction.DOWN:
                    if (y < 365)
                    {
                        y = y + schrittweite;
                    }
                    if ((y- 5) % 40 ==0 )
                    {
                        
                        onhorizontalline = true;
                        onvertikalline = true;
                        
                    }
                    else
                    {
                        onvertikalline = true;
                        onhorizontalline = false;
                    }
                    currentdirection = Direction.DOWN;
                    break;
                    
            }
            Omnomnom();
   
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

        public Direction CURRENTDIRECTION
        {
            get { return currentdirection; }
            set { currentdirection = value; }
        }
    }
}
