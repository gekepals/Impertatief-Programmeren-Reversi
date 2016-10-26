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
        int kleur, x, y;

        //indeling veld
        //0 is leeg
        //1 is rood
        //2 is blauw
        //3 is hulp blauw
        // 4 is hulp rood


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

            //beurt blauw-rood afwisselen & geklikte veld een steenwaarde geven
            if (speelveld[mousex, mousey] != 1 && speelveld[mousex, mousey] != 2 && speelveld[mousex, mousey] == 3 || speelveld[mousex, mousey] == 4)
            {
                //bepalen wie er aan de beurt is en dus welke kleur steen geplaatst wordt
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

            kleurVerander(mousex, mousey);

            Panel.Invalidate();
        }

        //Deze methode past de hoogte en de breedte aan van de array/speelveld
        private void veldWaarde()
        {
            int w_vakx, w_vaky;
            //waardes uit de textboxen parsen
            int.TryParse(x_waarde.Text, out w_vakx);
            int.TryParse(y_waarde.Text, out w_vaky);
            //waardes moeten minstens 2 zijn, anders te klein om een veld van te maken
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

            //veld opschonen van vorige hints
            for (int t = 0; t < vakx; t++)
            {
                for (int s = 0; s < vaky; s++)
                {
                    //alle hints leeg maken, oftewel waarde 0 geven
                    if (speelveld[t, s] == 3 || speelveld[t, s] == 4)
                    {
                        speelveld[t, s] = 0;
                    }
                }
            }


            //het hele veld doorlopen
            for (int t = 0; t < vakx; t++)
            {
                for (int s = 0; s < vaky; s++)
                {
                    //kijken naar de stenen van de andere partij
                    if (speelveld[t, s] != kleur && speelveld[t, s] != 0 && speelveld[t, s] != 3 && speelveld[t, s] != 4)
                    {
                        legaleZet(t, s);
                    }
                }
            }
        }

        //bepalen of iets een legale zet is
        private void legaleZet(int t, int s)
        {
            //raster rondom steen bekijken: beginnen bij 1, ophogen indien nodig
            for (int a = 1; a < vakx; a++)
            {
                for (int b = 1; b < vaky; b++)
                {
                    //raster doorlopen
                    for (x = -a; x <= a; x++)
                    {
                        for (y = -b; y <= b; y++)
                        {
                            //zorgen dat ie niet buiten de array van speelveld valt
                            if (t + x < vakx && t + x >= 0 && s + y < vaky && s + y >= 0)
                            {
                                //kijken in het raster rondom de steen van de tegenpartij
                                if (speelveld[t + x, s + y] != 1 && speelveld[t + x, s + y] != 2)
                                {
                                    if (t + x * -1 < vakx && t + x * -1 >= 0 && s + y * -1 < vaky && s + y * -1 >= 0)
                                    {
                                        if (speelveld[t + x * -1, s + y * -1] == kleur)
                                        {
                                            if (grenstAan(t + x, s + y) == true)
                                            {
                                                if (kleur == 2)
                                                {
                                                    speelveld[t + x, s + y] = 3;
                                                }
                                                else if (kleur == 1)
                                                {
                                                    speelveld[t + x, s + y] = 4;
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

        private bool grenstAan(int t, int s)
        {
            //veld rondom de betreffende steen doorlopen: oftewel door -1, 0, en 1 voor zowel x als y
            for (int a = -1; a <= 1; a++)
            {
                for (int b = -1; b <= 1; b++)
                {
                    //zorgen dat de waarde voor speelveld nog binnen speelveld past
                    if (t + a < vakx && s + b < vaky && t + a >= 0 && s + b >= 0)
                    {
                        //als aangrenzend veld 1 of 2 is, oftewel grenst aan een steen, return true
                        if (speelveld[t + a, s + b] == 1 || speelveld[t + a, s + b] == 2)
                            return true;
                    }
                }
            }
            //indien niet, return false
            return false;
        }

        private void kleurVerander(int t, int s)
        {
            //kijken rondom de gezette steen
            for(int gx = -1; gx <= 1; gx++)
            {
                for(int gy = -1; gy <= 1; gy++)
                {
                    //zorgen dat ie niet buiten de array vliegt
                    if (t + gx < vakx && t + gx >= 0 && s + gy < vaky && s + gy >= 0)
                    {
                        //kijken of steen naast de gezette steen van de andere kleur is
                        if (speelveld[t + gx, s + gy] != kleur)
                        {
                            int teller = 1;
                            //loop doorlopen zolang als de rij stenen van de andere kleur zijn
                            while (speelveld[t + gx, s + gy] != kleur && t + gx * teller >= 0 && t + gx * teller < vakx && s + gy * teller >= 0 && s + gy * teller < vaky)
                            {
                                //als de rij stenen op een gegeven moment een steen tegenkomt van eigen kleur
                                if (speelveld[t + gx * teller, s + gy * teller] == kleur)
                                {
                                    //teller terug laten lopen, zodat je alle stenen ertussen bereikt
                                    for (int z = teller; z > 0; z--)
                                    {
                                        //deze stenen de eigen kleur maken
                                        speelveld[t + gx * z, s + gy * z] = kleur;
                                    }
                                }
                                teller++;
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
                        //rode steen
                        if(speelveld[t,s] == 1)
                        {
                            pea.Graphics.FillEllipse(Brushes.Red, t * Panel.Width / vakx + 5, s * Panel.Height / vaky + 5, steen -10, steen -10);
                        }
                        //blauwe hint
                        else if(speelveld[t,s] == 3)
                        {
                            pea.Graphics.FillEllipse(Brushes.Blue, t * Panel.Width / vakx + 15, s * Panel.Height / vaky + 15, steen - 30, steen - 30);
                        }
                        //rode hint
                        else if(speelveld[t,s] == 4)
                        {
                            pea.Graphics.FillEllipse(Brushes.Red, t * Panel.Width / vakx + 15, s * Panel.Height / vaky + 15, steen - 30, steen - 30);
                        }
                        //blauwe steen
                        else
                        {
                            pea.Graphics.FillEllipse(Brushes.Blue, t * Panel.Width / vakx + 5, s * Panel.Height / vaky + 5, steen - 10, steen - 10);
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
