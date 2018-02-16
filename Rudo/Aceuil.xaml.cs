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
    /// Interaction logic for Aceuil.xaml
    /// </summary>
    public partial class Aceuil : Window
    {
        public Aceuil()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void local_game(object sender, RoutedEventArgs e)
        {
            AwaleGameWindo awaleGameWindo = new AwaleGameWindo();
            App.Current.MainWindow =  awaleGameWindo;
            awaleGameWindo.Show();

        }
    }
}
