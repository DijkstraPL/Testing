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

namespace ConcreteCover
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public double AdhesionCover { get; set; }
        public int ConstructionClass { get; set; }
        public int MinimalCover { get; set; }
        public readonly int[,] MinimalCoverList = new int[,]
        {
            { 10, 10, 10, 15, 20, 25, 30 },
            { 10, 10, 15, 20, 25, 30, 35 },
            { 10, 10, 20, 25, 30, 35, 40 },
            { 10, 15, 25, 30, 35, 40, 45 },
            { 15, 20, 30, 35, 40, 45, 50 },
            { 20, 25, 35, 40, 45, 55, 55 }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            AdhesionCover = Convert.ToDouble(barDiameter.Text);
            if (aggregate.IsChecked == true)
                AdhesionCover += 5;

            ConstructionClass = 4;
            if (longService.IsChecked == true)
                ConstructionClass += 2;
            if (plateShape.IsChecked == true)
                ConstructionClass -= 1;
            if (concreteControl.IsChecked == true)
                ConstructionClass -= 1;

            CalculateConstructionClassBaseOnConcreteClass();

            MinimalCover = MinimalCoverList[ConstructionClass - 1, exposure.SelectedIndex];

            cover.Text = Convert.ToString(Math.Max(Math.Max(AdhesionCover, MinimalCover), 10) + 10) + "mm";
        }



            private void CalculateConstructionClassBaseOnConcreteClass()
        {
            switch (exposure.SelectedIndex)
            {
                case 0:
                case 1:
                    if (strengthClass.SelectedIndex > 1)
                        ConstructionClass -= 1;
                    break;
                case 2:
                    if (strengthClass.SelectedIndex > 2)
                        ConstructionClass -= 1;
                    break;
                case 3:
                case 4:
                case 5:
                    if (strengthClass.SelectedIndex > 3)
                        ConstructionClass -= 1;
                    break;
                case 6:
                    if (strengthClass.SelectedIndex > 4)
                        ConstructionClass -= 1;
                    break;
                default:
                    break;
            }
        }
    }
}
