using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
using System.Windows.Threading;
using Rudo.Controller;
using Rudo.Model;
namespace Rudo
{
    /// <summary>
    /// Interaction logic for Aceuil.xaml
    /// </summary>
    public partial class Aceuil : Window
    {
        
        public Aceuil()
        {
                InitializeComponent();
               this.DataContext = this;
        }

        private void host_game(object sender, RoutedEventArgs e)
        {
            LobbyConnect lobbyConnect = new LobbyConnect();
            App.Current.MainWindow = lobbyConnect;
            lobbyConnect.Show();

        }

        private void local_game(object sender, RoutedEventArgs e)
        {
            LobbyLocal lobbyLocal = new LobbyLocal();
            App.Current.MainWindow = lobbyLocal;
            this.Close();
            lobbyLocal.Show();

        }
   
      
        private void historique_view(object sender, RoutedEventArgs e)
        {
            HistoriqueAwale historique = new HistoriqueAwale();
            App.Current.MainWindow = historique;
            this.Close();
            historique.Show();
        }

        
    }
}
