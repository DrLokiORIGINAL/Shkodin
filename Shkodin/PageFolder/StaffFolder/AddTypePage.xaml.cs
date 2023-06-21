using Microsoft.Win32;
using Shkodin.ClassFolder;
using Shkodin.DataFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddTypePage.xaml
    /// </summary>
    public partial class AddTypePage : Page
    {
        Type type = new Type();
        public AddTypePage()
        {
            InitializeComponent();
        }

        private void AddTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TypeAdd();

                MBClass.InformationMB("Тип комнаты добавлен");
                NavigationService.Navigate(new ListTypePage());
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            AddType();
        }

        private void TypeAdd()
        {
            try
            {
                var TypeAdd = new Type()
                {
                    PhotoType = ImaggeClass.ConvertImageToByteArray(selectedFileName),
                    NameType = NameTypeTB.Text,
                };
                DBEntities.GetContext().Type.Add(TypeAdd);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        string selectedFileName = "";

        private void AddType()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                    "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    type.PhotoType = ImaggeClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImaggeClass.ConvertByteArrayToImage(type.PhotoType);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }
    }
}
