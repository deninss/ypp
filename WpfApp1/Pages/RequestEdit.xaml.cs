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
    /// Логика взаимодействия для RequestEdit.xaml
    /// </summary>
    public partial class RequestEdit : Window
    {
        MainWindow mainWindow;
        public RequestEdit(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            LoadTypeOfFaul();
        }
        public void LoadTypeOfFaul()
        {
            DataTable item = Classes.DataBase.Select($"select * from [TypeOfFault]");
            foreach (DataRow row in item.Rows)
            {
                Classes.TypeOfFault typeOfFault = new Classes.TypeOfFault
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };
                mainWindow.TypeOfFaultList.Add(typeOfFault);
                comboBoxTypesOfFaults.Items.Add(typeOfFault.Name);
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Введите оборудование" || textBox.Text == "Введите описание проблемы") textBox.Text = "";
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == Equipment) textBox.Text = "Введите оборудование";
                else if (textBox == Description) textBox.Text = "Введите описание проблемы";
            }
        }
        public void AddRequest(object sender, RoutedEventArgs e)
        {
            if (Equipment.Text.Length != 0 && comboBoxTypesOfFaults.SelectedIndex != -1 && Description.Text.Length != 0)
            {
                try
                {
                    DateTime StartDate = DateTime.Now;
                    Random rand = new Random();

                    const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    Random random = new Random();
                    string Number = new string(Enumerable.Repeat(allowedChars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                    int TypesOfFaults = 0;
                    if (comboBoxTypesOfFaults.SelectedIndex == 0) TypesOfFaults = 1;
                    else if (comboBoxTypesOfFaults.SelectedIndex == 1) TypesOfFaults = 2;
                    else if (comboBoxTypesOfFaults.SelectedIndex == 2) TypesOfFaults = 3;
                    else if (comboBoxTypesOfFaults.SelectedIndex == 3) TypesOfFaults = 4;
                    else if (comboBoxTypesOfFaults.SelectedIndex == 4) TypesOfFaults = 5;
                    DataTable result = Classes.DataBase.Select($"insert into [Requests] (Number,StartDate,Equipment,TypeOfFault,Description,Client,Status) values ('{Number}','{StartDate}','{Equipment.Text}','{TypesOfFaults}','{Description.Text}','{Users.Id}','{1}')");
                    Classes.Request request = new Classes.Request
                    {
                        Number = Number,
                        StartDate = StartDate.ToString(),
                        Equipment = Equipment.Text,
                        TypeOfFault = TypesOfFaults.ToString(),
                        Description = Description.Text,
                        Client = User.Id.ToString(),
                        Status = 1.ToString(),
                    };
                    mainWindow.RequestItem.Add(request);
                    mainWindow.LoadItem();
                    MessageBox.Show("Запись успешно добавлена");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Заполните все поля");

        }
        public void TransitionBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
