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
    /// Логика взаимодействия для ListRoomPage.xaml
    /// </summary>
    public partial class ListRoomPage : Page
    {
        public ListRoomPage()
        {
            InitializeComponent();
            ListInLB.ItemsSource = DBEntities.GetContext().Room.ToList()
                .OrderBy(c => c.IdRoom);
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListInLB.ItemsSource = DBEntities.GetContext()
                .Room.Where(u => u.IdRoom.ToString()
                .StartsWith(SearchTb.Text))
                .ToList().OrderBy(u => u.IdRoom);
            if (ListInLB.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void AddRBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.StaffFolder.AddRoomPage());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Room room = ListInLB.SelectedItem as Room;

            if (ListInLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    " комнату");
            }
            else
            {
                if (MBClass.QestionMB("Удалить " +
                    $"выбранную комнату? " +
                    $"{room.IdRoom}?"))
                {
                    DBEntities.GetContext().Room
                        .Remove(ListInLB.SelectedItem as Room);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InformationMB("Выбранная комната удалена");
                    ListInLB.ItemsSource = DBEntities.GetContext()
                        .Room.ToList().OrderBy(u => u.IdRoom);
                }
            }
        }
    }
}
