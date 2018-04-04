using Rudo.Model;
using System.Windows;

namespace Rudo
{
    /// <summary>
    /// Interaction logic for AwaleGameWindo.xaml
    /// </summary>
    public partial class AwaleGameWindo : Window
    {
        AwaleGame awaleGame = AwaleGame.Instance;
        
        public Gestion gestion ;
       
        public AwaleGameWindo()
        {

            InitializeComponent();
             gestion = Gestion.Instance;

            //awaleGame = AwaleGame.Instance;
            this.DataContext = awaleGame;
        }


        private void e25_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur2(6);
             
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();   
             
            }

        }

        private void e24_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur2(5);
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }

        private void e23_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur2(4);
            }

            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }

        private void e22_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur2(3);
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }

        private void e21_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur2(2);
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }

        private void e20_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur2(1);
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }

        private void e10_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur1(1);
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }

        private void e11_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur1(2);
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }

        private void e12_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur1(3);
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }

        private void e13_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur1(4);
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }

        private void e14_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur1(5);
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }

        private void e15_Click(object sender, RoutedEventArgs e)
        {
            if (AwaleGame.Instance.awale.GaveOver == false)
            {
                AwaleGame.Instance.demande_joueur1(6);
            }
            else
            {
                AwaleGame.Instance.terminer_jeu();
                AwaleGame.Instance.afficher_gagnant_2joueurs();
            }
        }
    }
}
