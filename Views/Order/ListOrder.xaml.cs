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

namespace motoStore.Views.Order
{
    /// <summary>
    /// Interaction logic for ListOrder.xaml
    /// </summary>
    public partial class ListOrder : Window
    {
        DAL.DALOrder dal;
        public ListOrder()
        {
            InitializeComponent();
            dal = new DAL.DALOrder();
            updateDG();
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            if (ordersGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < ordersGrid.SelectedItems.Count; i++)
                {
                    Models.Order order = ordersGrid.SelectedItems[i] as Models.Order;
                    if (order != null)
                    {

                        OrderDetails orderDetails = new OrderDetails(order.Id);
                        orderDetails.ShowDialog();
                        break;
                    }
                }
            }
            updateDG();


           

        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            Order.AddOrder addOrder = new Order.AddOrder();
            addOrder.ShowDialog();
            updateDG();

        }
        private void updateDG()
        {
            ordersGrid.ItemsSource = null;
            ordersGrid.ItemsSource = dal.ShowALL();
        }
    }
}
