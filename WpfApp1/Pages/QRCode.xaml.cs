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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для QRCode.xaml
    /// </summary>
    public partial class QRCode : Window
    {
        MainWindow mainWindow;
        public QRCode(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            LoadQRCOde();
        }
        private void LoadQRCOde()
        {
            ImageQRCode.Source = Classes.QRCode.CreateBitmapCode(":)))))))))))))))))))))))))))))))))))))))))))))))))))");
        }
        public void TransitionBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
