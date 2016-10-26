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
        int vakx, vaky, mousex, mousey, kleur, x, y, geenoptie;
        int steen = 50;
        int[,] speelveld;
        int beurt = 0;
        bool help = false;
        int teller_rood = 0;
        int teller_blauw = 0;
        int hintaantal = 0;
        int stenenaantal = 4;
        
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
            label_x.Text = "breedte:";
            label_y.Text = "hoogte:";
        }


        //Help button
        private void button1_Click(object sender, EventArgs ea)
        {
            if (help)
            {
                help = false;
            }
            else
            {
                help = true;
            }

            Panel.Invalidate();
        }

        //Nieuw spel button
        private void button2_Click(object sender, EventArgs ea)
        {
            this.nieuwSpel();
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

        //klik-methode om een steen te zetten
        private void klik(object obj, MouseEventArgs mea)
        {
            //zorgen dat het geklikt een waarde voor vakx en vaky wordt
            mousex = mea.X / steen;
            mousey = mea.Y / steen;

            //beurt blauw-rood afwisselen & geklikte veld een steenwaarde geven
            if (speelveld[mousex, mousey] != 1 && speelveld[mousex, mousey] != 2 && speelveld[mousex, mousey] == 3)
            {
                //bepalen wie er aan de beurt is en dus welke kleur steen geplaatst wordt
                if (beurt % 2 == 0)
                {
                    speelveld[mousex, mousey] = 2;
                }
                else
                {
                    speelveld[mousex, mousey] = 1;
                }
                beurt++;

                //array opschonen van hints
                for (int t = 0; t < vakx; t++)
                {
                    for (int s = 0; s < vaky; s++)
                    {
                        //alle vakken met waarde 3 (hint) leeg maken (0)
                        if (speelveld[t, s] == 3)
                        {
                            speelveld[t, s] = 0;
                        }
                    }
                }

                //methode om de kleur van andere stenen mee te laten veranderen
                kleurVerander(mousex, mousey);
                //tellertje voor aantal stenen op het veld
                stenenaantal++;

                Panel.Invalidate();
            }
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

        //methode om een nieuw spel starten
        private void nieuwSpel()
        {
            stenenaantal = 4;
            geenoptie = 0;

            //waardes resetten
            for (int t = 0; t < vakx; t++)
            {
                for (int s = 0; s < vaky; s++)
                {
                    //alle velden leeg maken
                    speelveld[t, s] = 0;
                }
            }

            veldWaarde();
            hintaantal = 1;
            beurt = 0;
            geenoptie = 0;
            stenenaantal = 4;

            //grootte speelveld aanpassen
            Panel.Size = new Size(vakx * steen, vaky * steen);

            Panel.Invalidate();
        }

        //hier maken we de tweedimensionele array aan
        private void beginArray(int vakx, int vaky)
        {
            //Deze array is belangrijk
            speelveld = new int[vakx, vaky];

            //alle velden leeg maken (0)
            for(int t =0; t< vakx; t++)
            {
                for(int s = 0; s<vaky; s++)
                {
                    speelveld[t, s] = 0;
                }
            }

            //beginsituatie speelveld, 4 stenen in het midden
            speelveld[vakx / 2 - 1, vaky / 2 - 1] = 2;
            speelveld[vakx / 2, vaky / 2] = 2;
            speelveld[vakx / 2, vaky / 2 - 1] = 1;
            speelveld[vakx / 2 - 1, vaky / 2] = 1;
        }

        //deze methode geeft de mogelijke plaatsen aan
        private void steenHulp()
        {
            //int kleur afhankelijk maken van wie aan de beurt is
            if (beurt % 2 == 0)
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
                        legaleZet(t, s);
                    }
                }
            }
        }


        //methode om te bepalen of iets een legale zet is
        private void legaleZet(int t, int s)
        {
            //rastertje maken die van -1 t/m 1 loopt, zowel voor x als voor y
            for (x = -1; x <= 1; x++)
            {
                for (y = -1; y <= 1; y++)
                {
                    //zorgen dat ie niet buiten de array van speelveld valt
                    if (t + x < vakx && t + x >= 0 && s + y < vaky && s + y >= 0)
                    {
                        //kijken in het raster rondom de steen van de tegenpartij: veld moet niet al bezet zijn door een steen
                        if (speelveld[t + x, s + y] != 1 && speelveld[t + x, s + y] != 2)
                        {
                            //zorgen dat ie niet buiten de array van speelveld valt
                            if (t + x * -1 < vakx && t + x * -1 >= 0 && s + y * -1 < vaky && s + y * -1 >= 0)
                            {
                                //als ergens in het raster het tegenoverliggende veld van dezelfde kleur is
                                if (speelveld[t + x * -1, s + y * -1] == kleur)
                                {
                                    //zet een hint neer (3)
                                    speelveld[t + x, s + y] = 3;
                                }
                                //mocht de tegenovergestelde steen van de hint de kleur van de tegenstander hebben
                                else if (speelveld[t + x * -1, s + y * -1] != kleur && speelveld[t + x * -1, s + y * -1] != 0 && speelveld[t + x * -1, s + y * -1] != 3)
                                {
                                    //verder kijken dan bovengenoemde steen
                                    for (int verder = 2;
                                        t + verder * x * -1 < vakx && t + verder * x * -1 >= 0 && s + verder * y * -1 < vaky && s + verder * y * -1 >= 0;
                                        verder++)
                                    {
                                        //als het veld verder leeg is of een hint bevat: afbreken
                                        if (speelveld[t + verder * x * -1, s + verder * y * -1] == 0 || speelveld[t + verder * x * -1, s + verder * y * -1] == 3)
                                            break;
                                        //als het veld verder de eigen kleur is: hint maken (3)
                                        if (speelveld[t + verder * x * -1, s + verder * y * -1] == kleur)
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
        }

        //methode om de ingesloten stenen van kleur te laten veranderen
        private void kleurVerander(int t, int s)
        {
            //kijken in het raster rondom de gezette steen
            for(int gx = -1; gx <= 1; gx++)
            {
                for(int gy = -1; gy <= 1; gy++)
                {
                    //zorgen dat ie niet buiten de array vliegt
                    if (t + gx < vakx && t + gx >= 0 && s + gy < vaky && s + gy >= 0)
                    {
                        //kijken of steen naast de gezette steen van de andere kleur is
                        if (speelveld[t + gx, s + gy] != kleur && speelveld[t + gx, s + gy] != 3 && speelveld[t + gx, s + gy] != 0)
                        {
                            //teller mee laten lopen
                            int teller = 1;
                            //while-loop doorlopen zolang de rij stenen van de andere kleur zijn
                            while (speelveld[t + gx, s + gy] != kleur && speelveld[t + gx, s + gy] != 3 && speelveld[t + gx, s + gy] != 0 && t + gx * teller >= 0 && t + gx * teller < vakx && s + gy * teller >= 0 && s + gy * teller < vaky)
                            {
                                //als de rij stenen eindigt met een leeg veld of een hint: rij afbreken
                                if (speelveld[t + gx * teller, s + gy * teller] == 0 || speelveld[t + gx * teller, s + gy * teller] == 3)
                                    break;
                                //als de rij stenen een steen van de eigen kleur tegenkomen: doe het volgende
                                if (speelveld[t + gx * teller, s + gy * teller] == kleur)
                                {
                                    //teller terug laten lopen, zodat je alle stenen ertussen bereikt
                                    for (int z = teller; z > 0; z--)
                                    {
                                        //deze stenen de eigen kleur maken
                                        speelveld[t + gx * z, s + gy * z] = kleur;
                                    }
                                }
                                //teller ophogen
                                teller++;
                            }
                        }
                        
                    }
                }
            }
        }

        //methode om de score bij te houden
        private void score()
        {
            teller_rood = 0;
            teller_blauw = 0;

            //veld doorlopen
            for(int t = 0; t < vakx; t++)
            {
                for(int s = 0; s < vaky; s++)
                {
                    //bij elke rode steen de rode teller ophogen
                    if(speelveld[t, s] == 1)
                    {
                        teller_rood++;
                    }
                    //bij elke blauwe steen de blauwe teller ophogen
                    else if(speelveld[t, s] == 2)
                    {
                        teller_blauw++;
                    }
                }
            }

            //score op het scherm weergeven
            roodScore.Text = "Rood: " + teller_rood + " stenen";
            blauwScore.Text = "Blauw: " + teller_blauw + " stenen";
        }

        //methode om het einde van het spel te bepalen
        private void eindSpel()
        { 
            //veld doorlopen
            for(int t = 0; t < vakx; t++)
            {
                for(int s = 0; s < vaky; s++)
                {
                    if(speelveld[t,s] == 3)
                    {
                        //aantal hints tellen
                        hintaantal++;
                        geenoptie = 0;
                    }
                }
            }
            
            //eindscore laten zien als het veld vol is of als beide partijnen niet meer kunnen
            if(stenenaantal == vakx*vaky || geenoptie == 1)
            {
                if(teller_blauw > teller_rood)
                {
                    MessageBox.Show("Blauw heeft gewonnen!");
                    this.nieuwSpel(); 
                }
                else if(teller_rood > teller_blauw)
                {
                    MessageBox.Show("Rood heeft gewonnen!");
                    this.nieuwSpel();
                }
                else
                {
                    MessageBox.Show("Remise!");
                    this.nieuwSpel();
                }
                geenoptie = 0;
            }

            //als er geen hints zijn (kleur kan dus niks zetten), de beurt laten overslaan
            if (hintaantal == 0)
            {
                geenoptie++;
                beurt++;
                MessageBox.Show("De andere speler kan niet, ga nog een keer!");
                Panel.Invalidate();
            }

            hintaantal = 0;
        }

        //panel voor het paint event
        private void panel1_Paint(object sender, PaintEventArgs pea)
        {
           this.steenHulp();
           score();             
            //veld doorlopen
            for (int t = 0; t <= vakx; t++)
            {
                for(int s = 0; s<= vaky; s++)
                {
                    //veld tekenen
                    Pen pen = new Pen(Color.Black, 5);
                    pea.Graphics.DrawRectangle(pen, 0, 0, Panel.Width-1, Panel.Height-1);
                    //horizontale lijnen
                    pea.Graphics.DrawLine(Pens.Black, t * Panel.Width / vakx, 0, t * Panel.Width / vakx, Panel.Height);
                    //verticale lijnen
                    pea.Graphics.DrawLine(Pens.Black, 0, s * Panel.Height / vaky, Panel.Width, s * Panel.Height / vaky);                
                }
            }
            
            //veld doorlopen
            for(int t = 0; t < vakx; t++)
            {
                for(int s = 0; s < vaky; s++)
                {
                    if(speelveld[t,s] != 0)
                    {
                        //rode steen tekenen
                        if(speelveld[t,s] == 1)
                        {
                            pea.Graphics.FillEllipse(Brushes.Red, t * Panel.Width / vakx + 5, s * Panel.Height / vaky + 5, steen -10, steen -10);
                        }
                        //blauwe steen tekenen
                        else if(speelveld[t, s] == 2)
                        {
                            pea.Graphics.FillEllipse(Brushes.DodgerBlue, t * Panel.Width / vakx + 5, s * Panel.Height / vaky + 5, steen - 10, steen - 10);
                        }
                        //blauwe hint tekenen
                        else if (speelveld[t,s] == 3 && help && beurt % 2 ==0)
                        {
                            pea.Graphics.FillEllipse(Brushes.DodgerBlue, t * Panel.Width / vakx + 15, s * Panel.Height / vaky + 15, steen - 30, steen - 30);
                        }
                        //rode hint tekenen
                        else if(speelveld[t,s] == 3 && help && beurt % 2 ==1)
                        {
                            pea.Graphics.FillEllipse(Brushes.Red, t * Panel.Width / vakx + 15, s * Panel.Height / vaky + 15, steen - 30, steen - 30);
                        }
                       
                    }
                }
            }

            //tekst op het scherm wie er aan de beurt is
            if (beurt % 2 == 0)
            {
                Beurtbox.Text = "Blauw is aan de beurt.";
            }
            else
            {
                Beurtbox.Text = "Rood is aan de beurt.";
            }
            eindSpel();
        }
    }
}
