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
using MaterialDesignThemes;
using MaterialDesignColors;

namespace ESILV_TC_1.Views
{
    /// <summary>
    /// Logique d'interaction pour MembreAdministrer.xaml
    /// </summary>
    public partial class MembreAdministrer : UserControl
    {
        string[] colPersonnel = { "Nom", "Prenom", "Naissance","Adresse","Poste","Info bancaires","Salaire","Date entrée" };
        string[] colMembre = { "Nom", "Prenom", "Naissance", "Adresse", "Classement", "En regle", "Sexe" };
        ESILV_TC_1.Membre membreCourant = new ESILV_TC_1.Membre();
        ESILV_TC_1.Personnel personnnelCourant = new ESILV_TC_1.Personnel();
        TextBox tbCourante = new TextBox();
        RadioButton rbM = new RadioButton();
        RadioButton rbF = new RadioButton();
        RadioButton rbOui = new RadioButton();
        RadioButton rbNon = new RadioButton();
        Button valider = new Button();

        public MembreAdministrer()
        {
            InitializeComponent();
            Grille_Admin.Children.Clear();
            Grille_Admin.RowDefinitions.Clear();
            Grille_Admin.ColumnDefinitions.Clear();
            Modifier_Profil_Button.IsEnabled = true;
            Ajouter_Personnel_Button.IsEnabled = true;
        }

        private void Modifier_Profil_Button_Click(object sender, RoutedEventArgs e)
        {
            Grille_Admin.Children.Clear();
            Grille_Admin.RowDefinitions.Clear();
            Grille_Admin.ColumnDefinitions.Clear();

            AfficherMembreEtPersonnel();
            Modifier_Profil_Button.IsEnabled = false;
            Ajouter_Personnel_Button.IsEnabled = true;


        }


