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
    /// Interaction logic for GameOverWindo.xaml
    /// </summary>
    public partial class GameOverWindo : Window
    {
        public GameOverWindo()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void historique_Click(object sender, RoutedEventArgs e)
        {
            HistoriqueAwale historique = new HistoriqueAwale();
            App.Current.MainWindow = historique;
            historique.Show();
        }

        private void playAgain_Click(object sender, RoutedEventArgs e)
        {
            AwaleGameWindo awaleGameWindo = new AwaleGameWindo();
            App.Current.MainWindow = awaleGameWindo;
            awaleGameWindo.Show();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
