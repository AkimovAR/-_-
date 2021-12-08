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
using System.Windows.Navigation;
using System.Windows.Shapes;
using motoStore.Views;
using motoStore.Views.BikeShop;
using motoStore.Views.Client;
using motoStore.Views.Discount;
using motoStore.Views.Employee;
using motoStore.Views.Order;
using motoStore.Views.Stock;

namespace motoStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(int input)
        {
            InitializeComponent();
            if (input == 1)
            {
                btnBikes.IsEnabled = true;
                btnBikeShops.IsEnabled = true;
                btnClients.IsEnabled = true;
                btnDiscount.IsEnabled = true;
                btnEmployees.IsEnabled = true;
                btnOrders.IsEnabled = true;
                btnStocks.IsEnabled = true;
            }
            else
            {
                btnBikes.IsEnabled = false;
                btnBikeShops.IsEnabled = false;
                btnClients.IsEnabled = false;
                btnDiscount.IsEnabled = false;
                btnEmployees.IsEnabled = false;
                btnOrders.IsEnabled = true;
                btnStocks.IsEnabled = false;
            }
        }

   
        private void btnBikes_Click(object sender, RoutedEventArgs e)
        {
            ListBikes listBikes = new ListBikes();
            listBikes.ShowDialog();
        }

        private void btnBikeShops_Click(object sender, RoutedEventArgs e)
        {
            ListShop listShop = new ListShop();
            listShop.ShowDialog();
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            ListEmployee listEmployee = new ListEmployee();
            listEmployee.ShowDialog();
        }

        private void btnDiscount_Click(object sender, RoutedEventArgs e)
        {
            ListDiscount listDiscount = new ListDiscount();
            listDiscount.ShowDialog();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            ListOrder listOrder = new ListOrder();
            listOrder.ShowDialog();
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            ListClient listClient = new ListClient();
            listClient.ShowDialog();
        }

        private void btnStocks_Click(object sender, RoutedEventArgs e)
        {
            ListStock listStock = new ListStock();
            listStock.ShowDialog();
        }
    }
}
