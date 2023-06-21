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
using Size = Shkodin.DataFolder.Size;

namespace Shkodin.PageFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для ListSizePage.xaml
    /// </summary>
    public partial class ListSizePage : Page
    {
        public ListSizePage()
        {
            InitializeComponent();
            ListInLB.ItemsSource = DBEntities.GetContext().Size.ToList()
                .OrderBy(c => c.IdSize);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListInLB.ItemsSource = DBEntities.GetContext()
                .Size.Where(u => u.IdSize.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdSize);
            if (ListInLB.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void AddRBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.StaffFolder.AddSizePage());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Size size = ListInLB.SelectedItem as Size;

            if (ListInLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    " комнату");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"выбранную комнату? " +
                    $"{size.IdSize}?"))
                {
                    DBEntities.GetContext().Size
                        .Remove(ListInLB.SelectedItem as Size);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Выбранная комната удалена");
                    ListInLB.ItemsSource = DBEntities.GetContext()
                        .Size.ToList().OrderBy(u => u.IdSize);
                }
            }
        }
    }
}