        /// <summary>
        /// On affiche dans la grille à l'interieur de l'User Interface nommé Grille_Admin deux tableaux contenants respectivement le personnel et les membres ainsi que leurs données de base
        /// </summary>
        public void AfficherMembreEtPersonnel()
        {
            Grille_Admin.Children.Add(new StackPanel());

            (Grille_Admin.Children[0] as StackPanel).Children.Add(new StackPanel());
            ((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Orientation = Orientation.Horizontal;
            for (int i = 0; i < colPersonnel.Length; i++)
            {
                ((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children.Add(new TextBox());
                (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[i] as TextBox).Width = 105;
                (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[i] as TextBox).Foreground = Brushes.White;
                (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[i] as TextBox).IsHitTestVisible = false;
                (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[i] as TextBox).Background = new SolidColorBrush(Color.FromRgb(0, 23, 48));
                (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[i] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[i] as TextBox).Text = colPersonnel[i];
            }

            ((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children.Add(new TextBox());
            (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[colPersonnel.Length] as TextBox).Background = new SolidColorBrush(Color.FromRgb(0, 23, 48));
            (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[colPersonnel.Length] as TextBox).Foreground = Brushes.White;
            (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[colPersonnel.Length] as TextBox).Width = 40;
            (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[colPersonnel.Length] as TextBox).IsHitTestVisible = false;
            (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[colPersonnel.Length] as TextBox).FontSize = 10;
            (((Grille_Admin.Children[0] as StackPanel).Children[0] as StackPanel).Children[colPersonnel.Length] as TextBox).Text = "Modifier";


            #region Premier tableau pour le personnel

            (Grille_Admin.Children[0] as StackPanel).Children.Add(new ScrollViewer());
            ((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Width = 900;
            ((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Height = 228;
            ((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content = new StackPanel();
            (((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Orientation = Orientation.Vertical;

            for (int i = 0; i < ESILV_TC_1.Personnel.lperso.Count; i++)
            {
                (((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children.Add(new StackPanel());
                ((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Orientation = Orientation.Horizontal;

                ((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[0] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[0] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[0] as TextBox).FontSize = 12;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[0] as TextBox).Width = 105;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[0] as TextBox).Text = ESILV_TC_1.Personnel.lperso[i].Nom;

                ((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[1] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[1] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[1] as TextBox).FontSize = 12;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[1] as TextBox).Width = 105;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[1] as TextBox).Text = ESILV_TC_1.Personnel.lperso[i].Prenom;

                ((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[2] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[2] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[2] as TextBox).FontSize = 12;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[2] as TextBox).Width = 105;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[2] as TextBox).Text = ESILV_TC_1.Personnel.lperso[i].Naissance.Day + "/" + ESILV_TC_1.Personnel.lperso[i].Naissance.Month + "/" + ESILV_TC_1.Personnel.lperso[i].Naissance.Year;

                ((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[3] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[3] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[3] as TextBox).FontSize = 12;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[3] as TextBox).Width = 105;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[3] as TextBox).Text = ESILV_TC_1.Personnel.lperso[i].Adresse;

                ((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[4] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[4] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[4] as TextBox).FontSize = 12;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[4] as TextBox).Width = 105;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[4] as TextBox).Text = ESILV_TC_1.Personnel.lperso[i].Poste;

                ((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[5] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[5] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[5] as TextBox).FontSize = 12;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[5] as TextBox).Width = 105;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[5] as TextBox).Text = (ESILV_TC_1.Personnel.lperso[i] as ISalaire).infoBancaires;

                ((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[6] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[6] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[6] as TextBox).FontSize = 12;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[6] as TextBox).Width = 105;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[6] as TextBox).Text = (ESILV_TC_1.Personnel.lperso[i] as ISalaire).salaire.ToString();

                ((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[7] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[7] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[7] as TextBox).FontSize = 12;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[7] as TextBox).Width = 105;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[7] as TextBox).Text = (ESILV_TC_1.Personnel.lperso[i] as ISalaire).dateEntree.Day + "/" + (ESILV_TC_1.Personnel.lperso[i] as ISalaire).dateEntree.Month + "/" + (ESILV_TC_1.Personnel.lperso[i] as ISalaire).dateEntree.Year;
                

                ((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children.Add(new Button());
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[8] as Button).Background = Brushes.Black;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[8] as Button).Tag = i;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[8] as Button).Width = 40;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[8] as Button).Height = 20;
                (((((Grille_Admin.Children[0] as StackPanel).Children[1] as ScrollViewer).Content as StackPanel).Children[i] as StackPanel).Children[8] as Button).Click += PersonnelAdministrer_Click;
            }
            #endregion


            #region Tableau des membres
            (Grille_Admin.Children[0] as StackPanel).Children.Add(new StackPanel());
            ((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Orientation = Orientation.Horizontal;

            for (int i = 0; i < colMembre.Length; i++)
            {
                ((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children.Add(new TextBox());
                (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[i] as TextBox).Width = 100;
                (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[i] as TextBox).IsHitTestVisible = false;
                (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[i] as TextBox).Foreground = Brushes.White;
                (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[i] as TextBox).Background = new SolidColorBrush(Color.FromRgb(0, 23, 48));
                (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[i] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[i] as TextBox).Text = colMembre[i];
            }
            (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[0] as TextBox).Width = 120;
            (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[1] as TextBox).Width = 120;
            (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[3] as TextBox).Width = 220;
            (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[6] as TextBox).Width = 50;




            ((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children.Add(new TextBox());
            (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[colMembre.Length] as TextBox).Background = new SolidColorBrush(Color.FromRgb(0, 23, 48));
            (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[colMembre.Length] as TextBox).Foreground = Brushes.White;
            (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[colMembre.Length] as TextBox).Width = 50;
            (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[colMembre.Length] as TextBox).IsHitTestVisible = false;
            (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[colMembre.Length] as TextBox).FontSize = 10;
            (((Grille_Admin.Children[0] as StackPanel).Children[2] as StackPanel).Children[colMembre.Length] as TextBox).Text = "Modifier";





            (Grille_Admin.Children[0] as StackPanel).Children.Add(new ScrollViewer());
            ((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Width = 900;
            ((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Height = 228;
            ((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content = new StackPanel();
            (((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Orientation = Orientation.Vertical;

            for (int j = 0; j < ESILV_TC_1.Membre.lmembre.Count; j++)
            {
                (((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children.Add(new StackPanel());
                ((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Orientation = Orientation.Horizontal;

                ((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[0] as TextBox).Width = 120;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[0] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[0] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[0] as TextBox).Text = ESILV_TC_1.Membre.lmembre[j].Nom;

                ((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[1] as TextBox).Width = 120;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[1] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[1] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[1] as TextBox).Text = ESILV_TC_1.Membre.lmembre[j].Prenom;

                ((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[2] as TextBox).Width = 100;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[2] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[2] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[2] as TextBox).Text = ESILV_TC_1.Membre.lmembre[j].Naissance.Day.ToString() + "/" + ESILV_TC_1.Membre.lmembre[j].Naissance.Month.ToString() + "/" + ESILV_TC_1.Membre.lmembre[j].Naissance.Year.ToString();


                ((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[3] as TextBox).Width = 220;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[3] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[3] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[3] as TextBox).Text = ESILV_TC_1.Membre.lmembre[j].Adresse;

                ((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[4] as TextBox).Width = 100;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[4] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[4] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[4] as TextBox).Text = ESILV_TC_1.Membre.lmembre[j].Classement;


                ((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[5] as TextBox).Width = 100;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[5] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[5] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[5] as TextBox).Text = ESILV_TC_1.Membre.lmembre[j].EnRegle.ToString();

                ((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children.Add(new TextBox());
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[6] as TextBox).Width = 50;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[6] as TextBox).IsHitTestVisible = false;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[6] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[6] as TextBox).Text = ESILV_TC_1.Membre.lmembre[j].Sexe.ToString();


                ((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children.Add(new Button());
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[7] as Button).Background = Brushes.Black;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[7] as Button).Tag = j;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[7] as Button).Width = 50;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[7] as Button).Height = 20;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[7] as Button).BorderBrush = Brushes.Black;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[7] as Button).Content = "Modifier" ;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[7] as Button).Margin = new Thickness(0, 0, 0, 0);
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[7] as Button).Foreground = Brushes.Black;
                (((((Grille_Admin.Children[0] as StackPanel).Children[3] as ScrollViewer).Content as StackPanel).Children[j] as StackPanel).Children[7] as Button).Click += MembreAdministrer_Click;
                #endregion
            }
        }
        /// <summary>
        /// On utilise le tag du Button ( l'object sender ) pour identifier quel membre doit être modifié
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PersonnelAdministrer_Click(object sender, RoutedEventArgs e)
        {
            Grille_Admin.Children.Clear();
            Grille_Admin.RowDefinitions.Clear();
            Grille_Admin.ColumnDefinitions.Clear();


            Ajouter_Personnel_Button.IsEnabled = false;
            Modifier_Profil_Button.IsEnabled = true;

            for (int i = 0; i < 10; i++)
            {
                Grille_Admin.RowDefinitions.Add(new RowDefinition());
                Grille_Admin.ColumnDefinitions.Add(new ColumnDefinition());
            }

            #region Création des TextBox qui affichent juste du texte pour parler des charactéristiques du membre
            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Nom:";
            Grid.SetRow(tbCourante, 1);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 2);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false; tbCourante.Text = "Prénom:";
            Grid.SetRow(tbCourante, 3);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 2);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false; tbCourante.Text = "Date de naissance:";
            Grid.SetRow(tbCourante, 5);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Adresse:";
            Grid.SetRow(tbCourante, 7);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Poste:";
            Grid.SetRow(tbCourante, 1);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Date d'entrée:";
            Grid.SetRow(tbCourante, 3);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Salaire:";
            Grid.SetRow(tbCourante, 5);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Informations bancaires:";
            Grid.SetRow(tbCourante, 7);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            #endregion

            #region TextBox dont on peut modifer le texte et RadioButton proposant un choix binaire
            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            tbCourante.Text = ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Nom;
            Grid.SetRow(tbCourante, 2);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            tbCourante.Text = ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Prenom;
            Grid.SetRow(tbCourante, 4);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            tbCourante.Text = ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Naissance.Day+"/"+ ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Naissance.Month+"/"+ ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Naissance.Year;
            Grid.SetRow(tbCourante, 6);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 20;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 330;
            tbCourante.Text = ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Adresse;
            Grid.SetRow(tbCourante, 8);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 4);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            tbCourante.Text = ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Poste;
            Grid.SetRow(tbCourante, 2);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            tbCourante.Text = (ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)] as ISalaire).dateEntree.Day + "/"+(ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)] as ISalaire).dateEntree.Month + "/" + (ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)] as ISalaire).dateEntree.Year;
            Grid.SetRow(tbCourante, 4);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            tbCourante.Text = (ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)] as ISalaire).salaire.ToString();
            Grid.SetRow(tbCourante, 6);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 330;
            tbCourante.Text = (ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)] as ISalaire).infoBancaires;
            Grid.SetRow(tbCourante, 8);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 4);
            Grille_Admin.Children.Add(tbCourante);

            valider = new Button();
            valider.Content = "Confirmer";
            valider.Width = 250;
            valider.Click += Modifier_Personnel_Click;
            valider.Tag = (sender as Button).Tag;
            Grid.SetRow(valider, 9);
            Grid.SetColumn(valider, 4);
            Grid.SetColumnSpan(valider, 3);
            Grille_Admin.Children.Add(valider);


            #endregion


        }

        private void Modifier_Personnel_Click(object sender, RoutedEventArgs e)
        {
            ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Nom = (Grille_Admin.Children[8] as TextBox).Text;
            ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Prenom = (Grille_Admin.Children[9] as TextBox).Text;
            int[] date = new int[3];
            try
            {
                date[0] = Convert.ToInt32(((Grille_Admin.Children[10] as TextBox).Text).Split('/')[0]);
                date[1] = Convert.ToInt32(((Grille_Admin.Children[10] as TextBox).Text).Split('/')[1]);
                date[2] = Convert.ToInt32(((Grille_Admin.Children[10] as TextBox).Text).Split('/')[2]);
            }
            catch
            {
                MessageBox.Show("Le format de la date doit être JJ/MM/AAAA");
            }
            ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Naissance = new DateTime(date[2], date[1], date[0]);
            ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Adresse = (Grille_Admin.Children[11] as TextBox).Text;
            ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)].Poste = (Grille_Admin.Children[12] as TextBox).Text;
            try
            {
                date[0] = Convert.ToInt32(((Grille_Admin.Children[13] as TextBox).Text).Split('/')[0]);
                date[1] = Convert.ToInt32(((Grille_Admin.Children[13] as TextBox).Text).Split('/')[1]);
                date[2] = Convert.ToInt32(((Grille_Admin.Children[13] as TextBox).Text).Split('/')[2]);
            }
            catch
            {
                MessageBox.Show("Le format de la date doit être JJ/MM/AAAA");
            }
            (ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)] as ISalaire).dateEntree = new DateTime(date[2], date[1], date[0]);
            (ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)] as ISalaire).salaire = Convert.ToInt32((Grille_Admin.Children[14] as TextBox).Text);
            (ESILV_TC_1.Personnel.lperso[Convert.ToInt32((sender as Button).Tag)] as ISalaire).infoBancaires = (Grille_Admin.Children[15] as TextBox).Text;

            MessageBox.Show("Personnel modifié !");

        }

        /// <summary>
        /// On utilise le Tag du Button pour identifier quel membre doit être modifié
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MembreAdministrer_Click(object sender, RoutedEventArgs e)
        {                 
            membreCourant = ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)];
            Grille_Admin.Children.Clear();
            Grille_Admin.RowDefinitions.Clear();
            Grille_Admin.ColumnDefinitions.Clear();
            AfficherLeMembreAModifier(Convert.ToInt32((sender as Button).Tag));            
        }

        /// <summary>
        /// On a determiné quel membre doit être affiché pour donner la posibilité de le modifier en paramètre on prend l'indice du membre à afficher
        /// </summary>
        public void AfficherLeMembreAModifier(int tag)
        {
            for(int i=0; i<10;i++)
            {
                Grille_Admin.RowDefinitions.Add(new RowDefinition());
                Grille_Admin.ColumnDefinitions.Add(new ColumnDefinition());
            }

            #region Création des TextBox qui affichent juste du texte pour parler des charactéristiques du membre
            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Nom:";
            Grid.SetRow(tbCourante, 1);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 2);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false; tbCourante.Text = "Prénom:";
            Grid.SetRow(tbCourante, 3);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 2);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false; tbCourante.Text = "Date de naissance:";
            Grid.SetRow(tbCourante, 5);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false; 
            tbCourante.Text = "Adresse:";
            Grid.SetRow(tbCourante, 7);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Classement:";
            Grid.SetRow(tbCourante, 1);
            Grid.SetColumn(tbCourante, 7);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "En règle?:";
            Grid.SetRow(tbCourante, 3);
            Grid.SetColumn(tbCourante, 7);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Sexe:";
            Grid.SetRow(tbCourante, 5);
            Grid.SetColumn(tbCourante, 7);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            #endregion

