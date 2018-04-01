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

namespace QuizzEstilos_FinalWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void radioButtonSolucion_Checked(object sender, RoutedEventArgs e)
        {
            Style styleA = this.FindResource("EstiloA") as Style;
            Label1492.Style = styleA;
            LabelAlemania.Style = styleA;
        }

        private void radioButtonNoSolucion_Checked(object sender, RoutedEventArgs e)
        {
            Style styleB = this.FindResource("EstiloB") as Style;
            Label1492.Style = styleB;
            LabelAlemania.Style = styleB;
        }
    }
}
