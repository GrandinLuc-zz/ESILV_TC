using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ESILV_TC_1
{
    class CarteGUI : Button
    {
        private Carte carte;
        private Views.AutreMemory jeuGui;


        public CarteGUI(String valeurCarte, Views.AutreMemory jeu)
        {
            carte = new Carte(valeurCarte);

            // en tant que Button
            Content = "?";
            Click += CarteGUI_Click; // <=> new RoutedEventHandler(ActionOn_Click);
            FontSize = 75;


            Background = new SolidColorBrush(Color.FromRgb(75, 172, 63));

            // connaissance du jeu (la carte a "concience" d'être dans un jeu)
            jeuGui = jeu;
        }

        private void CarteGUI_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // la carte (GUI) est "autonome" pour se retourner
            this.TournerCarte();

            // ensuite, passer le relais au jeu qui a une "vision" sur les cartes (dont la carte précédemment retournée)
            jeuGui.miseAJour(this);
        }

        public String ValeurCarte
        {
            get { return carte.Valeur; }
        }

        public void TournerCarte()
        {
            carte.Retourner();

            if (carte.EstFaceCachee)
            {
                Content = "?";
                Background = new SolidColorBrush(Color.FromRgb(75, 172, 63));
            }
            else
            {
                Content = carte.Valeur;
                Background = Brushes.White;
            }
        }


        public void RendreInactive()
        {
            // en tant que Button
            IsEnabled = false;
        }

        public Carte Carte
        {
            get { return carte; }
        }

    }
}
