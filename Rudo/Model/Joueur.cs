using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rudo.Model
{
   public class Joueur
    {
        string nom ;
        //string prenom;

        public Joueur()
        {

        }
        public Joueur(string nom)
        {
            this.nom = nom;
        }
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value;
            }
        }

       

    }
}
