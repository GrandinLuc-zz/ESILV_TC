using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESILV_TC_1
{
    class Competition
    {
        private string nom;
        private string qualification;
        private int nbMatchs;
        private int nbJours;
        private string niveau;
        private int nbJoueurs;
        private DateTime dateCompetition;
        private List<Membre> compo = new List<Membre>();
        public static Competition competCourante = new Competition();
        public static List<Competition> lcompets = new List<Competition>();



        public Competition()
        {
        }
        public Competition(string nom, string qualification, int nbMatchs, int nbJours, string niveau, int nbJoueurs, DateTime dateCompetition)
        {
            this.dateCompetition = dateCompetition;
            this.nom = nom ?? throw new ArgumentNullException(nameof(nom));
            this.qualification = qualification ?? throw new ArgumentNullException(nameof(qualification));
            this.nbMatchs = nbMatchs;
            this.nbJours = nbJours;
            this.niveau = niveau ?? throw new ArgumentNullException(nameof(niveau));
            this.nbJoueurs = nbJoueurs;
            lcompets.Add(this);
        }

        public List<Membre> Compo
        {
            get { return compo; }
            set { compo = value;}
        }
        public DateTime DateCompetition
        {
            get { return dateCompetition; }
            set { dateCompetition = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Qualification
        {
            get { return qualification; }
            set { qualification = value; }
        }

        public int NbMatchs
        {
            get { return nbMatchs; }
            set { nbMatchs = value; }
        }

        public int NbJours
        {
            get { return nbJours; }
            set { nbJours = value; }
        }

        public string Niveau
        {
            get { return niveau; }
            set { niveau = value; }
        }

        public int NbJoueurs
        {
            get { return nbJoueurs; }
            set { nbJoueurs = value; }
        }

        public void AjouterJoueur(Membre membre)
        {
            compo.Add(membre);
        }

        public void RetirerJouer(Membre membre)
        {
            compo.Remove(membre);
        }



    }
}
