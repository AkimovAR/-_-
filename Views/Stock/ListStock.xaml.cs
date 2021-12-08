using System.Windows;
using motoStore.DAL;
using motoStore.Models;

namespace motoStore.Views.Stock
{
    /// <summary>
    /// Interaction logic for ListStock.xaml
    /// </summary>
    public partial class ListStock : Window
    {
        DALStock dal;
        public ListStock()
        {
            InitializeComponent();
            dal = new DALStock();
            stockGrid.ItemsSource = dal.ShowALL();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddStock addStock = new AddStock();
            addStock.ShowDialog();
            updateDG();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (stockGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < stockGrid.SelectedItems.Count; i++)
                {
                    Models.Stock stock = stockGrid.SelectedItems[i] as Models.Stock;
                    if (stock != null)
                    {

                        EditStock editStock = new EditStock(stock.Id);
                        editStock.ShowDialog();

                    }
                }
            }
            updateDG();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (stockGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < stockGrid.SelectedItems.Count; i++)
                {
                    Models.Stock stock = stockGrid.SelectedItems[i] as Models.Stock;
                    if (stock != null)
                    {

                        if (dal.Remove(stock))
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
            stockGrid.ItemsSource = null;
            stockGrid.ItemsSource = dal.ShowALL();
        }
    }
}
