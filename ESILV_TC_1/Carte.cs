using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESILV_TC_1
{
    class Carte
    {
        private string valeur;
        private bool estFaceCachee;

        // à la construction, une carte est face cachée
        public Carte(string valeur)
        {
            this.valeur = valeur;
            this.estFaceCachee = true;
        }

        public string Valeur
        {
            get { return valeur; }
        }

        public bool EstFaceCachee
        {
            get { return estFaceCachee; }
        }


        public void Retourner()
        {
            estFaceCachee = !estFaceCachee;
        }
    }
}
