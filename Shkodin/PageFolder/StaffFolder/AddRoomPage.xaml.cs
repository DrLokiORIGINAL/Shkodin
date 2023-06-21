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
    /// Логика взаимодействия для AddRoomPage.xaml
    /// </summary>
    public partial class AddRoomPage : Page
    {
        Room room = new Room();
        public AddRoomPage()
        {
            InitializeComponent();
        }

        private void AddRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomAdd();

                MBClass.InformationMB("Комната добавлена");
                NavigationService.Navigate(new ListRoomPage());
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            AddRoom();
        }

        private void RoomAdd()
        {
            try
            {
                var RoomAdd = new Room()
                {
                    PhotoRoom = ImaggeClass.ConvertImageToByteArray(selectedFileName),
                    NameRoom = NameRoomTB.Text,
                };
                DBEntities.GetContext().Room.Add(RoomAdd);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        string selectedFileName = "";

        private void AddRoom()
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
                    room.PhotoRoom = ImaggeClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImaggeClass.ConvertByteArrayToImage(room.PhotoRoom);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }
    }
}
