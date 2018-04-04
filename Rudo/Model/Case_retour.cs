using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rudo.Model
{
   public class Case_retour : INotifyPropertyChanged
    {
        public int case_meilleure { get; set; }
        public int gain_score { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public int Case_meilleure

        {
            get
            {
                return case_meilleure;
            }
            set
            {
                case_meilleure = value;
                NotifyPropertyChanged();
            }
        }

        public int Gain_score

        {
            get
            {
                return gain_score;
            }
            set
            {
                gain_score = value;
                NotifyPropertyChanged();
            }
        }
        public Case_retour(int case_meilleure,int gain_score)
        {
            this.case_meilleure = case_meilleure;
            this.gain_score = gain_score;
        }
    }
}
