using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motoStore.Entities
{
    class Order_E : E_Notifier
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        private DateTime order_date;
        public DateTime Order_date
        {
            get { return order_date; }
            set
            {
                order_date = value;
                OnPropertyChanged("Order_date");
            }
        }
        private string order_price;
        public string Order_price
        {
            get { return order_price; }
            set { order_price = value;
                OnPropertyChanged("Order_price");
            }
        }
        private int stock_code;
        public int Stock_code
        {
            get { return stock_code; }
            set { stock_code = value;
                OnPropertyChanged("Stock_code");
            }
        }
        private int bike_code;
        public int Bike_code
        {
            get { return bike_code; }
            set
            {
                bike_code = value;
                OnPropertyChanged("Bike_code");
            }
        }
        private int employee_code;
        public int Employee_code
        {
            get { return employee_code; }
            set { employee_code = value; OnPropertyChanged("Employee_code"); }
        }
        private int client_code;
        public int Client_code
        {
            get { return client_code; }
            set
            {
                client_code = value;
                OnPropertyChanged("Client_code");
            }
        }
        private ObservableCollection<Order_E> order_list;
        public ObservableCollection<Order_E> Order_list
        {
            get
            {
                return order_list;
            }
            set
            {
                order_list = value;
                OnPropertyChanged("Order_list");
            }
        }
        private void OrderModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Order_list");
        }
    }
}
