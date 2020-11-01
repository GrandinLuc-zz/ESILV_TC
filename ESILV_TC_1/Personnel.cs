using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESILV_TC_1
{
    class Personnel : Personne, ISalaire
    {
        static public List<Personnel> lperso = new List<Personnel>(); // On va ajouter chaque nouveau personnel instanciés à cette liste qui sera la liste des membres du club
        string poste;

        DateTime ISalaire.dateEntree { get; set; }
        double ISalaire.salaire { get; set; }
        string ISalaire.infoBancaires { get; set; }

        public Personnel()// Pas d'ajout à la liste des membres pour cette méthode d'instance car on aura besoin d'un membre temporaire à utiliser dans certaines situations sans l'ajouter à la liste des membres
        {

        }
        public Personnel( string nom, string prenom, DateTime naissance, string adresse, string poste) : base(nom, prenom, naissance, adresse)
        {
            this.poste = poste;           
            lperso.Add(this);
        }

        public string Poste
        {
            get { return poste; }
            set { this.poste = value; }
        }
    }
}
