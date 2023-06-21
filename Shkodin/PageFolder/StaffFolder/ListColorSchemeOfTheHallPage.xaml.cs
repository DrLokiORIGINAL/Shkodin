using Shkodin.ClassFolder;
using Shkodin.DataFolder;
using Shkodin.WindowFolder;
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
    /// Логика взаимодействия для ListColorSchemeOfTheHallPage.xaml
    /// </summary>
    public partial class ListColorSchemeOfTheHallPage : Page
    {
        public ListColorSchemeOfTheHallPage()
        {
            InitializeComponent();
            ListColorSchemeLB.ItemsSource = DBEntities.GetContext().ColorSchemeOfTheHall.ToList()
                .OrderBy(c => c.IdColorSchemeOfTheHall);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListColorSchemeLB.ItemsSource = DBEntities.GetContext()
                .ColorSchemeOfTheHall.Where(u => u.IdColorSchemeOfTheHall.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdColorSchemeOfTheHall);
            if (ListColorSchemeLB.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            ColorSchemeOfTheHall colorSchemeOfTheHall = ListColorSchemeLB.SelectedItem as ColorSchemeOfTheHall;

            if (ListColorSchemeLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите цветовую" +
                    " гамму зала для удаления");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"выбранную цветовую гамму зала? " +
                    $"{colorSchemeOfTheHall.IdColorSchemeOfTheHall}?"))
                {
                    DBEntities.GetContext().ColorSchemeOfTheHall
                        .Remove(ListColorSchemeLB.SelectedItem as ColorSchemeOfTheHall);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Выбранная цветовая гамма зала удалена");
                    ListColorSchemeLB.ItemsSource = DBEntities.GetContext()
                        .ColorSchemeOfTheHall.ToList().OrderBy(u => u.IdColorSchemeOfTheHall);
                }
            }
        }

        private void AddColorBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.StaffFolder.AddColorSchemeOfTheHallPage());
        }
    }
}
