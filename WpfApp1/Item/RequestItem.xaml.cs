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

namespace WpfApp1.Item
{
    /// <summary>
    /// Логика взаимодействия для RequestItem.xaml
    /// </summary>
    public partial class RequestItem : UserControl
    {
        MainWindow mainWindow;
        Classes.Request request;
        public RequestItem(MainWindow _mainWindow, Classes.Request _request)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            request = _request;
            LoadItemsRequest();
            if (User.Role == "Клиент")
            {
                ChangeRequest.Visibility = Visibility.Visible;
                Delete.Visibility = Visibility.Visible;
            }
            if (User.Role == "Менеджер")
            {
                ChangeArtist.Visibility = Visibility.Visible;
            }
            if (User.Role == "Сотрудник")
            {
                ChangeReport.Visibility = Visibility.Visible;
            }
        }
        public void LoadItemsRequest()
        {
            Number.Text = "Номер заявки: " + request.Number;
            StartDate.Text = "Дата начала: " + request.StartDate;
            EndDate.Text = "Дата конца: " + request.EndDate;
            Equipment.Text = "Оборудование: " + request.Equipment;
            TypeOfFault.Text = "Тип неисправности: " + request.TypeOfFault;
            Description.Text = "Описание проблемы: " + request.Description;
            Client.Text = "Клиент: " + request.Client;
            Performer.Text = "Исполнитель: " + request.Performer;
            Status.Text = "Статус: " + request.Status;
        }

        public void TransitionUpDateRequestManager(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Navigate(new Pages.RequestEdit(mainWindow, request));
        }
        public void DeleteRequst(object sender, RoutedEventArgs e)
        {
            DataTable item = Classes.DataBase.Select($"delete from [Requests] where Id = {request.Id}");
            MessageBox.Show("Вы успешно удалили заявку");
            mainWindow.LoadItem();
            mainWindow.frame.Navigate(new Pages.Main(mainWindow));
        }
        public void TransitionChangeReport(object sender, RoutedEventArgs e)
        {
            Pages.Report report = new Pages.Report(mainWindow,request);
            report.ShowDialog();
        }
    }
}
