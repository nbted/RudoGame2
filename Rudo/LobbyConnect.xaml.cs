using Rudo.Model;
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

namespace Rudo
{
    /// <summary>
    /// Interaction logic for LobbyConnect.xaml
    /// </summary>
    public partial class LobbyConnect : Window
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public string text_to_send;
        private readonly BackgroundWorker backgroundWorker1;
        private readonly BackgroundWorker backgroundWorker2;
        public bool ready = false;


        private readonly BackgroundWorker backgroundWorker3;
        private readonly BackgroundWorker backgroundWorker4;

        public Gestion gestion { get; set; }
        public int count=0;
        public LobbyConnect()
        {
            InitializeComponent();
            this.startButton.IsEnabled = false;
            gestion = Gestion.Instance;
            this.DataContext = this;

            listJoueur.ItemsSource = gestion.joueurs;

            // initialisation du background
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker2 = new BackgroundWorker();
            backgroundWorker3 = new BackgroundWorker();
            backgroundWorker4 = new BackgroundWorker();

            //Subscribe to events:
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker2.DoWork += backgroundWorker2_DoWork;

            backgroundWorker3.DoWork += backgroundWorker3_DoWork;
            backgroundWorker4.DoWork += backgroundWorker4_DoWork;
        }
        private void readyBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            this.count++;
            if (this.count == 2)
            {
                this.startButton.IsEnabled = true;
                this.ready = true;
            }
        }


       private void readyBox_CheckedChanged2(object sender, RoutedEventArgs e)
        {
            this.count--;
            if (this.count < 2)
            {
                this.startButton.IsEnabled = false;
                this.ready = false;
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            /*
             *AwaleGameWindo awaleGameWindo = new AwaleGameWindo();
             App.Current.MainWindow = awaleGameWindo;
             awaleGameWindo.Show();
             this.Close();
             */

           backgroundWorker4.RunWorkerAsync();

          //  backgroundWorker3.WorkerSupportsCancellation = true;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void start_server(object sender, RoutedEventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 123);
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;

            // Start Receiving Data
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();
            // Enable Cancelling this Thread
            backgroundWorker2.WorkerSupportsCancellation = true;
            backgroundWorker4.WorkerSupportsCancellation = true;

        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {

            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 123);

            try
            {
                client.Connect(IP_End);
                if (client.Connected)
                {
                    this.receiveTextBox.AppendText("Connected to Server");
                    
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;

                    // Start Receiving Data
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker3.RunWorkerAsync();
                    // Enable Cancelling this Thread
                    backgroundWorker2.WorkerSupportsCancellation = true;
                    backgroundWorker4.WorkerSupportsCancellation = true;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }


        }

        // Receive Data
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                    this.listJoueur.Dispatcher.Invoke(new Action(() =>
                    {
                        Gestion.Instance.joueurs.Add(new Joueur(receive));
                    }));

                    
                    this.receiveTextBox.Dispatcher.Invoke(new Action(() => {
                        receiveTextBox.AppendText("You Joueur 2: " + receive + "\n");
                       // Gestion.Instance.joueurs.Add(new Joueur(receive));
                    }));
                    


                    receive = "";
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
        }

        // Send Data
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(text_to_send);
                this.listJoueur.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Gestion.Instance.joueurs.Add(new Joueur(text_to_send));
                }));

              //  MessageBox.Show(text_to_send);


                this.receiveTextBox.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => {
                    receiveTextBox.AppendText("Moi Joueur 1 :" + text_to_send + "\n");
                   // Gestion.Instance.joueurs.Add(new Joueur(text_to_send));
                }));
                

            }
            else
            {
                MessageBox.Show("Send failed!");
            }
            backgroundWorker2.CancelAsync();

        }

        //lancer le jeu ...Plateau
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

            while (client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                    
                    if (receive != "true")
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate {

                            AwaleGameWindo awaleGameWindo = new AwaleGameWindo();
                            App.Current.MainWindow = awaleGameWindo;
                            awaleGameWindo.Show();
                            this.Close();
                            //MessageBox.Show(this.receiveTextBox.ToString());

                        });
                    }
                                           
                    receive = "";
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
           /* if (client.Connected)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate {

                    AwaleGameWindo awaleGameWindo = new AwaleGameWindo();
                    App.Current.MainWindow = awaleGameWindo;
                    awaleGameWindo.Show();
                    this.Close();

                });

            }*/
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {

            if (client.Connected)
            {
                STW.WriteLine(this.ready);
                Application.Current.Dispatcher.Invoke((Action)delegate {

                    AwaleGameWindo awaleGameWindo = new AwaleGameWindo();
                    App.Current.MainWindow = awaleGameWindo;
                    awaleGameWindo.Show();
                    this.Close();
                    //MessageBox.Show(this.receiveTextBox.ToString());

                });
                
            }

            backgroundWorker4.CancelAsync();
        }

        private void joueur_Click(object sender, RoutedEventArgs e)
        {
            if (sendTextBox.Text != "")
            {
                text_to_send = sendTextBox.Text;
                backgroundWorker2.RunWorkerAsync();

            }
            sendTextBox.Text = "";
        }
    }
}
