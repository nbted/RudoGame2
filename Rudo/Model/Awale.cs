using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rudo.Model
{
    public class Awale : INotifyPropertyChanged
    {
        public ObservableCollection<int> cases_joueur1 { set; get; }
        public ObservableCollection<int> cases_joueur2 { set; get; }
        public ObservableCollection<Joueur> joueurs { set; get; }
        public int score_joueur1 { set; get; }
        public int score_joueur2 { set; get; }
        int tour_jeu;
        string style;
        bool gaveOver;

        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public ObservableCollection<int> Cases_joueur1
        {
            get
            {
                return cases_joueur1;
            }
            set
            {
                if (value != this.cases_joueur1)
                    cases_joueur1 = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<int> Cases_joueur2
        {
            get
            {
                return cases_joueur2;
            }
            set
            {
                if (value != this.cases_joueur2)
                    cases_joueur2 = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Joueur> Joueurs
        {
            get
            {
                return joueurs;
            }
            set
            {
                if (value != this.joueurs)
                    joueurs = value;
                NotifyPropertyChanged();
            }
        }

        public int Score_joueur1
        {
            get
            {
                return score_joueur1;
            }
            set
            {
                score_joueur1 = value;
                NotifyPropertyChanged();
            }
        }

        public int Score_joueur2
        {
            get
            {
                return score_joueur2;
            }
            set
            {
                score_joueur2 = value;
                NotifyPropertyChanged();
            }
        }

        public int Tour_jeu
        {
            get
            {
                return tour_jeu;
            }
            set
            {
                tour_jeu = value;
                NotifyPropertyChanged("Tour_jeu");
            }
        }

        public bool GaveOver
        {
            get
            {
                return gaveOver;
            }
            set
            {
                gaveOver = value;
                NotifyPropertyChanged("gaveOver");
            }
        }

        public string Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
                NotifyPropertyChanged("Style");
            }
        }
        public Awale()
        {
            this.Cases_joueur1 = new ObservableCollection<int>() { 4, 4, 4, 4, 4, 4 };
            this.Cases_joueur2 = new ObservableCollection<int>() { 4, 4, 4, 4, 4, 4 };
            this.Joueurs = new ObservableCollection<Joueur>(); 
            this.gaveOver = false;
        }

    }
}
