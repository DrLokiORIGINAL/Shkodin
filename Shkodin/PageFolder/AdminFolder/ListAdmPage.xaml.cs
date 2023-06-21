using Shkodin.ClassFolder;
using Shkodin.DataFolder;
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

namespace Shkodin.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для ListAdmPage.xaml
    /// </summary>
    public partial class ListAdmPage : Page
    {
        public ListAdmPage()
        {
            InitializeComponent();
            ListAdminDG.ItemsSource = DBEntities.GetContext().User.ToList()
                .OrderBy(c => c.IdUser);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListAdminDG.ItemsSource = DBEntities.GetContext()
                .User.Where(u => u.NameUser
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.NameUser);
            if (ListAdminDG.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "пользователя для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditAdmPage(ListAdminDG.SelectedItem as User));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            User user = ListAdminDG.SelectedItem as User;

            if (ListAdminDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"пользователя с логином " +
                    $"{user.NameUser}?"))
                {
                    DBEntities.GetContext().User
                        .Remove(ListAdminDG.SelectedItem as User);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Пользователь удален");
                    ListAdminDG.ItemsSource = DBEntities.GetContext()
                        .User.ToList().OrderBy(u => u.NameUser);
                }

            }
        }
    }
}
