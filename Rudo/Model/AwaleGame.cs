using Rudo.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rudo.Model
{

    public class AwaleGame : INotifyPropertyChanged
    {
        public Awale awale { get; set; }
        private static AwaleGame instance = null;
        public bool enable_joueur1 = true;
        public bool enable_joueur2 = false;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static AwaleGame Instance
        {
            get
            {
                if (instance == null)
                    instance = new AwaleGame();
                return instance;
            }

        }

        private AwaleGame()
        {
            awale = new Awale();
        }

        public bool Enable_joueur1
        {
            get
            {
                return enable_joueur1;
            }
            set
            {
                enable_joueur1 = value;
                NotifyPropertyChanged();
            }
        }

        public bool Enable_joueur2
        {
            get
            {
                return enable_joueur2;
            }
            set
            {
                enable_joueur2 = value;
                NotifyPropertyChanged();
            }
        }

        public void joueur1_joue(int case_choisie)
        {
            int case_gene = case_choisie;
            int nb_graine = awale.Cases_joueur1[case_choisie];
            int case_bis = 11; // Servira pour la règle : enlève tt enlève rien
            int enleve = 0;

            awale.Cases_joueur1[case_choisie] = 0;

            //Dépose les graines
            while (nb_graine != 0)
            {
                case_gene++;
                if (case_gene == 12) case_gene = 0;
                if (case_gene == case_choisie) case_gene++;
                if (case_gene > 5)
                    awale.Cases_joueur2[case_gene - 6]++;
                else
                    awale.Cases_joueur1[case_gene]++;
                nb_graine--;
                //System.Threading.Thread.Sleep(1000);
            }
            // Vérifie la règle : enlève tt enlève rien
            if ((case_gene > 5) && ((awale.Cases_joueur2[case_gene - 6] == 2) || (awale.Cases_joueur2[case_gene - 6] == 3)))
            {
                while ((case_bis != case_gene) && (enleve == 0))
                {
                    if (awale.Cases_joueur2[case_bis - 6] != 0) enleve = 1;
                    case_bis--;
                }
                case_bis--;
                while ((case_bis > 5) && (enleve == 0))
                {
                    if ((awale.Cases_joueur2[case_bis - 6] != 2) && (awale.Cases_joueur2[case_bis - 6] != 3)) enleve = 1;
                    case_bis--;
                }
                // si enleve==1, alors on peut enlever les graines gagnées
                if (enleve == 1)
                    while ((case_gene > 5) && ((awale.Cases_joueur2[case_gene - 6] == 2) || (awale.Cases_joueur2[case_gene - 6] == 3)))
                    {
                        awale.Score_joueur1 += awale.Cases_joueur2[case_gene - 6];
                        awale.Cases_joueur2[case_gene - 6] = 0;
                        case_gene--;
                    }
            }
            awale.Tour_jeu = 2;
            this.Enable_joueur1 = false;
            this.Enable_joueur2 = true;

        }

        // Le joueur2 joue un coup entre 0 et 5
        // Déplace les pions, change le score
        //**************************************
        public void joueur2_joue(int case_choisie)
        //**************************************
        {
            int case_gene = case_choisie;
            int nb_graine = awale.Cases_joueur2[case_choisie];
            int case_bis = 11; // Servira pour la règle : enlève tt enlève rien
            int enleve = 0;


            awale.Cases_joueur2[case_choisie] = 0;

            //Dépose les graines
            while (nb_graine != 0)
            {
                case_gene++;
                if (case_gene == 12) case_gene = 0;
                if (case_gene == case_choisie) case_gene++;
                if (case_gene > 5)
                    awale.Cases_joueur1[case_gene - 6]++;
                else
                    awale.Cases_joueur2[case_gene]++;
               // System.Threading.Thread.Sleep(500);
                nb_graine--;
               // System.Threading.Thread.Sleep(1000);
            }

            //Enlève celles gagnées et augmente le score
            // Vérifie la règle : enlève tt enlève rien
            if ((case_gene > 5) && ((awale.Cases_joueur1[case_gene - 6] == 2) || (awale.Cases_joueur1[case_gene - 6] == 3)))
            {
                while ((case_bis != case_gene) && (enleve == 0))
                {
                    if (awale.Cases_joueur1[case_bis - 6] != 0) enleve = 1;
                    case_bis--;
                }
                case_bis--;
                while ((case_bis > 5) && (enleve == 0))
                {
                    if ((awale.Cases_joueur1[case_bis - 6] != 2) && (awale.Cases_joueur1[case_bis - 6] != 3)) enleve = 1;
                    case_bis--;
                }
                // si enleve==1, alors on peut enlever les graines gagnèes
                if (enleve == 1)
                    while ((case_gene > 5) && ((awale.Cases_joueur1[case_gene - 6] == 2) || (awale.Cases_joueur1[case_gene - 6] == 3)))
                    {
                        awale.Score_joueur2 += awale.Cases_joueur1[case_gene - 6];
                        awale.Cases_joueur1[case_gene - 6] = 0;
                        case_gene--;
                    }
            }
            awale.Tour_jeu = 1;
            this.Enable_joueur1 = true;
            this.Enable_joueur2 = false;
        }

        //***********************************************************************
        //*************************************************************************

        public void demande_joueur1(int coup)
        //***************************
        {
            int i = 0;
            // Vérifie si le jeu n'est pas fini
            if (awale.Cases_joueur2[0] + awale.Cases_joueur2[1] + awale.Cases_joueur2[2] + awale.Cases_joueur2[3] + awale.Cases_joueur2[4] + awale.Cases_joueur2[5] == 0)
            {
                while ((i + awale.Cases_joueur1[i] < 6) && (i < 6))
                {
                    i++; // Vérifie si on peut donner des graines
                    if (i == 6)
                    {
                        awale.GaveOver = true;
                        return; // Jeu fini
                    }
                }
            }



            // Joue une case non vide
            if (awale.Cases_joueur1[coup - 1] == 0)
            {
                MessageBox.Show("Hello, il faut jouer une case non vide", "Attention");
                
            }

            // Vérifie si l'adversaire n'a pas de graine
            if (awale.Cases_joueur2[0] + awale.Cases_joueur2[1] + awale.Cases_joueur2[2] + awale.Cases_joueur2[3] + awale.Cases_joueur2[4] + awale.Cases_joueur2[5] == 0)
                if (coup + awale.Cases_joueur1[coup - 1] < 7)
                {
                    MessageBox.Show("Il faut donner des graines ! (radin) :");

                }
            joueur1_joue(coup - 1);
        }

        // Demande au joueur2 quel coup il veut jouer et le joue
        //************************
        public void demande_joueur2(int coup)
        //************************
        {
            int i = 0;

            // Vérifie si le jeu n'est pas fini
            if (awale.Cases_joueur1[0] + awale.Cases_joueur1[1] + awale.Cases_joueur1[2] + awale.Cases_joueur1[3] + awale.Cases_joueur1[4] + awale.Cases_joueur1[5] == 0)
            {
                while ((i + awale.Cases_joueur2[i] < 6) && (i < 6))
                {
                    i++; // Vérifie si on peut donner des graines
                    if (i == 6)
                    {
                        awale.GaveOver = true;
                        return; // Jeu fini
                    }
                }
            }




            // Joue une case non vide
            if (awale.cases_joueur2[coup - 1] == 0)
            {
                MessageBox.Show("Il faut jouer une case non vide : ");

            }

            // Vérifie si l'adversaire n'a pas de graine
            if (awale.Cases_joueur1[0] + awale.Cases_joueur1[1] + awale.Cases_joueur1[2] + awale.Cases_joueur1[3] + awale.Cases_joueur1[4] + awale.Cases_joueur1[5] == 0)
                if (coup - 1 + awale.Cases_joueur2[coup - 1] < 6)
                {
                    MessageBox.Show("Il faut donner des graines ! (radin) :");

                }

            joueur2_joue(coup - 1);
        }

        // Affecte les dernieres graines quand le jeu est fini
        //  *************************
        public void terminer_jeu()
        //*************************
        {
            int i;
            awale.Score_joueur1 += awale.Cases_joueur1[0] + awale.Cases_joueur1[1] + awale.Cases_joueur1[2] + awale.Cases_joueur1[3] + awale.Cases_joueur1[4] + awale.Cases_joueur1[5];
            awale.Score_joueur2 += awale.Cases_joueur2[0] + awale.Cases_joueur2[1] + awale.Cases_joueur2[2] + awale.Cases_joueur2[3] + awale.Cases_joueur2[4] + awale.Cases_joueur2[5];
            for (i = 0; i < 6; i++)
            {
                awale.Cases_joueur1[i] = 0;
                awale.Cases_joueur2[i] = 0;
            }
        }


        

        // Cherche le meilleur coup du joueur2 de facon recursive
        // Renvoie la case donnant le meilleur coup et le gain de score
        //*******************************************************
        public Case_retour meilleure_case_joueur2(Awale k, int nbre_recursif)
        //*******************************************************
        {
            int i;
            Case_retour sortie = new Case_retour(0, 0);
            List<Awale> awa = new List<Awale>();
            int case_retenue = -1;
            int gain_retenu = -36;
            int gain_actuel;
           

            List<int> donne = new List<int> { 0, 0, 0, 0, 0, 0 };
            
            if (awale.Cases_joueur1[0] + awale.Cases_joueur1[1] + awale.Cases_joueur1[2] + awale.Cases_joueur1[3] + awale.Cases_joueur1[4] + awale.Cases_joueur1[5] == 0)
            {
                for (i = 0; i < 6; i++)
                    if (i + awale.Cases_joueur2[i] < 6)
                        donne[i] = 1;
                if (donne[0] + donne[1] + donne[2] + donne[3] + donne[4] + donne[5] == 6) // Jeu fini
                {
                    sortie.Gain_score = awale.Score_joueur1 - awale.Score_joueur2;
                    terminer_jeu();
                    sortie.Case_meilleure = -1;
                    sortie.Gain_score += awale.Score_joueur2 - awale.Score_joueur1;
                    return sortie;
                }
            }

            for (i = 0; i < 6; i++)
                if ((awale.Cases_joueur2[i] != 0) && (donne[i] == 0))
                {
                    awa[i] = awale;
                    

                    joueur2_joue(i);
                    if (nbre_recursif == 0)
                        gain_actuel = awale.Score_joueur1 - awale.Score_joueur2 + awa[i].Score_joueur2 - awa[i].Score_joueur1;
                    else
                    {
                        sortie = meilleure_case_joueur1(awa[i], nbre_recursif);
                        gain_actuel = awale.Score_joueur1 - awale.Score_joueur2 + awa[i].Score_joueur2 - awa[i].Score_joueur1 - sortie.Gain_score;
                    }
                    if (gain_actuel > gain_retenu)
                    {
                        gain_retenu = gain_actuel;
                        case_retenue = i;
                    }
                }

            sortie.case_meilleure = case_retenue;
            sortie.gain_score = gain_retenu;

            return sortie;
        }


        // Cherche le meilleur coup du joueur de facon recursive
        // Renvoie la case donnant le meilleur coup et le gain de score
        //**********************************************************
        public Case_retour meilleure_case_joueur1(Awale a, int nbre_recursif)
        //**********************************************************
        {
            int i;
            Case_retour sortie = new Case_retour(0, 0);
            List<Awale> awa = new List<Awale>();
            int case_retenue = -1;
            int gain_retenu = -36;
            int gain_actuel;
           

            List<int> donne = new List<int> { 0, 0, 0, 0, 0, 0 };
            // Vérifie si l'adversaire est sans graines et marque les cases qui ne donnent pas
            if (awale.Cases_joueur2[0] + awale.Cases_joueur2[1] + awale.Cases_joueur2[2] + awale.Cases_joueur2[3] + awale.Cases_joueur2[4] + awale.Cases_joueur2[5] == 0)
            {
                for (i = 0; i < 6; i++)
                    if (i + awale.Cases_joueur1[i] < 6)
                        donne[i] = 1;
                if (donne[0] + donne[1] + donne[2] + donne[3] + donne[4] + donne[5] == 6) // Jeu fini
                {
                    sortie.gain_score = awale.Score_joueur2 - awale.Score_joueur1;
                    terminer_jeu();
                    sortie.case_meilleure = -1;
                    sortie.gain_score += awale.Score_joueur1 - awale.Score_joueur2;
                    return sortie;
                }
            }

            for (i = 0; i < 6; i++)
                if ((awale.Cases_joueur1[i] != 0) && (donne[i] == 0))
                {
                    awa[i] = awale;
                    //joueur1_joue(&awa[i], i);

                    joueur1_joue(i);
                    if (nbre_recursif == 0)
                    {
                        gain_actuel = awale.score_joueur2 - awale.score_joueur1 + awa[i].score_joueur1 - awa[i].score_joueur2;
                    }
                    else
                    {
                        sortie = meilleure_case_joueur2(awa[i], nbre_recursif - 1);
                        gain_actuel = awale.Score_joueur2 - awale.Score_joueur1 + awa[i].Score_joueur1 - awa[i].Score_joueur2 - sortie.Gain_score;
                    }
                    if (gain_actuel > gain_retenu)
                    {
                        gain_retenu = gain_actuel;
                        case_retenue = i;
                    }
                }

            sortie.case_meilleure = case_retenue;
            sortie.gain_score = gain_retenu;

            return sortie;
        }

        // Affiche le gagnant pour jeu 1 joueur
        //************************************
        public void afficher_gagnant_2joueurs()
        //************************************
        {
            Database  databaseObject = new Database();
            // Console.ReadKey();
             string query2 = "CREATE TABLE IF NOT EXISTS historique(joueur1 text , joueur2 text , scoreFinal text)";
             string scoreF = awale.Score_joueur1 + " / " + awale.Score_joueur2 ;
             string query = "INSERT INTO historique('joueur1' , 'joueur2', 'scoreFinal') VALUES(@joueur1, @joueur2,@scoreFinal)";

             SQLiteCommand myCommand2 = new SQLiteCommand(query2, databaseObject.myConnection);
             SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
             databaseObject.OpenConnection();

             myCommand2.ExecuteNonQuery();

             myCommand.Parameters.AddWithValue("@joueur1", awale.Joueurs[0].Nom);
             myCommand.Parameters.AddWithValue("@joueur2", awale.Joueurs[1].Nom);
             myCommand.Parameters.AddWithValue("@scoreFinal", scoreF);

             var result = myCommand.ExecuteNonQuery();

             databaseObject.CloseConnection();
             

            GameOverWindo gameOver = new GameOverWindo();

            if (awale.Score_joueur1 > awale.Score_joueur2)
                gameOver.gameOverLabel.Content = "Le gagnant est le "+ awale.Joueurs[0].Nom + "!\n Félicitations.\n\n";
            
            else
                if (awale.Score_joueur1 < awale.Score_joueur2)
                gameOver.gameOverLabel.Content = "Le gagnant est "+ awale.Joueurs[1].Nom + " !\n Félicitations.\n\n";
            
            else
                gameOver.gameOverLabel.Content = "Match nul !\n Pas mal du tout.\n\n";
               
            App.Current.MainWindow = gameOver;
            
            gameOver.Show();
           
        }



        void lance_jeu_2joueurs(int coup)
        //*******************************
        {
            //int i;

            // afficher(a);  //binding score et case
            while (awale.GaveOver == false)
            {
                demande_joueur1(coup);
                //afficher(*a);
                //test_jeu_fini(a);
                if (awale.GaveOver == false)
                {
                    demande_joueur2(coup);
                    //afficher(*a);
                    //test_jeu_fini(a);
                }
            }
            terminer_jeu();
            afficher_gagnant_2joueurs();

        }


    }
}
