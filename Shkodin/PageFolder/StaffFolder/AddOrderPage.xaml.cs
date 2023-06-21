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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        public AddOrderPage()
        {
            InitializeComponent();
            SizeCb.ItemsSource = DBEntities.GetContext()
                .Size.ToList();
            RoomCb.ItemsSource = DBEntities.GetContext()
                .Room.ToList();
            InteriorCb.ItemsSource = DBEntities.GetContext()
                .Interior.ToList();
            TypeCb.ItemsSource = DBEntities.GetContext()
                .Type.ToList();
            StaffCb.ItemsSource = DBEntities.GetContext()
                .Staff.ToList();
            ColorSchemeOfTheHallCb.ItemsSource = DBEntities.GetContext()
                .ColorSchemeOfTheHall.ToList();
            EquippingCb.ItemsSource = DBEntities.GetContext()
                .Equipping.ToList();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    DBEntities.GetContext().Order.Add(new Order()
                    {
                        IdSize = Int32.Parse(SizeCb.SelectedValue.ToString()),
                        IdRoom = Int32.Parse(RoomCb.SelectedValue.ToString()),
                        IdInterior = Int32.Parse(InteriorCb.SelectedValue.ToString()),
                        IdType = Int32.Parse(TypeCb.SelectedValue.ToString()),
                        WishesOrder = WOTB.Text,
                        IdStaff = Int32.Parse(StaffCb.SelectedValue.ToString()),
                        IdColorSchemeOfTheHall = Int32.Parse(ColorSchemeOfTheHallCb.SelectedValue.ToString()),
                        Equipment = EPTB.Text,
                        IdEquipping = Int32.Parse(EquippingCb.SelectedValue.ToString()),
                        AddonFromBuyer = AFBTB.Text,
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Заказ успешно добавлен");
                    NavigationService.Navigate(new ListDirPage());
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
        }
    }
}
