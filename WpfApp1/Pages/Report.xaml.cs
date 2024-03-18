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
using WpfApp1.Classes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        MainWindow mainWindow;
        Classes.Request request;
        public Report(MainWindow _mainWindow, Classes.Request _request)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            request = _request;
        }
        public void TransitionBack(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Navigate(new Pages.Main(mainWindow));
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Введите материалы которые вы потратили на эту заявку" || textBox.Text == "Введите стоимость") textBox.Text = "";
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == Materials) textBox.Text = "Введите материалы которые вы потратили на эту заявку";
                else if (textBox == Price) textBox.Text = "Введите стоимость";
            }
        }
        public void CreateReport(object sender, RoutedEventArgs e)
        {
            if (Materials.Text.Length != 0 && Price.Text.Length != 0 && Materials.Text != "Введите материалы которые вы потратили на эту заявку" && Price.Text != "Введите стоимость")
            {
                try
                {
                    string materials = Materials.Text;
                    string price = Price.Text;
                    PDF.CreatePDF(request.Number.ToString(), DateTime.Now.ToString(), request.Equipment, (DateTime.Parse(request.EndDate) - DateTime.Parse(request.StartDate)).ToString(), materials, price);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Заполните все поля");
        }
    }
}
