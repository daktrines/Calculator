using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void regularButtonClick(object sender, RoutedEventArgs e)
            => SendToInput(((Button)sender).Content.ToString());

        private void SendToInput(string content)
        {
            if (txtInput.Text == "0")
                txtInput.Text = "";

            txtInput.Text = $"{txtInput.Text}{content}";
        }

        //Заполнение цифр и знаков с клавиатуры
        private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            switch (e.Text)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "+":
                case "-":
                case "/":
                case "*":
                case ".": 
                    SendToInput(e.Text);
                    break;
            }
            Rez.Focus();
        }

        public static string Rezult(string str)
        {
            string value = new DataTable().Compute(str, null).ToString();
            return value;
        }

        private void Rez_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = txtInput.Text;
                if (Convert.ToString(((ContentControl)sender).Content) != "⌫" & Convert.ToString(((ContentControl)sender).Content) != "=")
                {
                    txtInput.Text += Convert.ToString(((ContentControl)sender).Content);
                }
                if (Convert.ToString(((ContentControl)sender).Content) == "⌫")
                {
                    txtInput.Text = txtInput.Text.Remove(txtInput.Text.Length - 1);
                    if (txtInput.Text == "")
                    txtInput.Text = "0";
                }
                if (Convert.ToString(((ContentControl)sender).Content) == "=")
                {
                    txtInput.Text = Rezult(str);
                }
                if (Convert.ToString(((ContentControl)sender).Content) == "CE")
                {
                    txtInput.Text = "0";
                }
            }
            catch
            {
                MessageBox.Show("Неверные данные!", "Ошибка", MessageBoxButton.OK,
                  MessageBoxImage.Error);
            }
        }
    }
}
