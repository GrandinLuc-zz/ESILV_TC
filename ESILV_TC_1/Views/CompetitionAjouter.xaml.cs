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
    /// Logique d'interaction pour CompetitionAjouter.xaml
    /// </summary>
    public partial class CompetitionAjouter : UserControl
    {
        public CompetitionAjouter()
        {
            InitializeComponent();
        }
        private void Valider_Creation_Button_Click(object sender, RoutedEventArgs e)
        {
            int[] date = new int[3];
            try
            {
                date[0] = Convert.ToInt32((Ajouter_DateCompet .Text).Split('/')[0]);
                date[1] = Convert.ToInt32((Ajouter_DateCompet.Text).Split('/')[1]);
                date[2] = Convert.ToInt32((Ajouter_DateCompet.Text).Split('/')[2]);
            }
            catch
            {
                MessageBox.Show("Le format de la date doit être JJ/MM/AAAA");
            }

            try
            {
               new ESILV_TC_1.Competition(Ajouter_Nom.Text, Ajouter_Qualification.Text, Convert.ToInt32(Ajouter_NbMatchs.Text), Convert.ToInt32(Ajouter_NbJours.Text), Ajouter_Niveau.Text, Convert.ToInt32(Ajouter_NbJoueurs.Text),new DateTime(date[2],date[1],date[0]));
               Ajouter_NbJoueurs.Text = Ajouter_NbJours.Text = Ajouter_Nom.Text = Ajouter_Qualification.Text = Ajouter_Niveau.Text = Ajouter_NbMatchs.Text = "";
               MessageBox.Show("Création réussie");
            }
            catch
            {
                MessageBox.Show("Problème dans la création de la compétition");
            }
        }

    }
}
