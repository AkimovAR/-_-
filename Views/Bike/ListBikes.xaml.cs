using motoStore.DAL;
using motoStore.Models;
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

namespace motoStore.Views
{
    /// <summary>
    /// Interaction logic for ListBikes.xaml
    /// </summary>
    public partial class ListBikes : Window
    {
        DALBike dao;
        public ListBikes()
        {
            InitializeComponent();
            dao = new DALBike();
            bikesGrid.ItemsSource = dao.ShowALL();

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (bikesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < bikesGrid.SelectedItems.Count; i++)
                {
                    Bike bike = bikesGrid.SelectedItems[i] as Bike;
                    if (bike != null)
                    {

                        EditBike editBike = new EditBike(bike.Id);
                        editBike.ShowDialog();

                    }
                }
            }
            updateDG();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (bikesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < bikesGrid.SelectedItems.Count; i++)
                {
                    Bike bike = bikesGrid.SelectedItems[i] as Bike;
                    if (bike != null)
                    {

                        if (dao.Remove(bike))
                        {
                            MessageBox.Show("Запись успешно удалена");
                        }
                        else
                        {
                            MessageBox.Show("При удалении зписи возники ошибки");
                        }

                    }
                }
            }
            updateDG();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddBike addBike = new AddBike();
            addBike.ShowDialog();
            updateDG();
        }
        private void updateDG()
        {
            bikesGrid.ItemsSource = null;
            bikesGrid.ItemsSource = dao.ShowALL();
        }
    }
}
