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
    /// Логика взаимодействия для EditDirPage.xaml
    /// </summary>
    public partial class EditDirPage : Page
    {
        Staff staff = new Staff();
        public EditDirPage(Staff staff)
        {
            InitializeComponent();
            DataContext = staff;

            this.staff.IdStaff = staff.IdStaff;

            SexCb.ItemsSource = DBEntities.GetContext()
                .Gender.ToList();
        }

        private void EditDirBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                staff = DBEntities.GetContext().Staff
                        .FirstOrDefault(u => u.IdStaff == staff.IdStaff);
                staff.LastNameStaff = LNTB.Text;
                staff.FirstNameStaff = FNTB.Text;
                staff.MiddleNameStaff = MNTB.Text;
                staff.PhoneNumberStaff = PNTB.Text;
                staff.EmailStaff = ETB.Text;
                staff.IdGender = Int32.Parse(
                    SexCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListDirPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
