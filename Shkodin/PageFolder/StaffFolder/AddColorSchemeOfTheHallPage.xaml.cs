using Microsoft.Win32;
using Shkodin.ClassFolder;
using Shkodin.DataFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Drawing.Imaging;
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
    /// Логика взаимодействия для AddColorSchemeOfTheHallPage.xaml
    /// </summary>
    public partial class AddColorSchemeOfTheHallPage : Page
    {
        ColorSchemeOfTheHall colorSchemeOfTheHall = new ColorSchemeOfTheHall();
        public AddColorSchemeOfTheHallPage()
        {
            InitializeComponent();
        }

        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }

        private void AddColorSchemeOfTheHallBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClothesAdd();

                MBClass.InformationMB("Цветовая гамма добавлена");
                NavigationService.Navigate(new ListColorSchemeOfTheHallPage());
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void ClothesAdd()
        {
            try
            {
                var colorSchemeOfTheHallAdd = new ColorSchemeOfTheHall()
                {
                    PhotoColorSchemeOfTheHall = ImaggeClass.ConvertImageToByteArray(selectedFileName),
                    NameColorSchemeOfTheHall = ColorSchemeOfTheHallTB.Text,
                };
                DBEntities.GetContext().ColorSchemeOfTheHall.Add(colorSchemeOfTheHallAdd);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        string selectedFileName = "";

        private void AddPhoto()
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
                    colorSchemeOfTheHall.PhotoColorSchemeOfTheHall = ImaggeClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImaggeClass.ConvertByteArrayToImage(colorSchemeOfTheHall.PhotoColorSchemeOfTheHall);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }
    }
}
