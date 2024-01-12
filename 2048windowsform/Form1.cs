/************************************************************************************************************************************************************************************************************************************

         Auteur : Santiago Messer
         Date 12.01.2024
         Description = fenetre avec le jeu 2048

    
    (\ /)
    (o o) Pour qui ça soit plus joli visuellement vous aviez besoin de telecharger la font "Joystix Monospace" qui est dans le dossier du 2048
    (''')(''')



************************************************************************************************************************************************************************************************************************************/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;


namespace _2048windowsform
{
    public partial class Form1 : Form
    {
        string dossier = "2048";
        string sauvegardeMeilleursScores = "meilleursScores.txt";
        string cheminDossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "2048");
        string cheminMeilleursScores = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "2048"), "meilleursScores.txt");
        Label[,] lbl = new Label[4, 4]; // tableau de Labels 4 lignes et 4 colonnes
        string pseudo;
        int score;
        int[,] grille;
        bool victoire = false; // Remarque : J'ai changé "win" a "victoire" para mantener la coherencia con el francés.

        /// <summary>
        /// initializate le jeu avec les donnes du menu
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="score"></param>
        /// <param name="grille"></param>
        /// <param name="cheminMeilleursScores"></param>
        public Form1(string pseudo, int score, int[,] grille, string cheminMeilleursScores)
        {
            this.score = score;
            this.grille = grille;
            this.pseudo = pseudo;
            this.cheminMeilleursScores = cheminMeilleursScores;
            commencerJeu();
        }

        /// <summary>
        /// commence le jeu
        /// </summary>
        public void commencerJeu()
        {
            InitializeComponent();
            InitialiserJeu(grille);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            afficher(grille, score); // s'occupe des textes et couleurs
        }

        /// <summary>
        /// je fais le label et la interface graphique
        /// </summary>
        /// <param name="grille"></param>
        public void InitialiserJeu(int[,] grille)
        {
            // Création des labels
            for (int ligne = 0; ligne < 4; ligne++)
            {
                for (int colonne = 0; colonne < 4; colonne++)
                {
                    lbl[ligne, colonne] = new Label(); // Création du label

                    // le 20 + 100 * colonne détermine où placer le premier label dans le form en X
                    // le 20 + 100 * ligne détermine où placer le label en Y
                    // le 90, 90 est la taille du label
                    lbl[ligne, colonne].Bounds = new Rectangle(120 + 100 * colonne, 125 + 100 * ligne, 90, 90);

                    // met le texte au milieu du label
                    lbl[ligne, colonne].TextAlign = ContentAlignment.MiddleCenter;
                    lbl[ligne, colonne].Font = new Font("Joystix Monospace", 20);
                    Controls.Add(lbl[ligne, colonne]); // Ajout visible à la page
                }
            }
            NombreAleatoireInitial(grille);
        }

        /// <summary>
        /// je fais le couleur de mon 2048
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        static Color ObtenirCouleur(int valeur)
        {
            switch (valeur)
            {
                case 0: return Color.White;
                case 2: return Color.Beige;
                case 4: return Color.DarkGray;
                case 8: return Color.MistyRose;
                case 16: return Color.SandyBrown;
                case 32: return Color.Orange;
                case 64: return Color.Tomato;
                case 128: return Color.DarkRed;
                case 256: return Color.Magenta;
                case 512: return Color.DarkMagenta;
                case 1024: return Color.DarkBlue;
                case 2048: return Color.Blue;
                default: return Color.Cyan;
            }
        }

        /// <summary>
        /// je afiche le label et le score
        /// </summary>
        /// <param name="grille"></param>
        /// <param name="score"></param>
        private void afficher(int[,] grille, int score)
        {
            // réaffiche tout le tableau avec les bonnes couleurs et les bons textes, conformément au tableau jeu
            for (int ligne = 0; ligne < 4; ligne++)
            {
                for (int colonne = 0; colonne < 4; colonne++)
                {
                    if (grille[ligne, colonne] > 0) // plot avec puissance de 2, pour faire 2 puissance n on fait 1<<n
                    {
                        lbl[ligne, colonne].Text = (grille[ligne, colonne]).ToString();
                    }
                    else
                    {
                        lbl[ligne, colonne].Text = "";
                    }
                    lbl[ligne, colonne].BackColor = ObtenirCouleur(grille[ligne, colonne]);
                }
                labelScore.Text = "Score " + this.pseudo + ": " + score;
            }
        }

        
        /// <summary>
        /// nombre aleatoire (regarder bug quand le ligne et les colognes sont le memes)
        /// </summary>
        /// <param name="grille"></param>
        public static void NombreAleatoireInitial(int[,] grille)
        {
            Random rd = new Random();
            int ligne, colonne, quatre;
            ligne = rd.Next(0, 4);
            colonne = rd.Next(0, 4);
            quatre = rd.Next(0, 9);
            for (int i = 0; i < 2; i++) //oublies pas de faire ça (ligne = ligne et cologne = cologne))
            {
                if (quatre == 1) grille[colonne, ligne] = 4;
                else grille[colonne, ligne] = 2;
                ligne = rd.Next(0, 4);
                colonne = rd.Next(0, 4);
                quatre = rd.Next(0, 9);
            }
        }

        /// <summary>
        /// gerer la victoire
        /// </summary>
        /// <param name="grille"></param>
        /// <param name="victoire"></param>
        /// <returns></returns>
        static bool Victoire(int[,] grille, bool victoire)
        {
            foreach (var tab in grille)
            {
                if (tab == 2048 && victoire == false)
                {
                    MessageBox.Show("Vous avez gagné !");
                    victoire = true;
                }
            }
            return victoire;
        }

        /// <summary>
        /// mouvements, victoire et sauvegarde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int[,] grilleMouvement = new int[4, 4]; //faire teableau vide
            memeTableau(grille, grilleMouvement); //garde la valeur de mon tableau ancienne dans tableau
            switch (e.KeyCode)
            {
                case Keys.Up:
                    score = AdditionHaut(grille, score);
                    break;

                case Keys.Down:
                    score = AdditionBas(grille, score);
                    break;

                case Keys.Left:
                    score = AdditionGauche(grille, score);
                    break;

                case Keys.Right:
                    score = AdditionDroite(grille, score);
                    break;

                default:
                    break;
            } //modifier le tableau

            if (!tableauEgal(grilleMouvement, grille)) //verifier si sont diferents
            {
                Zero(grille); //si sont diferents, rajouter une 0
            }
            Sauvegarder(grille, score, pseudo);//sauvegarde score et grille
            afficher(grille, score);//afichage grille
            victoire = Victoire(grille, victoire); //victoire

            if (Defaite(grille) == true)
            {
                MessageBox.Show("Vous avez perdu !" + " \n Votre score est " + score);
                this.Close();
            }
            else if ((e.KeyCode == Keys.Escape || e.KeyCode == Keys.Q)) //sortir avec le q ou esc si on veux
            {
                MessageBox.Show("Merci pour jouer");
                this.Close();
            }
        }

        /// <summary>
        /// verifie si 2 tableaux sont egales
        /// </summary>
        /// <param name="grilleMouvement"></param>
        /// <param name="grille"></param>
        /// <returns></returns>
        public static bool tableauEgal(int[,] grilleMouvement, int[,] grille)
        {
            bool res = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (grille[i, j] != grilleMouvement[i, j]) res = false;
                }
            }

            return res;
        }

        /// <summary>
        /// copie une tableau
        /// </summary>
        /// <param name="grille"></param>
        /// <param name="grilleMouvement"></param>
        public static void memeTableau(int[,] grille, int[,] grilleMouvement)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    grilleMouvement[i, j] = grille[i, j];
                }
            }
        }

        /// <summary>
        /// mouvement gauche
        /// </summary>
        /// <param name="grille"></param>
        public static void Gauche(int[,] grille)
        {
            for (int rang = 0; rang < grille.GetLength(0); rang++)
            {
                for (int j = 0; j < grille.GetLength(0) - 1; j++)
                {
                    if (grille[rang, j] == 0)
                    {
                        grille[rang, j] = grille[rang, j + 1];
                        grille[rang, j + 1] = 0;
                    }
                }
            }
        }
        /// <summary>
        /// mouvement droite
        /// </summary>
        /// <param name="grille"></param>
        public static void Droite(int[,] grille)
        {
            for (int rang = 0; rang < grille.GetLength(0); rang++)
            {
                for (int j = 3; j > 0; j--)
                {
                    if (grille[rang, j] == 0)
                    {
                        grille[rang, j] = grille[rang, j - 1];
                        grille[rang, j - 1] = 0;
                    }
                }
            }
        }
        /// <summary>
        /// mouvement vers le haut
        /// </summary>
        /// <param name="grille"></param>
        public static void Haut(int[,] grille)
        {
            for (int j = 0; j < grille.GetLength(0); j++)
            {
                for (int rang = 0; rang < 3; rang++)
                {
                    if (grille[rang, j] == 0)
                    {
                        grille[rang, j] = grille[rang + 1, j];
                        grille[rang + 1, j] = 0;
                    }
                }
            }
        }
        /// <summary>
        /// mouvement vers le bas
        /// </summary>
        /// <param name="grille"></param>
        public static void Bas(int[,] grille)
        {
            for (int j = 0; j < grille.GetLength(0); j++)
            {
                for (int rang = 3; rang > 0; rang--)
                {
                    if (grille[rang, j] == 0)
                    {
                        grille[rang, j] = grille[rang - 1, j];
                        grille[rang - 1, j] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// ajouter une 0 si il y a la place dans la grille
        /// </summary>
        /// <param name="grille"></param>
        public static void Zero(int[,] grille)
        {
            var zero = new List<(int k, int n)> { };

            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == 0)
                    {
                        zero.Add((i, j));
                    }
                }
            }

            if (zero.Count() != 0)
            {
                Random rd = new Random();
                int add = 0;
                int quatre = 0;
                add = rd.Next(0, zero.Count());
                quatre = rd.Next(0, 9);

                if (quatre == 1) grille[zero[add].Item1, zero[add].Item2] = 4;
                else grille[zero[add].Item1, zero[add].Item2] = 2;
            }
        }

        /// <summary>
        /// fusion gauche
        /// </summary>
        /// <param name="grille"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static int AdditionGauche(int[,] grille, int score)
        {
            Gauche(grille);
            for (int rang = 0; rang < grille.GetLength(0); rang++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grille[rang, j] == grille[rang, j + 1])
                    {
                        grille[rang, j] = grille[rang, j] * 2;
                        score += grille[rang, j + 1];
                        grille[rang, j + 1] = 0;
                    }
                }
            }
            Gauche(grille);
            return score;
        }

        /// <summary>
        /// fusion droite
        /// </summary>
        /// <param name="grille"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static int AdditionDroite(int[,] grille, int score)
        {
            Droite(grille);
            for (int rang = 0; rang < grille.GetLength(0); rang++)
            {
                for (int j = 3; j > 0; j--)
                {
                    if (grille[rang, j] == grille[rang, j - 1])
                    {
                        grille[rang, j] = grille[rang, j] * 2;
                        score += grille[rang, j - 1];
                        grille[rang, j - 1] = 0;
                    }
                }
            }
            Droite(grille);
            return score;
        }

        /// <summary>
        ///fusion haut 
        /// </summary>
        /// <param name="grille"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static int AdditionHaut(int[,] grille, int score)
        {
            Haut(grille);
            for (int j = 0; j < grille.GetLength(0); j++)
            {
                for (int rang = 0; rang < 3; rang++)
                {
                    if (grille[rang, j] == grille[rang + 1, j])
                    {
                        grille[rang, j] = grille[rang + 1, j] * 2;
                        score += grille[rang, j];
                        grille[rang + 1, j] = 0;
                    }
                }
            }
            Haut(grille);
            return score;
        }

        /// <summary>
        /// fusion bas
        /// </summary>
        /// <param name="grille"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public static int AdditionBas(int[,] grille, int score)
        {
            Bas(grille);
            for (int j = 0; j < grille.GetLength(0); j++)
            {
                for (int rang = 3; rang > 0; rang--)
                {
                    if (grille[rang, j] == grille[rang - 1, j])
                    {
                        grille[rang, j] = grille[rang - 1, j] * 2;
                        score += grille[rang, j];
                        grille[rang - 1, j] = 0;
                    }
                }
            }
            Bas(grille);
            return score;
        }

        /// <summary>
        /// gerer la defaite
        /// </summary>
        /// <param name="grille"></param>
        /// <returns></returns>
        public static bool Defaite(int[,] grille) // vérifie si la grille est complète et si il n'y a plus rien à assembler. 
        {
            bool finJeu = true; // initie la variable pour voir si la grille est pleine
            for (int i = 0; i < grille.GetLength(0); i++) // Parcourt tout le tableau
            {
                if ((siFin(grille[i, 0], grille[i, 1], grille[i, 2], grille[i, 3])) || siFin(grille[0, i], grille[1, i], grille[2, i], grille[3, i])) finJeu = false;
            }
            return finJeu;
        }


        /// <summary>
        /// function necesaire pour ma defaite
        /// </summary>
        /// <param name="nbr1"></param>
        /// <param name="nbr2"></param>
        /// <param name="nbr3"></param>
        /// <param name="nbr4"></param>
        /// <returns></returns>
        public static bool siFin(int nbr1, int nbr2, int nbr3, int nbr4)
        {
            bool res = false;
            if (((nbr1 == nbr2) || (nbr2 == nbr3) || (nbr3 == nbr4)) || (nbr1 == 0 || nbr2 == 0 || nbr3 == 0 || nbr4 == 0)) res = true;
            return res;
        }

        /// <summary>
        /// label QUIT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merci pour jouer");
            this.Close();
        }

        /// <summary>
        /// sauvegarde sur
        /// </summary>
        /// <param name="grille"></param>
        /// <param name="score"></param>
        /// <param name="Joueur"></param>

        public static void Sauvegarder(int[,] grille, int score, string Joueur)
        {
            // Nom du dossier et des fichiers
            string dossier = "2048";
            string sauvegarde = "sauvegarde.txt";

            // Chemin complet du dossier dans Mes documents
            string cheminDossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dossier);

            // Chemin complet du fichier dans le dossier
            string cheminSauvegarde = Path.Combine(cheminDossier, sauvegarde);

            try
            {
                Directory.CreateDirectory(cheminDossier);
                SauvegarderGrille(cheminSauvegarde, grille, score, Joueur);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }

        /// <summary>
        /// sauvegarde dans une txt de la grille, le score et le nom du joueur
        /// </summary>
        /// <param name="cheminSauvegarde"></param>
        /// <param name="grille"></param>
        /// <param name="score"></param>
        /// <param name="Joueur"></param>
        static void SauvegarderGrille(string cheminSauvegarde, int[,] grille, int score, string Joueur)
        {
            using (StreamWriter writer = new StreamWriter(cheminSauvegarde))
            {
                for (int i = 0; i < grille.GetLength(0); i++)
                {
                    for (int j = 0; j < grille.GetLength(1); j++)
                    {
                        writer.Write(grille[i, j]);
                        if (j < grille.GetLength(1) - 1)
                        {
                            writer.Write(" ");
                        }
                    }
                    writer.WriteLine();
                }
                writer.Write(score);
                writer.WriteLine();
                writer.Write(Joueur);
                writer.WriteLine();
            }
        }

        /// <summary>
        /// sauvegarade meilleurs scores
        /// </summary>
        /// <param name="sauvegardeMeilleursScores"></param>
        /// <param name="score"></param>
        /// <param name="Joueur"></param>
        static void SauvegarderMeilleursScores(string sauvegardeMeilleursScores, int score, string Joueur)
        {
            if (!File.Exists(sauvegardeMeilleursScores))
            {
                FaireTXT(sauvegardeMeilleursScores, score, Joueur);
            }
            else
            {
                ActualiserTXT(sauvegardeMeilleursScores, score, Joueur);
            }
        }

        /// <summary>
        /// faure un txt vide
        /// </summary>
        /// <param name="sauvegardeMeilleursScores"></param>
        /// <param name="score"></param>
        /// <param name="Joueur"></param>
        static void FaireTXT(string sauvegardeMeilleursScores, int score, string Joueur)
        {
            List<string> lignes = new List<string>();
            // Ajouter la première ligne avec le nouvel entier et la chaîne de texte
            lignes.Add($"{score} {Joueur}");
            // Remplir 10 lignes avec "0 XXX"
            using (StreamWriter writer = new StreamWriter(sauvegardeMeilleursScores))
            {
                for (int i = 0; i < 9; i++)
                {
                    lignes.Add("0 XXX");
                }
            }
            // Écrire les lignes dans le fichier
            File.WriteAllLines(sauvegardeMeilleursScores, lignes);
        }

        /// <summary>
        /// actualizer le txt avec les scores
        /// </summary>
        /// <param name="sauvegardeMeilleursScores"></param>
        /// <param name="score"></param>
        /// <param name="Joueur"></param>
        static void ActualiserTXT(string sauvegardeMeilleursScores, int score, string Joueur)
        {
            List<(int, string)> bestScores = new List<(int, string)>();
            string[] lignes = File.ReadAllLines(sauvegardeMeilleursScores);
            // Convertir les lignes en tuples (int, string)
            foreach (var ligne in lignes)
            {
                string[] scores = ligne.Split(' ');
                int bestScore = Convert.ToInt32(scores[0]);
                string joueurScore = scores[1];
                bestScores.Add((bestScore, joueurScore));
            }

            // Trier les tuples dans l'ordre décroissant en fonction du nombre entier
            bestScores = bestScores.OrderByDescending(best => best.Item1).ToList();

            // Vérifier si le nouvel entier est supérieur à la dernière valeur de la liste
            if (score > bestScores.Last().Item1)
            {
                // Remplacer la dernière ligne par la nouvelle valeur
                bestScores.RemoveAt(bestScores.Count - 1);
                bestScores.Add((score, Joueur));
                bestScores = bestScores.OrderByDescending(dato => dato.Item1).ToList();
            }
            // Écrire les lignes mises à jour dans le fichier (maximum 10 lignes)
            List<string> newLigne = bestScores.Select(dato => $"{dato.Item1} {dato.Item2}").ToList();
            File.WriteAllLines(sauvegardeMeilleursScores, newLigne.Take(10)); // Prendre seulement les 10 premières lignes
        }

        /// <summary>
        /// sauvegarde grille
        /// </summary>
        /// <param name="cheminSauvegarde"></param>
        /// <returns></returns>
        public static int[,] Continuer(string cheminSauvegarde)
        {
            int[,] tableauModifie = new int[4, 4];

            string[] lignes = File.ReadAllLines(cheminSauvegarde);

            for (int i = 0; i < 4; i++)
            {
                string[] valeurs = lignes[i].Split(' ');

                for (int j = 0; j < valeurs.Length; j++)
                {
                    if (int.TryParse(valeurs[j], out int valeur))
                    {
                        tableauModifie[i, j] = valeur;
                    }
                }
            }
            return tableauModifie;
        }

        /// <summary>
        /// sauvegarde score
        /// </summary>
        /// <param name="cheminSauvegarde"></param>
        /// <returns></returns>
        public static int ContinuerScore(string cheminSauvegarde)
        {
            int score = 0;
            string[] lignes = File.ReadAllLines(cheminSauvegarde);
            score = int.Parse(lignes[4]);
            return score;
        }

        /// <summary>
        /// sauvegarde nom joueur
        /// </summary>
        /// <param name="cheminSauvegarde"></param>
        /// <returns></returns>
        public static string ContinuerJoueur(string cheminSauvegarde)
        {
            string joueur = "";
            string[] lignes = File.ReadAllLines(cheminSauvegarde);
            joueur = string.Concat(joueur, lignes[5]);
            return joueur;
        }

    }
}
