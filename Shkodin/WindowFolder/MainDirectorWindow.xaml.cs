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
    /// Логика взаимодействия для MainDirectorWindow.xaml
    /// </summary>
    public partial class MainDirectorWindow : Window
    {
        public MainDirectorWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new PageFolder.DirectorFolder.ListDirPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MBClass.QestionMB("Вы действительно хотите выйти из аккаунта?"))
            {
                new AuthorizationWindow().Show();
                Close();
            }
        }

        private void ListDirBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.DirectorFolder.ListDirPage());
        }

        private void AddDirBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageFolder.DirectorFolder.AddDirPage());
        }
    }
}
