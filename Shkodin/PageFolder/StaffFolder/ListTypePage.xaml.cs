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
using Type = Shkodin.DataFolder.Type;

namespace Shkodin.PageFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для ListTypePage.xaml
    /// </summary>
    public partial class ListTypePage : Page
    {
        public ListTypePage()
        {
            InitializeComponent();
            ListInLB.ItemsSource = DBEntities.GetContext().Type.ToList()
                .OrderBy(c => c.IdType);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListInLB.ItemsSource = DBEntities.GetContext()
                .Type.Where(u => u.IdType.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdType);
            if (ListInLB.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void AddTBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.StaffFolder.AddTypePage());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Type type = ListInLB.SelectedItem as Type;

            if (ListInLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    " комнату");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"выбранную комнату? " +
                    $"{type.IdType}?"))
                {
                    DBEntities.GetContext().Type
                        .Remove(ListInLB.SelectedItem as Type);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Выбранная комната удалена");
                    ListInLB.ItemsSource = DBEntities.GetContext()
                        .Type.ToList().OrderBy(u => u.IdType);
                }
            }
        }
    }
}
