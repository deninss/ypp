using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        MainWindow mainWindow;
        public Authorization(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }
        public void ToComeIn(object sender, RoutedEventArgs e)
        {
            if (Login.Text.Length != 0 && Password.Text.Length != 0)
            {
                try
                {
                    DataTable result = Classes.DataBase.Select($"SELECT * FROM [Users] WHERE Login='{Login.Text}' AND Password='{Password.Text}'");
                    if (result.Rows.Count > 0)
                    {
                        User.Id = Convert.ToInt32(result.Rows[0]["Id"]);
                        User.Login = result.Rows[0]["Login"].ToString();
                        User.Password = result.Rows[0]["Password"].ToString();
                        User.Role = result.Rows[0]["Role"].ToString();
                        mainWindow.frame.Navigate(new Pages.Main(mainWindow));
                    }
                    else MessageBox.Show("Неверное имя пользователя или пароль.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Заполните все поля");

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Введите логин" || textBox.Text == "Введите пароль") textBox.Text = "";
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == Login) textBox.Text = "Введите логин";
                else if (textBox == Password) textBox.Text = "Введите пароль";
            }
        }


        public void TransitionRegistration(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Navigate(new Pages.Registration(mainWindow));
        }
    }
}

