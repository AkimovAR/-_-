using motoStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motoStore.Entities
{
    class Order_E : Notify
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
        private string bike_name;
        public string Bike_name
        {
            get
            {
                return bike_name;
            }
            set
            {
                bike_name = value;
                OnPropertyChanged("Bike_name");
            }
        }
        private int employee_code;
        public int Employee_code
        {
            get { return employee_code; }
            set { employee_code = value; OnPropertyChanged("Employee_code"); }
        }
        private string employee_name;
        public string Employee_name
        {
            get { return employee_name; }
            set
            {
                employee_name = value;
                OnPropertyChanged("Employee_name");
            }
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
        private string client_name;
        public string Client_name
        {
            get { return client_name; }
            set
            {
                client_name = value;
                OnPropertyChanged("Client_name"); ;
            }
        }
        private string stock_name;
        public string Sock_name
        {
            get
            {
                return stock_name;
            }
            set
            {
                stock_name = value;
                OnPropertyChanged("Stock_name");
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
