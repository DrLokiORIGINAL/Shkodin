using Shkodin.ClassFolder;
using Shkodin.DataFolder;
using Shkodin.PageFolder.AdminFolder;
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
    /// Логика взаимодействия для AddDirPage.xaml
    /// </summary>
    public partial class AddDirPage : Page
    {
        public AddDirPage()
        {
            InitializeComponent();
            SexCb.ItemsSource = DBEntities.GetContext()
             .Gender.ToList();
        }

        private void AddDirBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LNTB.Text))
            {
                MBClass.ErrorMB("Введите фамилию");
                LNTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(FNTB.Text))
            {
                MBClass.ErrorMB("Введите имя");
                FNTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PNTB.Text))
            {
                MBClass.ErrorMB("Введите номер телефона");
                PNTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(ETB.Text))
            {
                MBClass.ErrorMB("Введите почту");
                ETB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(YOETB.Text))
            {
                MBClass.ErrorMB("Введите почту");
                YOETB.Focus();
            }
            else if (SexCb.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите пол сотрудника");
                SexCb.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().Staff.Add(new Staff()
                    {
                        LastNameStaff = LNTB.Text,
                        FirstNameStaff = FNTB.Text,
                        MiddleNameStaff = MNTB.Text,
                        IdGender = Int32.Parse(SexCb.SelectedValue.ToString()),
                        PhoneNumberStaff = PNTB.Text,
                        EmailStaff = ETB.Text,
                        YearsOfExperience = YOETB.Text,
                    });
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InformationMB("Сотрудник успешно добавлен");
                    NavigationService.Navigate(new ListDirPage());
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }
    }
}
