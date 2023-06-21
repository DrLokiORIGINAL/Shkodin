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

namespace Shkodin.PageFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для ListDirPage.xaml
    /// </summary>
    public partial class ListDirPage : Page
    {
        public ListDirPage()
        {
            InitializeComponent();
            ListStaffDG.ItemsSource = DBEntities.GetContext().Staff.ToList()
                .OrderBy(c => c.IdStaff);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListStaffDG.ItemsSource = DBEntities.GetContext()
                .Staff.Where(u => u.LastNameStaff
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.LastNameStaff);
            if (ListStaffDG.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListStaffDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "пользователя для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditDirPage(ListStaffDG.SelectedItem as Staff));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = ListStaffDG.SelectedItem as Staff;

            if (ListStaffDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"сотрудника с фамилией " +
                    $"{staff.LastNameStaff}?"))
                {
                    DBEntities.GetContext().Staff
                        .Remove(ListStaffDG.SelectedItem as Staff);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Сотрудник удален");
                    ListStaffDG.ItemsSource = DBEntities.GetContext()
                        .Staff.ToList().OrderBy(u => u.IdStaff);
                }

            }
        }
    }
}
