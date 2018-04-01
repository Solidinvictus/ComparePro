using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Calculadora_FinalWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double resultado;
        double numero1;
        double numero2;
        bool correct;
        public MainWindow()
        {
            InitializeComponent();
        }

        //SUMA
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                MessageBox.Show("Debes ingresar el primer numero!");
            }
            else if (string.IsNullOrEmpty(TextBox2.Text))
            {
                MessageBox.Show("Debes ingresar el segundo numero!");
            }
            else
            {
                correct = Double.TryParse(TextBox1.Text, out numero1);

                correct = Double.TryParse(TextBox2.Text, out numero2);
                if (correct)
                {
                    resultado = numero1 + numero2;
                    TextBoxRes.Text = resultado.ToString();
                }
            }

        }

        //Metodo para prevenir entrada de cualquier cosa que no sea numeros
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");     //Numeros decimales solo, no se puede teclear simbolos ni letras
            //Regex regex = new Regex("^ (\\d | -) ? (\\d |,)*\\,?\\d *$");
            //Regex regex = new Regex("[^0-9]+(^,");


            e.Handled = regex.IsMatch(e.Text);
        }

        //MULTIPLICACION
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                MessageBox.Show("Debes ingresar el primer numero!");
            }
            else if (string.IsNullOrEmpty(TextBox2.Text))
            {
                MessageBox.Show("Debes ingresar el segundo numero!");
            }
            else
            {
                correct = Double.TryParse(TextBox1.Text, out numero1);

                correct = Double.TryParse(TextBox2.Text, out numero2);
                if (correct)
                {

                    resultado = numero1 * numero2;
                    TextBoxRes.Text = resultado.ToString();
                }
            }
        }
        //RESTA
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                MessageBox.Show("Debes ingresar el primer numero!");
            }
            else if (string.IsNullOrEmpty(TextBox2.Text))
            {
                MessageBox.Show("Debes ingresar el segundo numero!");
            }
            else
            {
                correct = Double.TryParse(TextBox1.Text, out numero1);

                correct = Double.TryParse(TextBox2.Text, out numero2);
                if (correct)
                {

                    resultado = numero1 - numero2;
                    TextBoxRes.Text = resultado.ToString();
                }
            }
        }

        //DIVISION
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                MessageBox.Show("Debes ingresar el primer numero!");
            }
            else if (string.IsNullOrEmpty(TextBox2.Text))
            {
                MessageBox.Show("Debes ingresar el segundo numero!");
            }
            else
            {
                correct = Double.TryParse(TextBox1.Text, out numero1);

                correct = Double.TryParse(TextBox2.Text, out numero2);
                if (correct && numero2 != 0)
                {

                    resultado = numero1 / numero2;
                    TextBoxRes.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("El segundo numero no puede ser 0!");
                }
            }
        }

        //BORRADO
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = "";

            TextBox2.Text = "";

            TextBoxRes.Text = "";

        }

        //RAIZ CUADRADA
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text))
            {
                MessageBox.Show("Debes ingresar un numero!");
            }
            else
            {
                correct = Double.TryParse(TextBox1.Text, out numero1);

                bool correct2 = Double.TryParse(TextBox2.Text, out numero2);
                if (correct || correct2)
                {
                    if (string.IsNullOrEmpty(TextBox2.Text))
                    {
                        resultado = Math.Sqrt(numero1);
                        TextBoxRes.Text = resultado.ToString();
                    }
                    else if (string.IsNullOrEmpty(TextBox1.Text))
                    {
                        resultado = Math.Sqrt(numero2);
                        TextBoxRes.Text = resultado.ToString();
                    }
                    else if(numero1 <= 0 || numero2 <= 0)
                    {
                        MessageBox.Show("No se puede ingreasar numeros negativos para esta operacion");
                    }
                    else
                    {

                        resultado = Math.Sqrt(numero1);
                        TextBoxRes.Text = resultado.ToString();
                        MessageBox.Show("Hay dos numeros ingresados, el resultado es del primer numero!");
                    }
                }
              
            }
        }

        //POTENCIA 
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                MessageBox.Show("Debes ingresar el primer numero!");
            }
            else if (string.IsNullOrEmpty(TextBox2.Text))
            {
                MessageBox.Show("Debes ingresar el segundo numero!");
            }
            else
            {
                correct = Double.TryParse(TextBox1.Text, out numero1);

                correct = Double.TryParse(TextBox2.Text, out numero2);
                if (correct)
                {
                    resultado = Math.Pow(numero1, numero2);
                    TextBoxRes.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("Hay que ingresar correctamente los numeros!");
                }
            }
        }
    }
}
