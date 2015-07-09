using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;

// refactoring is when you change lines of your code that already have worked to implement new things
// doublebuffering

namespace Pacman
{
    public partial class Form1 : Form
    {
        Pacman pacman = new Pacman();
        List<Ghost> ghostlist = new List<Ghost>();
        Graphics g = null;
        Raster raster = null;
        bool bewegung =false;                                          //wird true wenn erstmals eine taste gedrückt wird                                                  
        
        Random randy = new Random();
        int punkteanz = 0;
        int lives = 3;
        Thread a;
        SoundPlayer sp = new SoundPlayer("pacman.wav");
        
        AllePunkte ap = new AllePunkte();
       
        
        public Form1()
        {
            InitializeComponent();
            this.raster = new Raster(this.pictureBox1.ClientSize.Height, this.pictureBox1.ClientSize.Width);
            this.pictureBox1.Invalidate();
            Ghost g1 = new Ghost(645, 365, pbblue);                         // inizalisiert die Ghosts
            Ghost g2 = new Ghost(645, 5, pborange);
            Ghost g3 = new Ghost(5, 365, pbred);
            ghostlist.Add(g1);
            ghostlist.Add(g2);
            ghostlist.Add(g3);
            ap.HitPoint += new AllePunkte.HitPointHandler(ap_HitPoint);
            ap.Won +=new AllePunkte.WinHandler(WinMessage);
            
            a = new Thread(Play);                                           // Musik
            a.Name = "Pacman_Music";
            a.Start();
        }

        private void ap_HitPoint(Punkt p)
        {
            if (p.GetType().ToString().Contains("SpecialPunkt"))
            {
                punkteanz += 100;
            }
            punkteanz+=10;
        }        

        private void p_Draw_Paint(object sender, PaintEventArgs e)
        {
            this.g = e.Graphics;
            //new Rectangle().IntersectsWith(new Rectangle());
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            ap.DrawPunkte(g);
            //raster.Draw(g);                                                   // Zeichnet den Raster
                                                                               
            g.DrawRectangle(new Pen(Color.Red), 4, 4, 672, 392);                // Zeichnet RasterWand
            pacman.Draw(g);            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PrintCoordinates();

            l_punkte.Text = "Points: " + punkteanz;

            if (bewegung == true)
            {
                pacman.Move();                                          // Bewegt den Pacman

                ap.CheckPoint(pacman);                                  // Prüft ob der Pacman einen Punkt gschnattert hat

                foreach (Ghost ghost in ghostlist)                      // prüft ob dem Spieler Leben abgezogen wird
                {                   
                    CheckGhostHit(ghost);
                    ghost.Move(pacman, randy);
                    
                }

            }
            CheckLives();

            pictureBox1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (bewegung == false)
            {
                bewegung = true;
            }
            switch (e.KeyData)                                          // Gibt dem Pacman die Direction
            {
                
                case Keys.Up:
                           
                            pacman.Dir(Pacman.Direction.UP);
                        
                        break;
                case Keys.Down:
                            
                            pacman.Dir(Pacman.Direction.DOWN);
                       
                        break;
               
                case Keys.Left:
                         
                            pacman.Dir(Pacman.Direction.LEFT);
                        
                        break;
                case Keys.Right:
                        
                            pacman.Dir(Pacman.Direction.RIGHT);
                        
                        break;
            }
            

        }

        private void Play()
        {
            sp.PlayLooping();
        }

        private void WinMessage()
        {            
                bewegung = false;                
                if (MessageBox.Show("U ve won!") == DialogResult.OK)
                {
                    Application.Exit();
                }
            
        }

        private void PrintCoordinates()
        {
            label1.Text = Convert.ToString(pacman.X);
            label2.Text = Convert.ToString(pacman.Y);
            foreach (Ghost ghost in ghostlist)
            {
                label3.Text = Convert.ToString(pbblue.Left);
                label4.Text = Convert.ToString(pbblue.Top);
                label5.Text = Convert.ToString(pbred.Left);
                label6.Text = Convert.ToString(pbred.Top);
                label7.Text = Convert.ToString(pborange.Left);
                label8.Text = Convert.ToString(pborange.Top);
            }
        }

        private void CheckGhostHit(Ghost ghost)
        {
            if (ghost.CheckPoint(pacman) == true)
            {
                lives--;
                l_lives.Text = "Lives: " + lives;
                bewegung = false;
            }
        }

        private void CheckLives()
        {
            if (lives == 0)
            {
                bewegung = false;
                lives = 1;
                if (MessageBox.Show("U ve lost!") == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void l_lives_Click(object sender, EventArgs e)
        {

        }

        private void l_punkte_Click(object sender, EventArgs e)
        {

        }
       
    }

    

}
