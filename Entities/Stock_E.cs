using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace motoStore.Entities
{
    class Stock_E: E_Notifier
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
        private string stock_name;
        public string Stock_name
        {
            get { return stock_name; }
            set { stock_name = value;
                OnPropertyChanged("Stock_name");
            }
        }
        private DateTime stock_date;
        public DateTime Stock_date
        {
            get { return stock_date; }
            set
            {
                stock_date = value;
                OnPropertyChanged("Stock_date");
            }
        }
        private string conditions;
        public string Conditions
        {
            get { return conditions; }

            set
            {
                conditions = value;
                OnPropertyChanged("Conditions");
            }
        }
        private ObservableCollection<Stock_E> stock_list;
        public ObservableCollection<Stock_E> Stock_list
        {
            get
            {
                return stock_list;
            }
            set
            {
                stock_list = value;
                OnPropertyChanged("Stock_list");
            }
        }
        private void StockModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Stock_list");
        }
    }
}
