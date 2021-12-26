using System.Windows;
using motoStore.DAL;
using motoStore.Models;

namespace motoStore.Views.BikeShop
{
    /// <summary>
    /// Interaction logic for ListShop.xaml
    /// </summary>
    public partial class ListShop : Window
    {
        DALShop DALShop;
        public ListShop()
        {
            InitializeComponent();
            DALShop = new DALShop();
            shopsGrid.ItemsSource = DALShop.ShowALL();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddShop addShop = new AddShop();
            addShop.ShowDialog();
            updateDG();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (shopsGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < shopsGrid.SelectedItems.Count; i++)
                {
                    Bikeshop shop = shopsGrid.SelectedItems[i] as Bikeshop;
                    if (shop != null)
                    {

                        EditShop editshop = new EditShop(shop.Id);
                        editshop.ShowDialog();

                    }
                }
            }
            updateDG();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (shopsGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < shopsGrid.SelectedItems.Count; i++)
                {
                    Bikeshop shop = shopsGrid.SelectedItems[i] as Bikeshop;
                    if (shop != null)
                    {

                        if (DALShop.Remove(shop.Id))
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
        private void updateDG()
        {
            shopsGrid.ItemsSource = null;
            shopsGrid.ItemsSource = DALShop.ShowALL();
        }
    }
}
