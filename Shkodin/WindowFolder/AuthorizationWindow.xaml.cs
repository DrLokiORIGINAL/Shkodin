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
using System.Windows.Shapes;

namespace Shkodin.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
                this.DragMove();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrEmpty(LoginTB.Text))
                {
                    MBClass.ErrorMB("Введите логин");
                    LoginTB.Focus();
                }
                if (string.IsNullOrEmpty(PasswordPB.Password))
                {
                    MBClass.ErrorMB("Введите пароль");
                    PasswordPB.Focus();
                }
                else
                {
                    try
                    {
                        var user = DBEntities.GetContext().User.FirstOrDefault
                            (u => u.NameUser == LoginTB.Text);
                        if (user == null)
                        {
                            MBClass.ErrorMB("Пользователь не найден");
                            LoginTB.Focus();
                            return;
                        }
                        if (user.PasswordUser != PasswordPB.Password)
                        {
                            MBClass.ErrorMB("Введен не правильный пароль");
                            PasswordPB.Focus();
                            return;
                        }
                        else
                        {
                            switch (user.IdRole)
                            {
                                case 1:
                                    new MainAdminWindow().Show();
                                    this.Close();
                                    break;

                                case 2:
                                    MainDirectorWindow dirWindow = new MainDirectorWindow();
                                    dirWindow.Show();
                                    this.Close();
                                    break;

                                case 3:
                                    MainStaffWindow StaffWindow = new MainStaffWindow();
                                    StaffWindow.Show();
                                    this.Close();
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MBClass.ErrorMB(ex);
                    }
                }
            }
        }
    }
}
