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
        public List<TypeOfFault> TypeOfFaultList = new List<TypeOfFault>();
        public MainWindow()
        {
            InitializeComponent();
            this.frame.Navigate(new Pages.Authorization(this));
        }

        public void LoadItem()
        {
            try
            {
                if (User.Role == "Клиент")
                {
                    try
                    {
                        RequestItem.Clear();
                        DataTable itemuser = Classes.DataBase.Select($"select * from [Requests] where Client = '{User.Id}'");
                        foreach (DataRow row in itemuser.Rows)
                        {
                            Classes.Request request = new Classes.Request
                            {
                                Id = Convert.ToInt32(row["Id"]),
                                Number = row["Number"].ToString(),
                                StartDate = row["StartDate"].ToString(),
                                EndDate = row["EndDate"].ToString(),
                                Equipment = row["Equipment"].ToString(),
                                TypeOfFault = row["TypeOfFault"].ToString(),
                                Description = row["Description"].ToString(),
                                Client = row["Client"].ToString(),
                                Performer = row["Performer"].ToString(),
                                Status = row["Status"].ToString(),
                                PerformerComment = row["PerformerComment"].ToString()
                            };
                            RequestItem.Add(request);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (User.Role == "Менеджер")
                {
                    try
                    {
                        RequestItem.Clear();
                        DataTable item = Classes.DataBase.Select($"select * from [Requests]");

                        foreach (DataRow row in item.Rows)
                        {
                            Classes.Request request = new Classes.Request
                            {
                                Id = Convert.ToInt32(row["Id"]),
                                Number = row["Number"].ToString(),
                                StartDate = row["StartDate"].ToString(),
                                EndDate = row["EndDate"].ToString(),
                                Equipment = row["Equipment"].ToString(),
                                TypeOfFault = row["TypeOfFault"].ToString(),
                                Description = row["Description"].ToString(),
                                Client = row["Client"].ToString(),
                                Performer = row["Performer"].ToString(),
                                Status = row["Status"].ToString(),
                                PerformerComment = row["PerformerComment"].ToString()
                            };
                            RequestItem.Add(request);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (User.Role == "Сотрудник")
                {
                    try
                    {
                        RequestItem.Clear();
                        DataTable item = Classes.DataBase.Select($"select * from [Requests] where Performer = '{User.Id}'");

                        foreach (DataRow row in item.Rows)
                        {
                            Classes.Request request = new Classes.Request
                            {
                                Id = Convert.ToInt32(row["Id"]),
                                Number = row["Number"].ToString(),
                                StartDate = row["StartDate"].ToString(),
                                EndDate = row["EndDate"].ToString(),
                                Equipment = row["Equipment"].ToString(),
                                TypeOfFault = row["TypeOfFault"].ToString(),
                                Description = row["Description"].ToString(),
                                Client = row["Client"].ToString(),
                                Performer = row["Performer"].ToString(),
                                Status = row["Status"].ToString(),
                                PerformerComment = row["PerformerComment"].ToString()
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
