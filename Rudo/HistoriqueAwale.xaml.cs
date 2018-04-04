using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using Rudo.Controller;

namespace Rudo
{
    /// <summary>
    /// Interaction logic for HistoriqueAwale.xaml
    /// </summary>
    public partial class HistoriqueAwale : Window
    {
       
        private SQLiteDataAdapter DB;

        Database databaseObject;


        public HistoriqueAwale()
        {
            InitializeComponent();
             databaseObject = new Database();
            
        }

        private void historique_Loaded(object sender, EventArgs e)
        {
            setConnection();
            string query = "SELECT * FROM historique";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            
            using (DB = new SQLiteDataAdapter(myCommand))
            {
                DataTable dt = new DataTable();
                DB.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
            }
            databaseObject.CloseConnection();
        }

        private void setConnection()
        {
            Database databaseObject = new Database();
            databaseObject.OpenConnection();

        }

        private void accueil_Click(object sender, RoutedEventArgs e)
        {
            Aceuil aceuil = new Aceuil();
            App.Current.MainWindow = aceuil;
            this.Close();
            aceuil.Show();
        }
    }
}

