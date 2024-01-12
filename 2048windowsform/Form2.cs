
/************************************************************************************************************************************************************************************************************************************

         Auteur : Santiago Messer
         Date 12.01.2024
         Description = Menu 2048

    
    (\ /)
    (o o) Pour qui ça soit plus joli visuellement vous aviez besoin de telecharger la font "Joystix Monospace" qui est dans le dossier du 2048
    (''')(''')


************************************************************************************************************************************************************************************************************************************/




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
        /// <summary>
        /// commencer mon jeu
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            string dossier = "2048";
            string sauvegarde = "sauvegarde.txt";
            string cheminDossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dossier);
            string cheminSauvegarde = Path.Combine(cheminDossier, sauvegarde);
            int[,] grillePrecedente = Form1.Continuer(cheminSauvegarde);

            if (Form1.Defaite(grillePrecedente) == false)//voire si je peux continuer et habiliter le bouton continuer
            {
                buttonContinue.Visible = true;
            }
            else buttonContinue.Visible = false;
        }

        /// <summary>
        /// button play 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            buttonContinue.Visible = false;
            buttonScore.Visible = false;
            panelJoueur.Visible = true;
            buttonPlay.Enabled = false;
        }

        /// <summary>
        /// button quitter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merci pour jouer");
            Close();
        }

        /// <summary>
        /// lire les meilleurs scores
        /// </summary>
        /// <param name="cheminMeilleursScores"></param>
        /// <param name="labelBestScores"></param>
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

        /// <summary>
        /// panneau pour commencer a joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// commencer une nouvelle partie et change mes valeurs de boutons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            string dossier = "2048";
            string sauvegardeMeilleursScores = "meilleursScores.txt";
            string sauvegarde = "sauvegarde.txt";
            string cheminDossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dossier);
            string cheminMeilleursScores = Path.Combine(cheminDossier, sauvegardeMeilleursScores);
            string cheminSauvegarde = Path.Combine(cheminDossier, sauvegarde);
            int[,] grillePrecedente = Form1.Continuer(cheminSauvegarde);
            int scorePrecedent = Form1.ContinuerScore(cheminSauvegarde);
            string joueurPrecedent = Form1.ContinuerJoueur(cheminSauvegarde);
            string joueur = textNickName.Text;
            Form1.SauvegarderMeilleursScores(cheminMeilleursScores, scorePrecedent, joueurPrecedent);
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

        /// <summary>
        /// bouton pour sortir de mon panel pour le nom de joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitNickname_Click(object sender, EventArgs e)
        {
            buttonContinue.Visible = true;
            buttonScore.Visible = true;
            panelJoueur.Visible = false;
        }

        /// <summary>
        /// bouton pour continuer une partie ancienne (si es qu'on peut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            Form1 startJeu = new Form1(joueurPrecedent, scorePrecedent, grillePrecedente, cheminMeilleursScores);
            startJeu.Show();

        }

        /// <summary>
        /// bouton pour lire les meilleurs scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            panelBestScores.Visible = true;
            string dossier = "2048";
            string sauvegardeMeilleursScores = "meilleursScores.txt";
            string cheminDossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dossier);
            string cheminMeilleursScores = Path.Combine(cheminDossier, sauvegardeMeilleursScores);
            LireMeilleursScores(cheminMeilleursScores, labelBestScores);
        }

        /// <summary>
        /// bouton pour sortir de les meilleurs scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuitScore_Click(object sender, EventArgs e)
        {
            panelBestScores.Visible = false;
        }
    }
}
