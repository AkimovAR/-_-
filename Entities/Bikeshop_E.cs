using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motoStore.Entities
{
    class Bikeshop_E : E_Notifier
    {
       private int id;
       private string motoshop_name;
       private string address;
       private string phone_number;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Motoshop_name
        {
            get => motoshop_name;

            set
            {
                motoshop_name = value;
                OnPropertyChanged("Motoshop_name");
            }
        }
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public string Phone_number
        {
            get => phone_number;
            set
            {
                phone_number = value;
                OnPropertyChanged("Phone_number");
            }
        }
        private ObservableCollection<Bikeshop_E> bikeshop_list;
        public ObservableCollection<Bikeshop_E> Bikeshop_list
        {
            get
            {
                return bikeshop_list;
            }
            set
            {
                bikeshop_list = value;
                OnPropertyChanged("Bikeshop_list");
            }
        }
        private void BikeModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Bikeshop_list");
        }
    }
}
