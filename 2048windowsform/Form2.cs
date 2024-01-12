using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace _2048windowsform
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            string dossier = "2048";
            string sauvegarde = "sauvegarde.txt";
            string cheminDossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dossier);
            string cheminSauvegarde = Path.Combine(cheminDossier, sauvegarde);
            int[,] grillePrecedente = Form1.Continuer(cheminSauvegarde);

            if (Form1.Defaite(grillePrecedente) == false)
            {
                buttonContinue.Visible = true;
            }
            else buttonContinue.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonContinue.Visible = false;
            buttonScore.Visible = false;
            panelJoueur.Visible = true;
            buttonPlay.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merci pour jouer");
            Close();
        }


        public static void LireMeilleursScores(string cheminMeilleursScores, Label labelBestScores)
        {
            List<(int, string)> bestScores = new List<(int, string)>();
            string[] lignes = File.ReadAllLines(cheminMeilleursScores);
            foreach (var ligne in lignes)
            {
                string[] scores = ligne.Split(' ');
                int bestScore = Convert.ToInt32(scores[0]);
                string joueurScore = scores[1];
                bestScores.Add((bestScore, joueurScore));
            }
            int longitudTotal = 32;
            foreach (var score in bestScores)
            {
                    string textoFormateado = $"{score.Item1}".PadRight(longitudTotal, '.') + score.Item2;
                    labelBestScores.Text = labelBestScores.Text + "\n \n" + textoFormateado;
            }
        }

        private void textNickName_KeyUp(object sender, KeyEventArgs e)
        {
            
            //Je gère le cas où l'utilisateur enlèverait le nom sans avoir cliqué sur le bouton "Bienvenue"
            if (textNickName.Text != "")
            {
                buttonPlay.Enabled = true;
            }
            else
            {
                buttonPlay.Enabled = false;
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            string dossier = "2048";
            string sauvegardeMeilleursScores = "meilleursScores.txt";
            string cheminDossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dossier);
            string cheminMeilleursScores = Path.Combine(cheminDossier, sauvegardeMeilleursScores);
            string joueur = textNickName.Text; 
            int[,] grille = new int[4, 4];  // tableau du jeu
            int score = 0;
            Form1 startJeu = new Form1(joueur, score, grille, cheminMeilleursScores);
            startJeu.Show();
            panelJoueur.Visible = false;
            textNickName.Text = "";
            buttonPlay.Enabled = false;
            buttonContinue.Visible = true;
            buttonScore.Visible = true;
        }

        private void quitNickname_Click(object sender, EventArgs e)
        {
            buttonContinue.Visible = true;
            buttonScore.Visible = true;
            panelJoueur.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dossier = "2048";
            string sauvegarde = "sauvegarde.txt";
            string sauvegardeMeilleursScores = "meilleursScores.txt";
            string cheminDossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dossier);
            string cheminMeilleursScores = Path.Combine(cheminDossier, sauvegardeMeilleursScores);
            string cheminSauvegarde = Path.Combine(cheminDossier, sauvegarde);
            int[,] grillePrecedente = Form1.Continuer(cheminSauvegarde);
            int scorePrecedent = Form1.ContinuerScore(cheminSauvegarde);
            string joueurPrecedent = Form1.ContinuerJoueur(cheminSauvegarde);
            bool victoire = false; // Remarque : J'ai changé "win" a "victoire" para mantener la coherencia con el francés.
            Form1 startJeu = new Form1(joueurPrecedent, scorePrecedent, grillePrecedente, cheminMeilleursScores);
            startJeu.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelBestScores.Visible = true;
            string dossier = "2048";
            string sauvegardeMeilleursScores = "meilleursScores.txt";
            string cheminDossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dossier);
            string cheminMeilleursScores = Path.Combine(cheminDossier, sauvegardeMeilleursScores);
            LireMeilleursScores(cheminMeilleursScores, labelBestScores);
        }

        private void buttonQuitScore_Click(object sender, EventArgs e)
        {
            panelBestScores.Visible = false;
        }
    }
}
