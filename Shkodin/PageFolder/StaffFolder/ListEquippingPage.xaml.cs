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
    /// Логика взаимодействия для ListEquippingPage.xaml
    /// </summary>
    public partial class ListEquippingPage : Page
    {
        public ListEquippingPage()
        {
            InitializeComponent();
            ListEqLB.ItemsSource = DBEntities.GetContext().Equipping.ToList()
                .OrderBy(c => c.IdEquipping);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListEqLB.ItemsSource = DBEntities.GetContext()
                .Equipping.Where(u => u.IdEquipping.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdEquipping);
            if (ListEqLB.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void AddEqBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.StaffFolder.AddEquippingPage());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Equipping equipping = ListEqLB.SelectedItem as Equipping;

            if (ListEqLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    " оснащение");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"выбранное оснащение? " +
                    $"{equipping.IdEquipping}?"))
                {
                    DBEntities.GetContext().Equipping
                        .Remove(ListEqLB.SelectedItem as Equipping);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Выбранное оснащение удалено");
                    ListEqLB.ItemsSource = DBEntities.GetContext()
                        .Equipping.ToList().OrderBy(u => u.IdEquipping);
                }
            }
        }
    }
}
