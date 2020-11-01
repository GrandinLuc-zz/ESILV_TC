using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESILV_TC_1
{
    class Membre : Personne
    {
        bool enRegle;
        string classement;
        public static List<Membre> lmembre = new List<Membre>(); // On va ajouter chaque nouveau membre instanciés à cette liste qui sera la liste des membres du club




        public Membre() // Pas d'ajout à la liste des membres pour cette méthode d'instance car on aura besoin d'un membre temporaire à utiliser dans certaines situations sans l'ajouter à la liste des membres
        {
           
        }
        public Membre(string nom, string prenom, DateTime naissance, string adresse,  Sexe sexe, string num, bool enRegle) : base(nom, prenom, naissance, adresse, sexe, num)
        {
            this.enRegle = enRegle;
            this.classement = "NC";
            lmembre.Add(this);
        }
        public Membre(string nom, string prenom, DateTime naissance, string adresse) : base(nom,prenom,naissance,adresse)
        {
            this.sexe = Sexe.NI;
            this.enRegle = false;
            this.classement = "NC";
            lmembre.Add(this);
        }
        public bool EnRegle
        {
            get { return enRegle; }
            set { enRegle = value; }
        }
        
        public string Classement
        {
            get { return classement; }
            set { this.classement = value; }
        }
        public void SupprimerMembre()
        {
            for(int i=0; i<lmembre.Count;i++)
            {
                if(lmembre[i] == this)
                {
                    lmembre.Remove(this);
                    break;
                }
            }
        }

        public delegate List<Membre> DelegateTri(List<Membre> membres);

        public Comparison<Membre> MembreComparison = (l1, l2) =>
        {
            return l1.Nom.CompareTo(l2.Nom);

        };
        public void Trier(List<Membre> listeMembres)
        {
            listeMembres.Sort(MembreComparison);
        }
    }
}
