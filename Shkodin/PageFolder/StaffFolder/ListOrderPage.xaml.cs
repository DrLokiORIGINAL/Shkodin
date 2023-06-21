using Shkodin.ClassFolder;
using Shkodin.DataFolder;
using Shkodin.PageFolder.DirectorFolder;
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
    /// Логика взаимодействия для ListOrderPage.xaml
    /// </summary>
    public partial class ListOrderPage : Page
    {
        public ListOrderPage()
        {
            InitializeComponent();
            ListOrderDG.ItemsSource = DBEntities.GetContext().Order.ToList()
                .OrderBy(c => c.IdOrder);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListOrderDG.ItemsSource = DBEntities.GetContext()
                .Order.Where(u => u.IdOrder.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdOrder);
            if (ListOrderDG.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListOrderDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "заказ для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditOrderPage(ListOrderDG.SelectedItem as Order));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Order order = ListOrderDG.SelectedItem as Order;

            if (ListOrderDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    " заказ");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"выбранный заказ? " +
                    $"{order.IdOrder}?"))
                {
                    DBEntities.GetContext().Order
                        .Remove(ListOrderDG.SelectedItem as Order);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Выбранный заказ удален");
                    ListOrderDG.ItemsSource = DBEntities.GetContext()
                        .Order.ToList().OrderBy(u => u.IdOrder);
                }
            }
        }
    }
}
