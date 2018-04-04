using Rudo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rudo
{
    /// <summary>
    /// Interaction logic for LobbyLocal.xaml
    /// </summary>
    public partial class LobbyLocal : Window
    {
        AwaleGame awaleGame = AwaleGame.Instance;
        public LobbyLocal()
        {
            InitializeComponent();
            this.DataContext = awaleGame;
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(this.pseudo1.Text);
            this.awaleGame.awale.Joueurs.Add(new Joueur(this.pseudo1.Text));
            this.awaleGame.awale.Joueurs.Add(new Joueur(this.pseudo2.Text));
            
             AwaleGameWindo awaleGameWindo = new AwaleGameWindo();
            
            App.Current.MainWindow = awaleGameWindo;
            this.Close();
            awaleGameWindo.Show();
            
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            Aceuil aceuil = new Aceuil();
            App.Current.MainWindow = aceuil;
            this.Close();
            aceuil.Show();
        }
    }
}
