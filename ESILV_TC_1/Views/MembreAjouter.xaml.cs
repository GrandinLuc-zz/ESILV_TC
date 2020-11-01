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
    /// Logique d'interaction pour MembreAjouter.xaml
    /// </summary>
    public partial class MembreAjouter : UserControl
    {
        public MembreAjouter()
        {
            InitializeComponent();
        }

        private void Valider_Inscription_Button_Click(object sender, RoutedEventArgs e)
        {
            int[] date = new int[3];
            try
            {
                date[0] = Convert.ToInt32((Ajouter_DateN.Text).Split('/')[0]);
                date[1] = Convert.ToInt32((Ajouter_DateN.Text).Split('/')[1]);
                date[2] = Convert.ToInt32((Ajouter_DateN.Text).Split('/')[2]);
            }
            catch
            {
                MessageBox.Show("Le format de la date doit être JJ/MM/AAAA");
            }
            if(date[0] != 0)
            {
                new ESILV_TC_1.Membre(Ajouter_Nom.Text, Ajouter_Prenom.Text, new DateTime(date[2], date[1], date[0]), Ajouter_Adresse.Text);
                Ajouter_Adresse.Text = Ajouter_DateN.Text = Ajouter_Nom.Text = Ajouter_Prenom.Text = "";
                MessageBox.Show("Inscription réussie");
            }
        }
    }
}
