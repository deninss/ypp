using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Request> RequestItem = new List<Request>();
        public MainWindow()
        {
            InitializeComponent();
            this.frame.Navigate(new Pages.Authorization(this));
        }
        public void LoadItem()
        {
            try
            {
                RequestItem.Clear();
                DataTable item = Classes.DataBase.Select($"select * from [Requests]");

                foreach (DataRow row in item.Rows)
                {
                    Classes.Request request = new Classes.Request
                    {
                        Number = "Номер заявки: " + Convert.ToInt32(row["Number"]),
                        StartDate = "Дата начала: " + Convert.ToString(row["StartDate"]),
                        EndDate = "Дата конца: " + Convert.ToString(row["EndDate"]),
                        Equipment = "Оборудование: " + row["Equipment"].ToString(),
                        TypeOfFault = " Тип неисправности: " + Convert.ToInt32(row["TypeOfFault"]),
                        Description = "Описание проблемы: " + row["Description"].ToString(),
                        Client = "Клиент: " + Convert.ToInt32(row["Client"]),
                        Performer = "Исполнитель: " + Convert.ToInt32(row["Performer"]),
                        Status = "Статус: " + row["Status"].ToString(),
                        PerformerComment = "Статус: " + row["Status"].ToString()
                    };
                    RequestItem.Add(request);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
