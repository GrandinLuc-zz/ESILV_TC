using ESILV_TC_1.ViewModels;
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
using System.Windows.Markup;



namespace ESILV_TC_1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Initialisation des variables
        internal static bool autoriserAdmin = false;
        bool mouseEnter = false;
        bool mouseDown = false;
        internal static bool competSelect = false;
        internal static bool voirCompetMembres;
        #endregion


        public MainWindow()
        {
            InitializeComponent();

            //Mettre l'image dans le fichier ressource en arrière-plan sur le menu d'accueil ( je n'ai finalement pas opté pour cette solution )

            //Image im = new Image();
            //var uriSource = new Uri(@"/ESILV_TC_1;component/Resources/tennis-1381230_1920.jpg", UriKind.Relative);
            //im.Source = new BitmapImage(uriSource);            
            //DataContext = im;

            DataContext = new AccueilViewModel();
            InitialiserDesMembres();           
            InitialiserDesCompetitions();
        }
        internal void Trier(List<Membre> listeDeMembres)
        {
            Membre mem = new Membre();
            mem.Trier(listeDeMembres);
        }

        public void InitialiserDesMembres()
        {
            new Membre("Petit", "Elise", new DateTime(1996, 09, 06), "11 Boulevard de Sèvres, Marseille", Sexe.F, "0673435618", false);
            new Membre("Durand", "Thomas", new DateTime(1999, 01, 23), "52 Rue de la Paix, Paris", Sexe.M, "0673435618", true);
            new Membre("Dubois", "Victor", new DateTime(2000, 12, 31), "17 Cours de Vincennes, Marseille", Sexe.M, "0723538756", false);
            new Membre("Lambert", "Boris", new DateTime(1999, 11, 22), "10 Downing Street, London", Sexe.M, "0645435618", true);
            new Membre("Smith", "John", new DateTime(1989, 02, 15), "2456, 5th Avenue, NY", Sexe.M, "0642042010", false);
            new Membre("Daniel", "Jeanne", new DateTime(1963, 01, 23), "401 Rue de la Paix, Paris", Sexe.F, "0671254618", true);
            Membre.lmembre[0].Classement = "40";
            Membre.lmembre[1].Classement = "15.3";
            Membre.lmembre[2].Classement = "15.1";
            Membre.lmembre[4].Classement = "30.5";
        }

        public void InitialiserDesCompetitions()
        {
            new Competition("Tournoi académique de Toulon", "Regional", 15, 12, "30.5", 64, new DateTime(2020,01,29));
            new Competition("Competition ESILV tennis", "National", 4, 1, "15.3", 10, new DateTime(2020,03,01));
            new Competition("Competition du Roubaix TC", "Departemental", 1, 1, "NC", 2, new DateTime(2020,05,11));
            ISalaire salarie = new Personnel("Grandin", "Luc", new DateTime(1999, 03, 11), "Paris", "Gérant");
            salarie.salaire = 9000;
            salarie.infoBancaires = "IBAN: ...";
            salarie.dateEntree = new DateTime(2020, 01, 15);
        }




        #region Changement d'User Interface
        public void CompetCompetiteurs()
        {
            DataContext = new MembreAfficherViewModel();
            voirCompetMembres = true;
        }
        public void CompetSelect()
        {
            DataContext = new MembreAfficherViewModel();
            competSelect = true;
            voirCompetMembres = false;
        }
        private void Off_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void Afficher_Membre_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MembreAfficherViewModel();
            competSelect = false;
            voirCompetMembres = false;
        }
        public void Afficher_Competition_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CompetitionViewModel();
            competSelect = false;
        }
        public void Ajouter_Competition_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CompetitionAjouterViewModel();
            competSelect = false;
        }
        public void Ajouter_Membre_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MembreAjouter();
            competSelect = false;
        }
        #endregion

        /// <summary>
        /// Donne les privilèges d'administrateur à la personne si elle ne les a pas et lui retire si elle les a. 
        /// Par soucis de simplification je n'ai pas mis en place un système de mot de passe permettant de securiser cet accès.
        /// Il s'agit du click correspondant à l'activation d'un ToggleButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Administrer_Membre_Click(object sender, RoutedEventArgs e)
        {
            if( autoriserAdmin == true)
            {
                DataContext = new MembreAdministrerViewModel();
                competSelect = false;
            }
            else
            {
                MessageBox.Show("Vous n'êtes pas autorisé à modifier les paramètres administratifs");
            }
        }

        /// <summary>
        /// Simple bouton ON/OFF pour les privilèges d'administrateur qui serait sensés être sécurisés par un mot de passe, solution que je n'ai pas encore mis en place
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Toggle_Admin_Privileges(object sender, RoutedEventArgs e)
        {           
            autoriserAdmin = !autoriserAdmin;
            if (autoriserAdmin == false)
            {
                Admin_Privileges_TB.Background = Brushes.White;
            }
            else
                Admin_Privileges_TB.Background = Brushes.Red;
        }

        /// <summary>
        /// Cette region comporte les méthodes nécessaires pour déplacer la fenêtre quand on maintient le click gauche de la souris enfoncé et que la souris est au dessus de la barre du menu superieur
        /// </summary>

        #region Bouger la fenêtre  
     
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter = true;
            BougerFenetre();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseEnter = false;
            BougerFenetre();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseDown = true;
            BougerFenetre();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseDown = false;
            BougerFenetre();
        }
        public void BougerFenetre()
        {
            if(mouseEnter == true && mouseDown == true)
            {
                try
                {
                    DragMove();
                }
                catch
                {
                    //  Je n'arrive pas à ne pas générer de problème en cas de click droit 
                    // donc je fais un try/catch avec un catch vide, j'ai testé au préalable les différents 
                    // problèmes généré par cette décision mais après mûre réfléxion c'est à mon humble 
                    // avis la meilleure et la plus simple solution à ce problème
                }
            }
        }

        #endregion

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Afficher_Statistiques_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ViewModels.StatistiquesAfficherViewModel();
        }

        private void Autre_Memory_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ViewModels.AutreMemoryViewModel();
        }
    }
}
