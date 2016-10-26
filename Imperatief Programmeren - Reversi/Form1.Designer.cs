namespace Imperatief_Programmeren___Reversi
{
    partial class Reversi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel = new System.Windows.Forms.Panel();
            this.Help = new System.Windows.Forms.Button();
            this.Nieuw = new System.Windows.Forms.Button();
            this.Beurtbox = new System.Windows.Forms.Label();
            this.x_waarde = new System.Windows.Forms.TextBox();
            this.y_waarde = new System.Windows.Forms.TextBox();
            this.label_x = new System.Windows.Forms.Label();
            this.label_y = new System.Windows.Forms.Label();
            this.OK_button = new System.Windows.Forms.Button();
            this.blauwScore = new System.Windows.Forms.Label();
            this.roodScore = new System.Windows.Forms.Label();
            this.kop_grootte = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.PaleGreen;
            this.Panel.Location = new System.Drawing.Point(158, 16);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(500, 500);
            this.Panel.TabIndex = 0;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(12, 65);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(111, 32);
            this.Help.TabIndex = 1;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nieuw
            // 
            this.Nieuw.Location = new System.Drawing.Point(12, 16);
            this.Nieuw.Name = "Nieuw";
            this.Nieuw.Size = new System.Drawing.Size(112, 32);
            this.Nieuw.TabIndex = 2;
            this.Nieuw.Text = "Nieuw spel";
            this.Nieuw.UseVisualStyleBackColor = true;
            this.Nieuw.Click += new System.EventHandler(this.button2_Click);
            // 
            // Beurtbox
            // 
            this.Beurtbox.AutoSize = true;
            this.Beurtbox.Location = new System.Drawing.Point(9, 257);
            this.Beurtbox.Name = "Beurtbox";
            this.Beurtbox.Size = new System.Drawing.Size(0, 13);
            this.Beurtbox.TabIndex = 3;
            // 
            // x_waarde
            // 
            this.x_waarde.Location = new System.Drawing.Point(77, 146);
            this.x_waarde.Name = "x_waarde";
            this.x_waarde.Size = new System.Drawing.Size(46, 20);
            this.x_waarde.TabIndex = 5;
            // 
            // y_waarde
            // 
            this.y_waarde.Location = new System.Drawing.Point(75, 177);
            this.y_waarde.Name = "y_waarde";
            this.y_waarde.Size = new System.Drawing.Size(48, 20);
            this.y_waarde.TabIndex = 6;
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(9, 149);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(45, 13);
            this.label_x.TabIndex = 7;
            this.label_x.Text = "Grootte:";
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Location = new System.Drawing.Point(9, 180);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(47, 13);
            this.label_y.TabIndex = 8;
            this.label_y.Text = "Breedte:";
            // 
            // OK_button
            // 
            this.OK_button.Location = new System.Drawing.Point(42, 212);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(41, 23);
            this.OK_button.TabIndex = 9;
            this.OK_button.Text = "OK";
            this.OK_button.UseVisualStyleBackColor = true;
            // 
            // blauwScore
            // 
            this.blauwScore.AutoSize = true;
            this.blauwScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blauwScore.ForeColor = System.Drawing.Color.DodgerBlue;
            this.blauwScore.Location = new System.Drawing.Point(9, 326);
            this.blauwScore.Name = "blauwScore";
            this.blauwScore.Size = new System.Drawing.Size(45, 13);
            this.blauwScore.TabIndex = 10;
            this.blauwScore.Text = "Blauw:";
            // 
            // roodScore
            // 
            this.roodScore.AutoSize = true;
            this.roodScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roodScore.ForeColor = System.Drawing.Color.Red;
            this.roodScore.Location = new System.Drawing.Point(9, 353);
            this.roodScore.Name = "roodScore";
            this.roodScore.Size = new System.Drawing.Size(41, 13);
            this.roodScore.TabIndex = 11;
            this.roodScore.Text = "Rood:";
            // 
            // kop_grootte
            // 
            this.kop_grootte.AllowDrop = true;
            this.kop_grootte.AutoSize = true;
            this.kop_grootte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kop_grootte.Location = new System.Drawing.Point(9, 111);
            this.kop_grootte.Name = "kop_grootte";
            this.kop_grootte.Size = new System.Drawing.Size(143, 32);
            this.kop_grootte.TabIndex = 12;
            this.kop_grootte.Text = "Pas de grootte van \r\nhet scherm aan:";
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_label.Location = new System.Drawing.Point(9, 296);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(53, 16);
            this.score_label.TabIndex = 13;
            this.score_label.Text = "Score:";
            // 
            // Reversi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.kop_grootte);
            this.Controls.Add(this.roodScore);
            this.Controls.Add(this.blauwScore);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.label_y);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.y_waarde);
            this.Controls.Add(this.x_waarde);
            this.Controls.Add(this.Beurtbox);
            this.Controls.Add(this.Nieuw);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Panel);
            this.Name = "Reversi";
            this.Text = "Reversi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button Nieuw;
        private System.Windows.Forms.Label Beurtbox;
        private System.Windows.Forms.TextBox x_waarde;
        private System.Windows.Forms.TextBox y_waarde;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label_y;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Label blauwScore;
        private System.Windows.Forms.Label roodScore;
        private System.Windows.Forms.Label kop_grootte;
        private System.Windows.Forms.Label score_label;
    }
}

