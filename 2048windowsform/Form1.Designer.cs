using System.Drawing;
using System.Windows.Forms;

namespace _2048windowsform
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            Sauvegarder(grille, score, pseudo);
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2048 = new System.Windows.Forms.Label();
            this.labelQuit = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2048
            // 
            this.label2048.Font = new System.Drawing.Font("Joystix Monospace", 50F);
            this.label2048.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2048.Location = new System.Drawing.Point(68, 9);
            this.label2048.Name = "label2048";
            this.label2048.Size = new System.Drawing.Size(292, 92);
            this.label2048.TabIndex = 0;
            this.label2048.Text = "2048";
            this.label2048.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelQuit
            // 
            this.labelQuit.Image = ((System.Drawing.Image)(resources.GetObject("labelQuit.Image")));
            this.labelQuit.Location = new System.Drawing.Point(233, 639);
            this.labelQuit.Name = "labelQuit";
            this.labelQuit.Size = new System.Drawing.Size(138, 47);
            this.labelQuit.TabIndex = 1;
            this.labelQuit.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Joystix Monospace", 30F);
            this.labelScore.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelScore.Location = new System.Drawing.Point(12, 570);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(180, 48);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "Score";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 761);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelQuit);
            this.Controls.Add(this.label2048);
            this.Font = new System.Drawing.Font("Joystix Monospace", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2048;
        private System.Windows.Forms.Label labelQuit;
        private System.Windows.Forms.Label labelScore;
    }
}

