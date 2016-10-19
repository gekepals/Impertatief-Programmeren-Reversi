using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imperatief_Programmeren___Reversi
{
    public partial class Reversi : Form
    {
        //variabelen
        int vakx, vaky;
        int steen = 50;
        int[,] speelveld;
        int mousex, mousey;
        int teller = 0;

        //indeling veld
        //0 is leeg
        //1 is rood
        //2 is blauw
        //3 is hulp


        public Reversi()
        {
            InitializeComponent();
            this.Text = "Reversi";
            vakx = 10;
            vaky = 10;
            Panel.Size = new Size(vakx * steen, vaky * steen);

            //evenementen
            Panel.MouseClick += klik;
            OK_button.Click += button2_Click;
            x_waarde.KeyDown += x_waarde_enter;
            y_waarde.KeyDown += y_waarde_enter;

            /*
            //array
            speelveld = new int[vakx, vaky];
            speelveld[vakx / 2 - 1, vaky / 2 - 1] = 2;
            speelveld[vakx / 2, vaky / 2] = 2;
            speelveld[vakx / 2, vaky / 2 - 1] = 1;
            speelveld[vakx / 2 - 1, vaky / 2] = 1;
            */

            //aanpassen grootte speelveld - labels & tekstboxen
            label1.Text = "Grootte van het speelveld:";
            label_x.Text = "breedte:";
            label_y.Text = "hoogte:";          

        }



        //Help button
        private void button1_Click(object sender, EventArgs ea)
        {
            System.Windows.Forms.MessageBox.Show("Hier moeten instructies komen.");
            
        }

        //Nieuw spel button
        private void button2_Click(object sender, EventArgs ea)
        {
            beginArray(vakx, vaky);
            //evt aanpassing van speelveld
            veldWaarde();

            //waardes resetten
            for (int t = 0; t < vakx; t++)
            {
                for (int s = 0; s < vakx; s++)
                {
                    speelveld[t, s] = 0;
                }
            }

            /*
            //beginwaardes meegeven
            speelveld[vakx / 2 - 1, vaky / 2 - 1] = 2;
            speelveld[vakx / 2, vaky / 2] = 2;
            speelveld[vakx / 2, vaky / 2 - 1] = 1;
            speelveld[vakx / 2 - 1, vaky / 2] = 1;
            */

           
            
            //grootte speelveld aanpassen
            Panel.Size = new Size(vakx * steen, vaky * steen);

            Panel.Invalidate();
        }

        //indrukken ENTER na tekstbox x_waarde
        public void x_waarde_enter(object obj, KeyEventArgs kea)
        {
            if (kea.KeyCode == Keys.Enter)
                button2_Click(this, kea);
        }

        //indrukken ENTER na tekstbox y_waarde
        public void y_waarde_enter(object obj, KeyEventArgs kea)
        {
            if (kea.KeyCode == Keys.Enter)
                button2_Click(this, kea);
        }


        private void klik(object obj, MouseEventArgs mea)
        {
            mousex = mea.X / steen;
            mousey = mea.Y / steen;

            //beurt blauw-rood afwisselen
            if (speelveld[mousex, mousey] != 1 && speelveld[mousex, mousey] != 2 && speelveld[mousex,mousey] == 3)
            {
                if (teller % 2 == 0)
                {
                    speelveld[mousex, mousey] = 2;
                }
                else
                {
                    speelveld[mousex, mousey] = 1;
                }
                teller += 1;
            }

            //array opschonen van tips
            for (int t = 0; t < vakx; t++)
            {
                for (int s = 0; s < vakx; s++)
                {
                    if (speelveld[t, s] == 3)
                    {
                        speelveld[t, s] = 0;
                    }
                }
            }
            Panel.Invalidate();
        }

        private void veldWaarde()
        {
            int w_vakx, w_vaky;
            int.TryParse(x_waarde.Text, out w_vakx);
            int.TryParse(y_waarde.Text, out w_vaky);
            if (w_vakx > 2)
                vakx = w_vakx;
            if (w_vaky > 2)
                vaky = w_vaky;


            beginArray(vakx, vaky);
            Panel.Invalidate();

            //probleem: zodra vakx of vaky groter dan beginwaardes ervan wordt gemaakt knalt ie eruit
        }

        private void beginArray(int vakx, int vaky)
        {
            speelveld = new int[vakx, vaky];
            speelveld[vakx / 2 - 1, vaky / 2 - 1] = 2;
            speelveld[vakx / 2, vaky / 2] = 2;
            speelveld[vakx / 2, vaky / 2 - 1] = 1;
            speelveld[vakx / 2 - 1, vaky / 2] = 1;
        }


        private void steenHulp()
        {
            int kleur;
            if (teller % 2 == 0)
                kleur = 2;
            else
                kleur = 1;

            for (int t = 0; t < vakx; t++)
            {
                for (int s = 0; s < vakx; s++)
                {
                    //kijken naar de stenen van de andere partij
                    if (speelveld[t, s] != kleur && speelveld[t, s] != 0 && speelveld[t, s] != 3)
                    {
                        for(int x = -1; x<=1; x++)
                        {
                            for(int y = -1; y<= 1; y++)
                            {
                                //kijken in het raster rondom de steen van de tegenpartij + niet buiten speelveld vallen
                                if(speelveld[t+x,s+y] != 1 && speelveld[t+x,s+y] != 2)
                                {
                                    if(speelveld[t+x*-1,s+y*-1] == kleur)
                                    {
                                        speelveld[t + x, s + y] = 3;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }



        //panel voor het paint event
        private void panel1_Paint(object sender, PaintEventArgs pea)
        {
           
            beginArray(vakx,vaky);

           this.steenHulp();
                        
            for (int t = 0; t <= vakx; t++)
            {
                for(int s = 0; s<= vaky; s++)
                {
                    pea.Graphics.DrawRectangle(Pens.Black, 0, 0, Panel.Width-1, Panel.Height-1);
                    //horizontale lijnen
                    pea.Graphics.DrawLine(Pens.Black, t * Panel.Width / vakx, 0, t * Panel.Width / vakx, Panel.Height);
                    //verticale lijnen
                    pea.Graphics.DrawLine(Pens.Black, 0, s * Panel.Height / vaky, Panel.Width, s * Panel.Height / vaky);
                }
            }
            
            for(int t = 0; t < vakx; t++)
            {
                for(int s = 0; s < vaky; s++)
                {
                    if(speelveld[t,s] != 0)
                    {
                        if(speelveld[t,s] == 1)
                        {
                            pea.Graphics.FillEllipse(Brushes.Red, t * Panel.Width / vakx, s * Panel.Height / vaky, steen, steen);
                        }
                        else if(speelveld[t,s] == 3)
                        {
                            pea.Graphics.DrawEllipse(Pens.Black, t * Panel.Width / vakx + 15, s * Panel.Height / vaky + 15, steen - 25, steen - 25);
                        }
                        else
                        {
                            pea.Graphics.FillEllipse(Brushes.Blue, t * Panel.Width / vakx, s * Panel.Height / vaky, steen, steen);
                        }
                    }
                }
            }

            if (teller % 2 == 0)
            {
                Beurtbox.Text = "Blauw is aan de beurt.";
            }
            else
            {
                Beurtbox.Text = "Rood is aan de beurt.";
            }
        }
    }
}
