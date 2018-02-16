using Rudo.Controller;
using Rudo.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Rudo
{
    /// <summary>
    /// Interaction logic for ellipseControl.xaml
    /// </summary>
    public partial class ellipseControl : UserControl , INotifyPropertyChanged
    {
        public static DependencyProperty TextInsideEllipse = 
            DependencyProperty.Register("EllipseText", typeof(int), typeof(ellipseControl),new PropertyMetadata(TextInsideEllipseChanged));

        public event PropertyChangedEventHandler PropertyChanged;

        AwaleGame a;
        public int EllipseText
        {
            get
            {
                return (int)GetValue(TextInsideEllipse);
            }
            set
            {
                SetValue(TextInsideEllipse, value);
                OnPropertyChanged("EllipseText");
                
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

       

        private static void TextInsideEllipseChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            ellipseControl control = d as ellipseControl;
            if (control != null)
            {
                if (control.PropertyChanged != null)
                {
                    control.PropertyChanged(control, new PropertyChangedEventArgs("EllipseText"));
                }
            }
        }
        public ellipseControl()
        {
            a = new AwaleGame();
            this.DataContext = this;
            InitializeComponent();
        }
        private void beginAparty(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("lolterran", "tedddy" + this.EllipseText);
            //this.EllipseText = 10;
            //int b = a.Cases_joueur1.IndexOf()

           a.jouer(AwaleController.Instance.awaleGameInstance,2);


            // image on main window
            // .Source = new BitmapImage(new Uri("pack://application:,,,/" + Constants.RACESPATH + "T.png"));
        }
    }
}
