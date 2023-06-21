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

namespace Shkodin.PageFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для ListInteriorPage.xaml
    /// </summary>
    public partial class ListInteriorPage : Page
    {
        public ListInteriorPage()
        {
            InitializeComponent();
            ListInLB.ItemsSource = DBEntities.GetContext().Interior.ToList()
                .OrderBy(c => c.IdInterior);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListInLB.ItemsSource = DBEntities.GetContext()
                .Interior.Where(u => u.IdInterior.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdInterior);
            if (ListInLB.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void AddEqBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.StaffFolder.AddInteriorPage());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Interior interior = ListInLB.SelectedItem as Interior;

            if (ListInLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    " интерьер");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"выбранный интерьер? " +
                    $"{interior.IdInterior}?"))
                {
                    DBEntities.GetContext().Interior
                        .Remove(ListInLB.SelectedItem as Interior);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Выбранный интерьер удалён");
                    ListInLB.ItemsSource = DBEntities.GetContext()
                        .Interior.ToList().OrderBy(u => u.IdInterior);
                }
            }
        }
    }
}
