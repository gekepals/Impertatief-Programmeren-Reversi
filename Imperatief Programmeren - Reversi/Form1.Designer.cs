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
            this.label1 = new System.Windows.Forms.Label();
            this.x_waarde = new System.Windows.Forms.TextBox();
            this.y_waarde = new System.Windows.Forms.TextBox();
            this.label_x = new System.Windows.Forms.Label();
            this.label_y = new System.Windows.Forms.Label();
            this.OK_button = new System.Windows.Forms.Button();
            this.blauwScore = new System.Windows.Forms.Label();
            this.roodScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Location = new System.Drawing.Point(52, 121);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(300, 300);
            this.Panel.TabIndex = 0;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(277, 38);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(111, 32);
            this.Help.TabIndex = 1;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nieuw
            // 
            this.Nieuw.Location = new System.Drawing.Point(12, 37);
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
            this.Beurtbox.Location = new System.Drawing.Point(136, 40);
            this.Beurtbox.Name = "Beurtbox";
            this.Beurtbox.Size = new System.Drawing.Size(0, 13);
            this.Beurtbox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // x_waarde
            // 
            this.x_waarde.Location = new System.Drawing.Point(199, 82);
            this.x_waarde.Name = "x_waarde";
            this.x_waarde.Size = new System.Drawing.Size(46, 20);
            this.x_waarde.TabIndex = 5;
            // 
            // y_waarde
            // 
            this.y_waarde.Location = new System.Drawing.Point(304, 82);
            this.y_waarde.Name = "y_waarde";
            this.y_waarde.Size = new System.Drawing.Size(48, 20);
            this.y_waarde.TabIndex = 6;
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(149, 85);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(35, 13);
            this.label_x.TabIndex = 7;
            this.label_x.Text = "label2";
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Location = new System.Drawing.Point(251, 85);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(35, 13);
            this.label_y.TabIndex = 8;
            this.label_y.Text = "label2";
            // 
            // OK_button
            // 
            this.OK_button.Location = new System.Drawing.Point(373, 82);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(41, 23);
            this.OK_button.TabIndex = 9;
            this.OK_button.Text = "OK";
            this.OK_button.UseVisualStyleBackColor = true;
            // 
            // blauwScore
            // 
            this.blauwScore.AutoSize = true;
            this.blauwScore.Location = new System.Drawing.Point(439, 26);
            this.blauwScore.Name = "blauwScore";
            this.blauwScore.Size = new System.Drawing.Size(39, 13);
            this.blauwScore.TabIndex = 10;
            this.blauwScore.Text = "Blauw:";
            // 
            // roodScore
            // 
            this.roodScore.AutoSize = true;
            this.roodScore.Location = new System.Drawing.Point(439, 56);
            this.roodScore.Name = "roodScore";
            this.roodScore.Size = new System.Drawing.Size(36, 13);
            this.roodScore.TabIndex = 11;
            this.roodScore.Text = "Rood:";
            // 
            // Reversi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 484);
            this.Controls.Add(this.roodScore);
            this.Controls.Add(this.blauwScore);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.label_y);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.y_waarde);
            this.Controls.Add(this.x_waarde);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox x_waarde;
        private System.Windows.Forms.TextBox y_waarde;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label_y;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Label blauwScore;
        private System.Windows.Forms.Label roodScore;
    }
}