            #region TextBox dont on peut modifer le texte et RadioButton proposant un choix binaire
            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Text = ESILV_TC_1.Membre.lmembre[tag].Nom;
            Grid.SetRow(tbCourante,  2);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Text = ESILV_TC_1.Membre.lmembre[tag].Prenom;
            Grid.SetRow(tbCourante, 4);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Text = ESILV_TC_1.Membre.lmembre[tag].Naissance.Day+"/"+ ESILV_TC_1.Membre.lmembre[tag].Naissance.Month+"/"+ ESILV_TC_1.Membre.lmembre[tag].Naissance.Year ;
            Grid.SetRow(tbCourante, 6);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 20;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Text = ESILV_TC_1.Membre.lmembre[tag].Adresse;
            Grid.SetRow(tbCourante, 8);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 5);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Text = ESILV_TC_1.Membre.lmembre[tag].Classement;
            Grid.SetRow(tbCourante, 2);
            Grid.SetColumn(tbCourante, 7);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            rbOui.Content = "Oui";
            rbOui.GroupName = "EnRegle";
            Grid.SetColumn(rbOui, 7);
            Grid.SetRow(rbOui, 4);
            Grille_Admin.Children.Add(rbOui);

            rbNon.Content = "Non";
            rbNon.GroupName = "EnRegle";
            Grid.SetColumn(rbNon, 9);
            Grid.SetRow(rbNon, 4);
            Grille_Admin.Children.Add(rbNon);

