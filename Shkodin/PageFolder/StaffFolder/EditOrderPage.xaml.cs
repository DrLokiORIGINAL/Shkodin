using Shkodin.ClassFolder;
using Shkodin.DataFolder;
using Shkodin.PageFolder.DirectorFolder;
using System;
using System.Collections;
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
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {
        Order order = new Order();
        public EditOrderPage(Order order)
        {
            InitializeComponent();
            DataContext = order;

            this.order.IdOrder = order.IdOrder;

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

        private void EditDirBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                order = DBEntities.GetContext().Order
                        .FirstOrDefault(u => u.IdOrder == order.IdOrder);
                order.IdSize = Int32.Parse(
                    SizeCb.SelectedValue.ToString());
                order.IdRoom = Int32.Parse(
                    RoomCb.SelectedValue.ToString());
                order.IdInterior = Int32.Parse(
                    InteriorCb.SelectedValue.ToString());
                order.IdType = Int32.Parse(
                    TypeCb.SelectedValue.ToString());
                order.WishesOrder = WOTB.Text;
                order.IdStaff = Int32.Parse(
                    StaffCb.SelectedValue.ToString());
                order.IdColorSchemeOfTheHall = Int32.Parse(
                    ColorSchemeOfTheHallCb.SelectedValue.ToString());
                order.Equipment = EPTB.Text;
                order.IdEquipping = Int32.Parse(
                    EquippingCb.SelectedValue.ToString());
                order.AddonFromBuyer = AFBTB.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListOrderPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
