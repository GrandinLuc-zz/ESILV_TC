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
    /// Logique d'interaction pour AutreMemory.xaml
    /// </summary>
    public partial class AutreMemory : UserControl
    {
        private List<String> valeursCartes;
        private CarteGUI carteRetourneePrecedente; // état "mémoire" du coup précédemment joué
        bool gagnee;


        public AutreMemory()
        {
            InitializeComponent();

            String[] temp = { "A", "A", "B", "B", "C", "C", "D", "D", "E", "E" };
            valeursCartes = new List<string>(temp);

            carteRetourneePrecedente = null;


            int nbLignes = 2;
            int nbColonnes = 5;
            for (int l = 0; l < nbLignes; l++)
            {
                RowDefinition ligne = new RowDefinition();
                grid1.RowDefinitions.Add(ligne);
            }
            for (int c = 0; c < nbColonnes; c++)
            {
                ColumnDefinition colonne = new ColumnDefinition();
                grid1.ColumnDefinitions.Add(colonne);
            }

            for (int l = 0; l < nbLignes; l++)
            {
                for (int c = 0; c < nbColonnes; c++)
                {
                    CarteGUI carteGui = new CarteGUI(ValeurSuivante(), this);

                    Grid.SetRow(carteGui, l);       // positionnement sur ligne
                    Grid.SetColumn(carteGui, c);    // positionnement sur colonne
                    grid1.Children.Add(carteGui);   // ajout au conteneur parent (la grille)
                }
            }
        }

        /// <summary>
        /// Permet, lors de la construction de l'objet, de donner aléatoirement une valeur à chaque Carte.
        /// </summary>
        /// Le principe est de "piocher" aléatoirement dans valeursCartes, puis d'enlever cette valeur. Et ainsi de suite à chaque appel de la méthode.
        /// <returns></returns>
        private String ValeurSuivante()
        {
            if (valeursCartes.Count == 0)
                return null;

            Random rand = new Random();
            int indice = rand.Next(0, valeursCartes.Count - 1);
            String valeur = valeursCartes[indice]; //valeursCartes.ElementAt<String>(indice);
            valeursCartes.RemoveAt(indice);
            return valeur;
        }


        /// <summary>
        /// Le jeu, qui a la responsabilité de l'ensemble des cartes, arbitre de la suite à donner une fois que la carte carteRetournee vient d'être retournée.
        /// </summary>
        /// <param name="carteRetournee">Carte venant d'être retournée</param>
        internal void miseAJour(CarteGUI carteRetournee)
        {
            if (carteRetourneePrecedente == null)
            {
                carteRetourneePrecedente = carteRetournee;
            }
            else
            {
                // le joueur rejoue la même carte
                if (carteRetournee == carteRetourneePrecedente)
                {
                    carteRetourneePrecedente = null;
                }
                else
                {
                    // bonne paire --> cartes désactivées, pour ne plus jouer avec
                    if (carteRetourneePrecedente.ValeurCarte == carteRetournee.ValeurCarte)
                    {
                        carteRetourneePrecedente.RendreInactive();
                        carteRetournee.RendreInactive();
                        gagnee = true;
                        for(int i=0; i<10;i++)
                        {
                            if((grid1.Children[i] as Button).IsEnabled == true)
                            {
                                gagnee = false;
                            }
                        }
                        if (gagnee == true)
                        {
                            MessageBox.Show("Le jeu est fini, vous avez gagné !");
                        }
                    }
                    // mauvaise paire --> on les retourne toutes les deux.
                    else
                    {
                        MessageBox.Show("mauvaise paire");
                        carteRetourneePrecedente.TournerCarte();
                        carteRetournee.TournerCarte();
                    }
                    carteRetourneePrecedente = null;
                }
            }
        }

    }
}
