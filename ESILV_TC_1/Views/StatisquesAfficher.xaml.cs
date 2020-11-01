using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ESILV_TC_1.Views
{
    /// <summary>
    /// Logique d'interaction pour StatisquesAfficher.xaml
    /// </summary>
    public partial class StatisquesAfficher : UserControl
    {
        public StatisquesAfficher()
        {
            InitializeComponent();
            MettreLesChiffresDansLesTextBox();
        }
        /// <summary>
        /// Tout est dans le nom
        /// </summary>
        public void MettreLesChiffresDansLesTextBox()
        {
            int a = 0;
            int b = 0;
            double moy=0;
            for(int i = 0; i< ESILV_TC_1.Competition.lcompets.Count;i++)
            {
                if(ESILV_TC_1.Competition.lcompets[i].DateCompetition < DateTime.Now)
                {
                    a++;
                }
                else
                {
                    b++;
                }
                moy += ESILV_TC_1.Competition.lcompets[i].NbJoueurs;
            }
            Compet_Real.Text = a.ToString();
            Compet_Restantes.Text = b.ToString();
            moy = moy / ESILV_TC_1.Competition.lcompets.Count;
            string arondimoy = "";
            if (moy.ToString().Length > 4)
            {
                arondimoy= moy.ToString()[0].ToString()+ moy.ToString()[1].ToString()+ moy.ToString()[2].ToString()+ moy.ToString()[3].ToString()+moy.ToString()[4].ToString();
            }
            Moyenne_Joueur_Par_Compet.Text = arondimoy;

            Nb_Matchs_Gagnes.Text = "0";

            Nb_Matchs_Perdus.Text = "0";





        }





    }
}
