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

namespace Shkodin.PageFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для AddInteriorPage.xaml
    /// </summary>
    public partial class AddInteriorPage : Page
    {
        Interior interior = new Interior();
        public AddInteriorPage()
        {
            InitializeComponent();
        }

        private void AddInteriorBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InteriorAdd();

                MBClass.InformationMB("Интерьер добавлен");
                NavigationService.Navigate(new ListInteriorPage());
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            AddInterior();
        }

        private void InteriorAdd()
        {
            try
            {
                var InteriorAdd = new Interior()
                {
                    PhotoInterior = ImaggeClass.ConvertImageToByteArray(selectedFileName),
                    NameInterior = NameInteriorTB.Text,
                };
                DBEntities.GetContext().Interior.Add(InteriorAdd);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        string selectedFileName = "";

        private void AddInterior()
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
                    interior.PhotoInterior = ImaggeClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImaggeClass.ConvertByteArrayToImage(interior.PhotoInterior);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }
    }
}
