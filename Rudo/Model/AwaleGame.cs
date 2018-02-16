using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rudo.Model
{
    public class AwaleGame : INotifyPropertyChanged
    {
       ObservableCollection<int> cases_joueur1;
        ObservableCollection<int> cases_joueur2;
        int score_joueur1;
        int score_joueur2;
        int tour_jeu;
        string style;
        bool gaveOver;

        public AwaleGame() {
            cases_joueur1 = new ObservableCollection<int>() { 4, 4, 4, 4, 4, 4 };
            cases_joueur2 = new ObservableCollection<int>() { 4, 4, 4, 4, 4, 4 };
        }

        public ObservableCollection<int> Cases_joueur1
        {
            get
            {
                return cases_joueur1;
            }
            set
            {
                cases_joueur1 = value;
                OnPropertyChanged("Cases_joueur1");
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
                cases_joueur2 = value;
                OnPropertyChanged("Cases_joueur2");
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
                OnPropertyChanged("Score_joueur1");
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
                OnPropertyChanged("Score_joueur2");
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
                OnPropertyChanged("Tour_jeu");
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
                OnPropertyChanged("gaveOver");
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
                OnPropertyChanged("Style");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public void jouer(AwaleGame a, int case_choisie)
        {
            int case_gene = case_choisie;
            int nb_graine = a.Cases_joueur1[case_choisie];
            int case_bis = 11; // Servira pour la règle : enlève tt enlève rien
            int enleve = 0;

            a.Cases_joueur1[case_choisie] = 0;

            //Dépose les graines
            while (nb_graine != 0)
            {
                case_gene++;
                if (case_gene == 12) case_gene = 0;
                if (case_gene == case_choisie) case_gene++;
                if (case_gene > 5)
                    a.Cases_joueur2[case_gene - 6]++;
                else
                    a.Cases_joueur1[case_gene]++;
                nb_graine--;
            }
            // Vérifie la règle : enlève tt enlève rien
	if ((case_gene>5)&&((a.Cases_joueur2[case_gene-6]==2)||(a.Cases_joueur2[case_gene-6]==3)))
	{
		while ((case_bis!=case_gene)&&(enleve==0))
		{
			if (a.Cases_joueur2[case_bis-6]!=0) enleve=1;
			case_bis--;
		}
		case_bis--;
		while ((case_bis>5)&&(enleve==0))
		{
			if ((a.Cases_joueur2[case_bis-6]!=2)&&(a.Cases_joueur2[case_bis-6]!=3)) enleve=1;
			case_bis--;
		}
		// si enleve==1, alors on peut enlever les graines gagnées
		if (enleve==1)
			while ((case_gene>5)&&((a.Cases_joueur2[case_gene-6]==2)||(a.Cases_joueur2[case_gene-6]==3)))
			{
				a.score_joueur1+=a.cases_joueur2[case_gene-6];
				a.cases_joueur2[case_gene-6]=0;
				case_gene--;
			}
	}	
	a.tour_jeu=2;

        }
    }
}
