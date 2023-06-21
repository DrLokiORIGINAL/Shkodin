using Shkodin.ClassFolder;
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
using System.Windows.Shapes;

namespace Shkodin.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainStaffWindow.xaml
    /// </summary>
    public partial class MainStaffWindow : Window
    {
        public MainStaffWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new PageFolder.StaffFolder.ListOrderPage());
        }

        private void ListOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffFolder.ListOrderPage());
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffFolder.AddOrderPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MBClass.QestionMB("Вы действительно хотите выйти из аккаунта?"))
            {
                new AuthorizationWindow().Show();
                Close();
            }
        }

        private void ListColorSchemeOfTheHallBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffFolder.ListColorSchemeOfTheHallPage());
        }

        private void ListSizeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffFolder.ListSizePage());
        }

        private void ListInteriorBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffFolder.ListInteriorPage());
        }

        private void ListTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffFolder.ListTypePage());
        }

        private void ListEquippingBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffFolder.ListEquippingPage());
        }

        private void ListRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.StaffFolder.ListRoomPage());
        }
    }
}
