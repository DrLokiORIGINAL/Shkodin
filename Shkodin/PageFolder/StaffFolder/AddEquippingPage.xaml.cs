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
    /// Логика взаимодействия для AddEquippingPage.xaml
    /// </summary>
    public partial class AddEquippingPage : Page
    {
        Equipping equipping = new Equipping();
        public AddEquippingPage()
        {
            InitializeComponent();
        }

        private void AddColorSchemeOfTheHallBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EquippingAdd();

                MBClass.InformationMB("Оснащение добавлено");
                NavigationService.Navigate(new ListEquippingPage());
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            AddEquipping();
        }

        private void EquippingAdd()
        {
            try
            {
                var EquippingAdd = new Equipping()
                {
                    PhotoEquipping = ImaggeClass.ConvertImageToByteArray(selectedFileName),
                    NameEquipping = NameEquippingTB.Text,
                };
                DBEntities.GetContext().Equipping.Add(EquippingAdd);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        string selectedFileName = "";

        private void AddEquipping()
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
                    equipping.PhotoEquipping = ImaggeClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImaggeClass.ConvertByteArrayToImage(equipping.PhotoEquipping);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }
    }
}
