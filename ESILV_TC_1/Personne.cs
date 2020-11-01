using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESILV_TC_1
{
    enum Sexe {NI, M, F };

    abstract class Personne
    {
        protected string nom;
        protected string prenom;
        protected string num;
        protected Sexe sexe;
        protected DateTime naissance;
        protected string adresse;
        protected Personne()
        {

        }
        protected Personne(string nom, string prenom, DateTime naissance, string adresse, Sexe sexe, string num)
        {
            this.nom = nom;
            this.prenom = prenom ;
            this.num = num;
            this.sexe = sexe;
            this.naissance = naissance;
            this.adresse = adresse;
        }
        protected Personne(string nom, string prenom, DateTime naissance, string adresse)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.naissance = naissance;
            this.adresse = adresse;
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        public string Num
        {
            get { return num; }
            set { num = value; }
        }
        public Sexe Sexe
        {
            get { return sexe; }
            set { sexe = value; }
        }
        public DateTime Naissance
        {
            get { return naissance; }
            set { naissance = value; }
        }
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
    }
}
