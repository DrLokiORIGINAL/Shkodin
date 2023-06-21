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
using Size = Shkodin.DataFolder.Size;

namespace Shkodin.PageFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для AddSizePage.xaml
    /// </summary>
    public partial class AddSizePage : Page
    {
        Size size = new Size();
        public AddSizePage()
        {
            InitializeComponent();
        }

        private void AddSizeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SizeAdd();

                MBClass.InformationMB("Размер комнаты добавлен");
                NavigationService.Navigate(new ListSizePage());
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            AddSize();
        }

        private void SizeAdd()
        {
            try
            {
                var SizeAdd = new Size()
                {
                    PhotoSize = ImaggeClass.ConvertImageToByteArray(selectedFileName),
                    NameSize = NameSizeTB.Text,
                };
                DBEntities.GetContext().Size.Add(SizeAdd);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        string selectedFileName = "";

        private void AddSize()
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
                    size.PhotoSize = ImaggeClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImaggeClass.ConvertByteArrayToImage(size.PhotoSize);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }
    }
}