            if (ESILV_TC_1.Membre.lmembre[tag].EnRegle == true)
                rbOui.IsChecked = true;
            else
                rbNon.IsChecked = true;

            rbM.Content = "M";
            rbM.GroupName = "Sexe";
            Grid.SetColumn(rbM, 7);
            Grid.SetRow(rbM, 6);
            Grille_Admin.Children.Add(rbM);


            
            rbF.Content = "F";
            rbF.GroupName = "Sexe";
            Grid.SetColumn(rbF, 9);
            Grid.SetRow(rbF, 6);
            Grille_Admin.Children.Add(rbF);


            if (ESILV_TC_1.Membre.lmembre[tag].Sexe == Sexe.M)
                rbM.IsChecked = true;
            else if(ESILV_TC_1.Membre.lmembre[tag].Sexe == Sexe.F)
                rbF.IsChecked = true;


            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Numéro:";
            Grid.SetRow(tbCourante, 7);
            Grid.SetColumn(tbCourante, 7);
            Grid.SetColumnSpan(tbCourante, 2);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Text = ESILV_TC_1.Membre.lmembre[tag].Num;
            Grid.SetRow(tbCourante, 8);
            Grid.SetColumn(tbCourante, 7);
            Grid.SetColumnSpan(tbCourante, 2);
            Grille_Admin.Children.Add(tbCourante);


