using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    class Ghost
    {
        int x;
        int y;            
        bool onhorizontalline = true;
        bool onvertikalline = true;
        
        PictureBox pb;
        int schrittweite = 2;

        Direction_G direction = Direction_G.RIGHT;  //aktuelle Richtung des ghosts

        public Ghost(int x,int y, PictureBox pb)
        {
            this.x = x;
            this.y = y;
            this.pb = pb;
            this.pb.Left = x;
            this.pb.Top = y;
        }

        private void RandomDir(Pacman pacman, int randy, int randy2)   //  case 1 u. 2 = KI , case 3 = Random
        {
           

                    switch (randy)
                    {
                        case 1:
                             if (pacman.Y < this.pb.Top)
                            {
                                direction = Direction_G.UP;
                            }
                            if (pacman.Y > this.pb.Top)
                            {
                                direction = Direction_G.DOWN;
                            }
                            if (pacman.Y == this.pb.Top)
                            {
                                if (pacman.X < this.pb.Left)
                                {
                                    direction = Direction_G.LEFT;
                                }
                                if (pacman.X > this.pb.Left)
                                {
                                    direction = Direction_G.RIGHT;
                                }
                            }
                        break;
                    
                    

                        case 2:

                            if (pacman.X < this.pb.Left)
                            {
                                direction = Direction_G.LEFT;
                            }
                            if (pacman.X > this.pb.Left)
                            {
                               direction = Direction_G.RIGHT;
                            }
                            if (pacman.X == this.pb.Left)
                            {
                                if (pacman.Y < this.pb.Top)
                                {
                                    direction = Direction_G.UP;
                                }
                                if (pacman.Y > this.pb.Top)
                                {
                                    direction = Direction_G.DOWN;
                                }
                            }

                            break;

                        case 3:

                            switch (randy2)
                            {
                                case 1: direction = Direction_G.DOWN;
                                    break;

                                case 2: direction = Direction_G.UP;
                                    break;

                                case 3: direction = Direction_G.RIGHT;
                                    break;

                                case 4: direction = Direction_G.LEFT;
                                    break;                        
                            }

                            break;

                        
                   
            }
            
            
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

        public enum Direction_G
        { UP, DOWN, LEFT, RIGHT }

        public bool CheckPoint(Pacman pacman)
        {

              //if (new Point(this.pb.Left + 15, this.pb.Top + 15) == new Point(pacman.X + 15, pacman.Y + 15))
            if(new Rectangle(this.pb.Left, this.pb.Top,25,25).IntersectsWith(new Rectangle(pacman.X,pacman.Y,25,25)))
              {
                   pacman.X = 5;
                   pacman.Y = 5;

                   return true;

               }
            

                    return false;

            
        }

        public void Move(Pacman pacman, Random randy)
        {

            if (onhorizontalline == true && onvertikalline == true)
            {
                int s = randy.Next(1, 5);
                int r = randy.Next(1, 4);
                RandomDir(pacman,r,s);
            }

            switch (direction)
            {
                case Direction_G.RIGHT:
                    if (this.pb.Left < 645)
                    {
                        this.pb.Left = this.pb.Left + schrittweite;
                    }
                    if ((this.pb.Left - 5) % 40 == 0)
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

                case Direction_G.LEFT:
                    if (this.pb.Left > 5)
                    {
                        this.pb.Left = this.pb.Left - schrittweite;
                    }
                    if ((this.pb.Left - 5) % 40 == 0)
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

                case Direction_G.UP:
                    if (this.pb.Top > 5)
                    {
                        this.pb.Top = this.pb.Top - schrittweite;
                    }
                    
                    if ((this.pb.Top - 5) % 40 == 0)
                    {

                        onhorizontalline = true;
                        onvertikalline = true;
                    }
                    else
                    {
                        onvertikalline = true;
                        onhorizontalline = false;
                    }

                    break;
                case Direction_G.DOWN:
                    if (this.pb.Top < 365)
                    {
                        this.pb.Top = this.pb.Top + schrittweite;
                    }
                    
                    if ((this.pb.Top - 5) % 40 == 0)
                    {
                        ONHORIZONTALLINE = true;
                        onvertikalline = true;

                    }
                    else
                    {
                        onvertikalline = true;
                        onhorizontalline = false;
                    }

                    break;

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
