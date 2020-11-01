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
    /// Logique d'interaction pour MembreAfficher.xaml
    /// </summary>
    public partial class MembreAfficher : UserControl
    {
        List<ESILV_TC_1.Membre> MembresAfficher = new List<ESILV_TC_1.Membre>();
        bool triParNom = false;

        public MembreAfficher()
        {
            InitializeComponent();
            triParNom = false;
            InitialiserListeMembre();
        }
        public void InitialiserListeMembre()
        {            
            string sex;
            MembresAfficher = new List<ESILV_TC_1.Membre>();
            if(ESILV_TC_1.MainWindow.voirCompetMembres == true)
            {
                for(int i=0;i<ESILV_TC_1.Competition.competCourante.Compo.Count;i++)
                {
                    for(int j=0;j<ESILV_TC_1.Membre.lmembre.Count;j++)
                    {
                        if(ESILV_TC_1.Competition.competCourante.Compo[i] == ESILV_TC_1.Membre.lmembre[j])
                        {
                            MembresAfficher.Add(ESILV_TC_1.Membre.lmembre[j]);
                        }
                    }
                }               
            }
            else if(triParNom == true)
            {
                MembresAfficher = ESILV_TC_1.Membre.lmembre;
                ((MainWindow)System.Windows.Application.Current.MainWindow).Trier(MembresAfficher);
            }
            else
            {
                MembresAfficher = ESILV_TC_1.Membre.lmembre;
            }
            for (int i=0; i< MembresAfficher.Count;i++)
            {
                // On ajoute un StackPanel pour chaque membre                
                LW_AfficherMembre.Children.Add(new StackPanel());
                (LW_AfficherMembre.Children[i] as StackPanel).Orientation = Orientation.Horizontal;

                (LW_AfficherMembre.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[0] as TextBox).Width = 159;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[0] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[0] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[0] as TextBox).IsReadOnly = true;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[0] as TextBox).Text = MembresAfficher[i].Nom;

                (LW_AfficherMembre.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[1] as TextBox).Width = 159;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[1] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[1] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[1] as TextBox).IsReadOnly = true;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[1] as TextBox).Text = MembresAfficher[i].Prenom;

                (LW_AfficherMembre.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[2] as TextBox).Width = 146;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[2] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[2] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[2] as TextBox).IsReadOnly = true;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[2] as TextBox).Text = MembresAfficher[i].Num;               
                                    
                (LW_AfficherMembre.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[3] as TextBox).Width = 146;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[3] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[3] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[3] as TextBox).IsReadOnly = true;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[3] as TextBox).Text = MembresAfficher[i].Naissance.Day+"/"+MembresAfficher[i].Naissance.Month+"/"+ MembresAfficher[i].Naissance.Year;
                                    
                (LW_AfficherMembre.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[4] as TextBox).Width = 280;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[4] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[4] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[4] as TextBox).IsReadOnly = true;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[4] as TextBox).Text = MembresAfficher[i].Adresse;

                (LW_AfficherMembre.Children[i] as StackPanel).Children.Add(new TextBox());
                if (MembresAfficher[i].Sexe == Sexe.M)
                {
                    sex = "M";
                }
                else if(MembresAfficher[i].Sexe == Sexe.F)
                {
                    sex = "F";
                }
                else
                {
                    sex = "NI";
                }
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[5] as TextBox).Width = 50;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[5] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[5] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[5] as TextBox).IsReadOnly = true;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[5] as TextBox).Text = sex;

                (LW_AfficherMembre.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[6] as TextBox).Width = 146;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[6] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[6] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[6] as TextBox).IsReadOnly = true;
                ((LW_AfficherMembre.Children[i] as StackPanel).Children[6] as TextBox).Text = MembresAfficher[i].Classement;


                if ( ESILV_TC_1.MainWindow.competSelect == true || ESILV_TC_1.MainWindow.voirCompetMembres == true)
                {
                    (LW_AfficherMembre.Children[i] as StackPanel).Children.Add(new Button());
                    ((LW_AfficherMembre.Children[i] as StackPanel).Children[7] as Button).Width = 25;
                    ((LW_AfficherMembre.Children[i] as StackPanel).Children[7] as Button).Height = 25;
                    ((LW_AfficherMembre.Children[i] as StackPanel).Children[7] as Button).Margin = new Thickness(3,0,0,0);
                    ((LW_AfficherMembre.Children[i] as StackPanel).Children[7] as Button).Tag = i;
                    ((LW_AfficherMembre.Children[i] as StackPanel).Children[7] as Button).Style = null;
                    ((LW_AfficherMembre.Children[i] as StackPanel).Children[7] as Button).Content = new MaterialDesignThemes.Wpf.PackIcon { Kind = MaterialDesignThemes.Wpf.PackIconKind.Add };
                    if(ESILV_TC_1.MainWindow.competSelect == true)
                    {
                        ((LW_AfficherMembre.Children[i] as StackPanel).Children[7] as Button).Click += AjouterMembreCompet;
                    }
                    else if(ESILV_TC_1.MainWindow.voirCompetMembres == true)
                    {
                        ((LW_AfficherMembre.Children[i] as StackPanel).Children[7] as Button).Click += RetirerMembreCompet;
                    }

                }

            }

        }

        private void RetirerMembreCompet(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ESILV_TC_1.MainWindow.autoriserAdmin == true)
                {
                    ESILV_TC_1.Competition.competCourante.Compo.Remove(ESILV_TC_1.Competition.competCourante.Compo[Convert.ToInt32((sender as Button).Tag)]);
                    MessageBox.Show("Membre retiré de la compétition");
                    //((MainWindow)System.Windows.Application.Current.MainWindow).CompetCompetiteurs();
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas les privilèges d'administrateur");
                }

            }
            catch
            {
                MessageBox.Show("Le joueur à déjà été retiré de la compétition");
            }
        }

        private void AjouterMembreCompet(object sender, RoutedEventArgs e)
        {
            bool estDedans = false;
            if(ESILV_TC_1.Competition.competCourante.Compo != null)
            {
                for(int i=0;i< ESILV_TC_1.Competition.competCourante.Compo.Count;i++)
                {
                    if(ESILV_TC_1.Competition.competCourante.Compo[i] == ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)])
                    {
                        estDedans = true;
                    }
                }
                if(estDedans == false)
                {
                    ESILV_TC_1.Competition.competCourante.Compo.Add(ESILV_TC_1.Membre.lmembre[Convert.ToInt32((sender as Button).Tag)]);
                    MessageBox.Show("Joueur ajouté à la compétition");
                }
                else
                {
                    MessageBox.Show("Ce joueur est déjà inscrit à cette compétition");
                }                
            }
            else
            {
                MessageBox.Show("Pas de compétition sélectionnée");
            }

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            triParNom = !triParNom;
            LW_AfficherMembre.Children.Clear();
            InitialiserListeMembre();
        }
    }
}