            valider = new Button();
            valider.Content = "Confirmer";
            valider.Width = 200;
            valider.Click += Changer_Membre_Click;
            valider.Tag = tag;
            Grid.SetRow(valider,9);
            Grid.SetColumn(valider, 4);
            Grid.SetColumnSpan(valider, 3);
            Grille_Admin.Children.Add(valider);



            #endregion
        }

        private void Changer_Membre_Click(object sender, RoutedEventArgs e)
        {
            ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)].Nom = (Grille_Admin.Children[7] as TextBox).Text;
            ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)].Prenom = (Grille_Admin.Children[8] as TextBox).Text;
            int[] date = new int[3];
            try
            {
                date[0] = Convert.ToInt32(((Grille_Admin.Children[9] as TextBox).Text).Split('/')[0]);
                date[1] = Convert.ToInt32(((Grille_Admin.Children[9] as TextBox).Text).Split('/')[1]);
                date[2] = Convert.ToInt32(((Grille_Admin.Children[9] as TextBox).Text).Split('/')[2]);
            }
            catch
            {
                MessageBox.Show("Le format de la date doit être JJ/MM/AAAA");
            }
            ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)].Naissance = new DateTime(date[2],date[1],date[0]);
            ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)].Adresse = (Grille_Admin.Children[10] as TextBox).Text;
            ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)].Classement = (Grille_Admin.Children[11] as TextBox).Text;
            ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)].EnRegle = (Grille_Admin.Children[12] as RadioButton).IsChecked == true;
            Sexe sex = Sexe.NI;
            if ((Grille_Admin.Children[14] as RadioButton).IsChecked == true)
                sex = Sexe.M;
            else if ((Grille_Admin.Children[15] as RadioButton).IsChecked == true)
                sex = Sexe.F;
            ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)].Sexe = sex;
            ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)].Num = (Grille_Admin.Children[17] as TextBox).Text;

            MessageBox.Show("Membre modifié !");

        }

        private void Ajouter_Personnel_Button_Click(object sender, RoutedEventArgs e)
        {
            Grille_Admin.Children.Clear();
            Grille_Admin.RowDefinitions.Clear();
            Grille_Admin.ColumnDefinitions.Clear();


            Ajouter_Personnel_Button.IsEnabled = false;
            Modifier_Profil_Button.IsEnabled = true;

            for (int i = 0; i < 10; i++)
            {
                Grille_Admin.RowDefinitions.Add(new RowDefinition());
                Grille_Admin.ColumnDefinitions.Add(new ColumnDefinition());
            }

            #region Création des TextBox qui affichent juste du texte pour parler des charactéristiques du membre
            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Nom:";
            Grid.SetRow(tbCourante, 1);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 2);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false; tbCourante.Text = "Prénom:";
            Grid.SetRow(tbCourante, 3);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 2);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false; tbCourante.Text = "Date de naissance:";
            Grid.SetRow(tbCourante, 5);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Adresse:";
            Grid.SetRow(tbCourante, 7);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Poste:";
            Grid.SetRow(tbCourante, 1);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Date d'entrée:";
            Grid.SetRow(tbCourante, 3);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Salaire:";
            Grid.SetRow(tbCourante, 5);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.White;
            tbCourante.IsEnabled = false;
            tbCourante.Text = "Informations bancaires:";
            Grid.SetRow(tbCourante, 7);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            #endregion

            #region TextBox dont on peut modifer le texte et RadioButton proposant un choix binaire
            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            Grid.SetRow(tbCourante, 2);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            Grid.SetRow(tbCourante, 4);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            Grid.SetRow(tbCourante, 6);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 20;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            Grid.SetRow(tbCourante, 8);
            Grid.SetColumn(tbCourante, 1);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            Grid.SetRow(tbCourante, 2);
            Grid.SetColumn(tbCourante,6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            Grid.SetRow(tbCourante, 4);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            Grid.SetRow(tbCourante, 6);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            tbCourante = new TextBox();
            tbCourante.Style = null;
            tbCourante.FontSize = 25;
            tbCourante.BorderBrush = Brushes.Black;
            tbCourante.Width = 250;
            Grid.SetRow(tbCourante, 8);
            Grid.SetColumn(tbCourante, 6);
            Grid.SetColumnSpan(tbCourante, 3);
            Grille_Admin.Children.Add(tbCourante);

            valider = new Button();
            valider.Content = "Confirmer";
            valider.Width = 250;
            valider.Click += Ajouter_Personnel;            
            Grid.SetRow(valider, 9);
            Grid.SetColumn(valider, 4);
            Grid.SetColumnSpan(valider, 3);
            Grille_Admin.Children.Add(valider);


            #endregion



        }

        private void Ajouter_Personnel(object sender, RoutedEventArgs e)
        {
            int[] date = new int[3];
            int dernier = Personnel.lperso.Count;
            try
            {
                date[0] = Convert.ToInt32(((Grille_Admin.Children[10] as TextBox).Text).Split('/')[0]);
                date[1] = Convert.ToInt32(((Grille_Admin.Children[10] as TextBox).Text).Split('/')[1]);
                date[2] = Convert.ToInt32(((Grille_Admin.Children[10] as TextBox).Text).Split('/')[2]);
            }
            catch
            {
                MessageBox.Show("Le format de la date doit être JJ/MM/AAAA");
            }

            new Personnel((Grille_Admin.Children[8] as TextBox).Text, (Grille_Admin.Children[9] as TextBox).Text, new DateTime(date[2], date[1], date[0]),(Grille_Admin.Children[11] as TextBox).Text,(Grille_Admin.Children[12] as TextBox).Text);
            try
            {
                date[0] = Convert.ToInt32(((Grille_Admin.Children[13] as TextBox).Text).Split('/')[0]);
                date[1] = Convert.ToInt32(((Grille_Admin.Children[13] as TextBox).Text).Split('/')[1]);
                date[2] = Convert.ToInt32(((Grille_Admin.Children[13] as TextBox).Text).Split('/')[2]);
            }
            catch
            {
                MessageBox.Show("Le format de la date doit être JJ/MM/AAAA");
            }
            (Personnel.lperso[dernier] as ISalaire).dateEntree = new DateTime(date[2], date[1], date[0]);
            (Personnel.lperso[dernier] as ISalaire).salaire = Convert.ToInt32((Grille_Admin.Children[14] as TextBox).Text);
            (Personnel.lperso[dernier] as ISalaire).infoBancaires = (Grille_Admin.Children[15] as TextBox).Text;

            MessageBox.Show("Personnel ajouté !");
        }
    }
}
