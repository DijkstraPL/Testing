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


namespace ReinforcementCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Beam beam = new Beam();
            beam.Metoda(4);
        }

        private void calc_Click(object sender, RoutedEventArgs e)
        {
            double width = Double.Parse(wWidth.Text);
            double height = Double.Parse(wHeight.Text);
            double charStrengthConcrete = Double.Parse(wCharStrengthConcrete.Text);
            double charStrengthSteel = Double.Parse(wCharStrengthSteel.Text);
            double cover = Double.Parse(wCover.Text);
            double stirrupsDiameter = Double.Parse(wStirrupsDiameter.Text);
            double reinforcementDiameter = Double.Parse(wReinforcementDiameter.Text);
            double bendingMoment = Double.Parse(wBendingMoment.Text);

            var beam = new Beam(width, height, bendingMoment, charStrengthConcrete, charStrengthSteel, cover, stirrupsDiameter, reinforcementDiameter);
            beam.CalculateReinforcement();

            wNeededReinforcement.Text = beam.RequiredReinforcement.ToString();

            wAmountOfReinforcement.Text = "You need " + Math.Ceiling(beam.RequiredReinforcement / (Math.PI * Math.Pow(beam.ReinforcementDiameter / 10 / 2, 2))) + " bars";
        }
    }
}
