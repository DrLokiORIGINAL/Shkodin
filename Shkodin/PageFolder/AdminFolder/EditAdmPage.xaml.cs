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

namespace Shkodin.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для EditAdmPage.xaml
    /// </summary>
    public partial class EditAdmPage : Page
    {
        User user = new User();
        public EditAdmPage(User user)
        {
            InitializeComponent();
            DataContext = user;

            this.user.IdUser = user.IdUser;

            RoleCb.ItemsSource = DBEntities.GetContext()
                .Role.ToList();
        }

        private void EditAdmBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user = DBEntities.GetContext().User
                        .FirstOrDefault(u => u.IdUser == user.IdUser);
                user.NameUser = LoginTB.Text;
                user.PasswordUser = PasswordTB.Text;
                user.IdRole = Int32.Parse(
                    RoleCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InformationMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListAdmPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
