namespace _2048windowsform
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2048 = new System.Windows.Forms.Label();
            this.panelJoueur = new System.Windows.Forms.Panel();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.quitNickname = new System.Windows.Forms.Button();
            this.labelJoueur = new System.Windows.Forms.Label();
            this.textNickName = new System.Windows.Forms.TextBox();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonScore = new System.Windows.Forms.Button();
            this.panelBestScores = new System.Windows.Forms.Panel();
            this.buttonQuitScore = new System.Windows.Forms.Button();
            this.BestScores = new System.Windows.Forms.Label();
            this.labelBestScores = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelJoueur.SuspendLayout();
            this.panelBestScores.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(197, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 62);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(197, 431);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 47);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2048
            // 
            this.label2048.Font = new System.Drawing.Font("Joystix Monospace", 50F);
            this.label2048.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2048.Location = new System.Drawing.Point(12, 9);
            this.label2048.Name = "label2048";
            this.label2048.Size = new System.Drawing.Size(292, 92);
            this.label2048.TabIndex = 2;
            this.label2048.Text = "2048";
            this.label2048.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panelJoueur
            // 
            this.panelJoueur.Controls.Add(this.buttonPlay);
            this.panelJoueur.Controls.Add(this.quitNickname);
            this.panelJoueur.Controls.Add(this.labelJoueur);
            this.panelJoueur.Controls.Add(this.textNickName);
            this.panelJoueur.Location = new System.Drawing.Point(121, 208);
            this.panelJoueur.Name = "panelJoueur";
            this.panelJoueur.Size = new System.Drawing.Size(303, 234);
            this.panelJoueur.TabIndex = 6;
            this.panelJoueur.Visible = false;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlay.Image")));
            this.buttonPlay.Location = new System.Drawing.Point(220, 177);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(51, 22);
            this.buttonPlay.TabIndex = 3;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // quitNickname
            // 
            this.quitNickname.FlatAppearance.BorderSize = 0;
            this.quitNickname.Image = ((System.Drawing.Image)(resources.GetObject("quitNickname.Image")));
            this.quitNickname.Location = new System.Drawing.Point(45, 176);
            this.quitNickname.Name = "quitNickname";
            this.quitNickname.Size = new System.Drawing.Size(48, 23);
            this.quitNickname.TabIndex = 2;
            this.quitNickname.TabStop = false;
            this.quitNickname.UseVisualStyleBackColor = true;
            this.quitNickname.Click += new System.EventHandler(this.quitNickname_Click);
            // 
            // labelJoueur
            // 
            this.labelJoueur.AutoSize = true;
            this.labelJoueur.Font = new System.Drawing.Font("Joystix Monospace", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJoueur.Location = new System.Drawing.Point(42, 55);
            this.labelJoueur.Name = "labelJoueur";
            this.labelJoueur.Size = new System.Drawing.Size(115, 18);
            this.labelJoueur.TabIndex = 1;
            this.labelJoueur.Text = "Nickname:";
            // 
            // textNickName
            // 
            this.textNickName.Font = new System.Drawing.Font("Joystix Monospace", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNickName.Location = new System.Drawing.Point(45, 106);
            this.textNickName.Multiline = true;
            this.textNickName.Name = "textNickName";
            this.textNickName.Size = new System.Drawing.Size(226, 33);
            this.textNickName.TabIndex = 0;
            this.textNickName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textNickName_KeyUp);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Image = ((System.Drawing.Image)(resources.GetObject("buttonContinue.Image")));
            this.buttonContinue.Location = new System.Drawing.Point(213, 286);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(113, 34);
            this.buttonContinue.TabIndex = 4;
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Visible = false;
            this.buttonContinue.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonScore
            // 
            this.buttonScore.Image = ((System.Drawing.Image)(resources.GetObject("buttonScore.Image")));
            this.buttonScore.Location = new System.Drawing.Point(213, 349);
            this.buttonScore.Name = "buttonScore";
            this.buttonScore.Size = new System.Drawing.Size(115, 48);
            this.buttonScore.TabIndex = 5;
            this.buttonScore.UseVisualStyleBackColor = true;
            this.buttonScore.Click += new System.EventHandler(this.button4_Click);
            // 
            // panelBestScores
            // 
            this.panelBestScores.Controls.Add(this.buttonQuitScore);
            this.panelBestScores.Controls.Add(this.BestScores);
            this.panelBestScores.Controls.Add(this.labelBestScores);
            this.panelBestScores.Controls.Add(this.label1);
            this.panelBestScores.Location = new System.Drawing.Point(1, 0);
            this.panelBestScores.Name = "panelBestScores";
            this.panelBestScores.Size = new System.Drawing.Size(554, 564);
            this.panelBestScores.TabIndex = 6;
            this.panelBestScores.Visible = false;
            // 
            // buttonQuitScore
            // 
            this.buttonQuitScore.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuitScore.Image")));
            this.buttonQuitScore.Location = new System.Drawing.Point(197, 484);
            this.buttonQuitScore.Name = "buttonQuitScore";
            this.buttonQuitScore.Size = new System.Drawing.Size(144, 48);
            this.buttonQuitScore.TabIndex = 6;
            this.buttonQuitScore.UseVisualStyleBackColor = true;
            this.buttonQuitScore.Click += new System.EventHandler(this.buttonQuitScore_Click);
            // 
            // BestScores
            // 
            this.BestScores.AutoSize = true;
            this.BestScores.Font = new System.Drawing.Font("Joystix Monospace", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BestScores.Location = new System.Drawing.Point(178, 102);
            this.BestScores.Name = "BestScores";
            this.BestScores.Size = new System.Drawing.Size(173, 23);
            this.BestScores.TabIndex = 5;
            this.BestScores.Text = "Best Scores";
            // 
            // labelBestScores
            // 
            this.labelBestScores.Font = new System.Drawing.Font("Joystix Monospace", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.labelBestScores.Location = new System.Drawing.Point(87, 133);
            this.labelBestScores.Name = "labelBestScores";
            this.labelBestScores.Size = new System.Drawing.Size(467, 345);
            this.labelBestScores.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Joystix Monospace", 50F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 92);
            this.label1.TabIndex = 3;
            this.label1.Text = "2048";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(552, 559);
            this.Controls.Add(this.panelBestScores);
            this.Controls.Add(this.buttonScore);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.panelJoueur);
            this.Controls.Add(this.label2048);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Menu2048";
            this.panelJoueur.ResumeLayout(false);
            this.panelJoueur.PerformLayout();
            this.panelBestScores.ResumeLayout(false);
            this.panelBestScores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2048;
        private System.Windows.Forms.Panel panelJoueur;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button quitNickname;
        private System.Windows.Forms.Label labelJoueur;
        private System.Windows.Forms.TextBox textNickName;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonScore;
        private System.Windows.Forms.Panel panelBestScores;
        private System.Windows.Forms.Label labelBestScores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BestScores;
        private System.Windows.Forms.Button buttonQuitScore;
    }
}