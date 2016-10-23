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
        int kleur;

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

            this.beginArray(vakx, vaky);

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
            //beginArray(vakx, vaky);
            //evt aanpassing van speelveld


            //waardes resetten
            for (int t = 0; t < vakx; t++)
            {
                for (int s = 0; s < vaky; s++)
                {
                    speelveld[t, s] = 0;
                }
            }

            veldWaarde();


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
            if (speelveld[mousex, mousey] != 1 && speelveld[mousex, mousey] != 2 && speelveld[mousex, mousey] == 3)
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

        //Deze methode past de hoogte en de breedte aan van de array/speelveld
        private void veldWaarde()
        {
            int w_vakx, w_vaky;
            int.TryParse(x_waarde.Text, out w_vakx);
            int.TryParse(y_waarde.Text, out w_vaky);
            if (w_vakx > 2)
                vakx = w_vakx;
            if (w_vaky > 2)
                vaky = w_vaky;

            this.beginArray(vakx, vaky);

            Panel.Invalidate();


        }

        //hier maken we de tweedimensionele array aan
        private void beginArray(int vakx, int vaky)
        {
            //Deze array is belangrijk
            speelveld = new int[vakx, vaky];
            speelveld[vakx / 2 - 1, vaky / 2 - 1] = 2;
            speelveld[vakx / 2, vaky / 2] = 2;
            speelveld[vakx / 2, vaky / 2 - 1] = 1;
            speelveld[vakx / 2 - 1, vaky / 2] = 1;

        }

        //deze methode geeft de mogelijke plaatsen aan
        private void steenHulp()
        {
            //int kleur;
            if (teller % 2 == 0)
                kleur = 2;
            else
                kleur = 1;

            //het hele veld doorlopen
            for (int t = 0; t < vakx; t++)
            {
                for (int s = 0; s < vaky; s++)
                {
                    //kijken naar de stenen van de andere partij
                    if (speelveld[t, s] != kleur && speelveld[t, s] != 0 && speelveld[t, s] != 3)
                    {
                        //legaleZet(t, s);
                        //raster rondom steen bekijken: beginnen bij 1, ophogen indien nodig
                        //probleem: hierbij nog bepaling dat ie niet buiten het veld eruit vliegt. Voor gemak heb ik nu 3 gekozen om deze code te testen
                        for(int a = 1; a < 3; a++)
                        {
                            for(int b = 1; b < 3; b++)
                            {
                                for (int x = -a; x <= a; x++)
                                {
                                    for (int y = -b; y <= b; y++)
                                    {
                                        //kijken in het raster rondom de steen van de tegenpartij + niet buiten speelveld vallen
                                        if (speelveld[t + x, s + y] != 1 && speelveld[t + x, s + y] != 2 && t + x < vakx && t + x > 0 && s + y < vaky && s + y > 0)
                                        {
                                            if (t + x * -1 < vakx && t + x * -1 > 0 && s + y * -1 < vaky && s + y * -1 > 0)
                                            {
                                                if (speelveld[t + x * -1, s + y * -1] == kleur)
                                                {
                                                    speelveld[t + x, s + y] = 3;
                                                    //probleem: code wordt te ver doorlopen, waardoor ook vakjes die niet grenzen aan een steen 3 worden
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }                                            
                    }
                }
            }
        }

        //deze methode werkt nog niet goed
        //idee is om een deel van steenhulp() in aparte methode te zetten zodat de code overzichtelijker wordt
        //methode om te bepalen of iets een legale zet is
        private void legaleZet(int t, int s)
        {
            //rondjes-schaal bepalen: begin bij 1, ophogen als nodig
            for (int x = 1; x < 3; x++)
            {
                for (int y = 1; y < 3; y++)
                {
                    //schaal laten lopen door -1, 0 en 1
                    for (int a = -x; a <= x; a++)
                    {
                        for (int b = -y; b <= y; b++)
                        {
                            //steen bepalen die niet kleur is en niet leeg --> vanuit daar kijken
                            if (speelveld[t, s] != 1 && speelveld[t, s] != 2)
                            {
                                //poging tot niet uit laten vliegen bij randen
                                //if (t + a * -1 > 0 && t + a * -1 < vakx && s + b * -1 > 0 && s + b * -1 < vaky)
                                //{
                                //bepalen of tegenovergestelde van veld de andere kleur is: dan geldige zet want insluiten
                                if (speelveld[t + a * -1, s + b * -1] == kleur)
                                {
                                    //dan het veld 3 maken, aka doorzichtig rondje
                                    speelveld[t + a, s + b] = 3;
                                }
                                //}
                            }
                        }
                    }
                
                }
            }
        }



        //panel voor het paint event
        private void panel1_Paint(object sender, PaintEventArgs pea)
        {
           
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
