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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ESILV_TC_1.Views
{
    /// <summary>
    /// Logique d'interaction pour Competition.xaml
    /// </summary>
    public partial class Competition : UserControl
    {

        public Competition()
        {
            InitializeComponent();
            InitialiserCompetitions();
        }
        public void InitialiserCompetitions()
        {
            for(int i=0; i< ESILV_TC_1.Competition.lcompets.Count;i++)
            {
                LW_AfficherCompetitions.Children.Add(new StackPanel());
                (LW_AfficherCompetitions.Children[i] as StackPanel).Orientation = Orientation.Horizontal;

                (LW_AfficherCompetitions.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[0] as TextBox).Width = 185;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[0] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[0] as TextBox).IsReadOnly = true;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[0] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[0] as TextBox).Text = ESILV_TC_1.Competition.lcompets[i].Nom;

                (LW_AfficherCompetitions.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[1] as TextBox).Width = 186;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[1] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[1] as TextBox).IsReadOnly = true;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[1] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[1] as TextBox).Text = ESILV_TC_1.Competition.lcompets[i].Qualification;

                (LW_AfficherCompetitions.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[2] as TextBox).Width = 186;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[2] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[2] as TextBox).IsReadOnly = true;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[2] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[2] as TextBox).Text = ESILV_TC_1.Competition.lcompets[i].Niveau;

                (LW_AfficherCompetitions.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[3] as TextBox).Width = 140;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[3] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[3] as TextBox).IsReadOnly = true;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[3] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[3] as TextBox).Text = ESILV_TC_1.Competition.lcompets[i].NbMatchs.ToString();

                (LW_AfficherCompetitions.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[4] as TextBox).Width = 140;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[4] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[4] as TextBox).IsReadOnly = true;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[4] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[4] as TextBox).Text = ESILV_TC_1.Competition.lcompets[i].NbJours.ToString();

                (LW_AfficherCompetitions.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[5] as TextBox).Width = 140;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[5] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[5] as TextBox).IsReadOnly = true;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[5] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[5] as TextBox).Text = ESILV_TC_1.Competition.lcompets[i].NbJoueurs.ToString();

                (LW_AfficherCompetitions.Children[i] as StackPanel).Children.Add(new TextBox());
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[6] as TextBox).Width = 80;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[6] as TextBox).FontWeight = FontWeights.Bold;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[6] as TextBox).IsReadOnly = true;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[6] as TextBox).HorizontalContentAlignment = HorizontalAlignment.Center;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[6] as TextBox).Text = ESILV_TC_1.Competition.lcompets[i].DateCompetition.Day+"/"+ ESILV_TC_1.Competition.lcompets[i].DateCompetition.Month+"/"+ ESILV_TC_1.Competition.lcompets[i].DateCompetition.Year;


                (LW_AfficherCompetitions.Children[i] as StackPanel).Children.Add(new Button());
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[7] as Button).Width = 25;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[7] as Button).Height = 25;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[7] as Button).Background = Brushes.White;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[7] as Button).Margin = new Thickness(3, 0, 0, 0);
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[7] as Button).Content = new MaterialDesignThemes.Wpf.PackIcon  { Kind = MaterialDesignThemes.Wpf.PackIconKind.Add };
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[7] as Button).Tag = i;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[7] as Button).Click += Competition_Ajouter_Competiteur_Click;

                (LW_AfficherCompetitions.Children[i] as StackPanel).Children.Add(new Button());
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[8] as Button).Width = 25;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[8] as Button).Background = Brushes.Black;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[8] as Button).Margin = new Thickness(3, 0, 0, 0);
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[8] as Button).Height = 25;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[8] as Button).Content = new MaterialDesignThemes.Wpf.PackIcon { Kind = MaterialDesignThemes.Wpf.PackIconKind.Add };
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[8] as Button).Tag = i;
                ((LW_AfficherCompetitions.Children[i] as StackPanel).Children[8] as Button).Click += Competition_Voir_Competiteurs;

            }
        }

        private void Competition_Voir_Competiteurs(object sender, RoutedEventArgs e)
        {
            ESILV_TC_1.Competition.competCourante = ESILV_TC_1.Competition.lcompets[Convert.ToInt32((sender as Button).Tag)];
            ((MainWindow)System.Windows.Application.Current.MainWindow).CompetCompetiteurs();
        }

        private void Competition_Ajouter_Competiteur_Click(object sender, RoutedEventArgs e)
        {
            ESILV_TC_1.Competition.competCourante = ESILV_TC_1.Competition.lcompets[Convert.ToInt32((sender as Button).Tag)];
            ((MainWindow)System.Windows.Application.Current.MainWindow).CompetSelect();            

        }
    }
}
