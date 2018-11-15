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

namespace Animations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding b = new Binding("Height");
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor,
                                                     typeof(Window), 1);
            sButton.SetBinding(Button.ContentProperty, b);
        }
    }
}
