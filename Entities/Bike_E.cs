using motoStore.Entities;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace motoStore.Models
{
    class Bike_E : E_Notifier
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
        private string brand_name;
        public string Brand_name
        {
            get { return brand_name; }
            set
            {
                brand_name = value;
                OnPropertyChanged("Brand_name");
            }
        }
        private string model_name;
        public string Model_name
        {
            get { return model_name; }
            set { model_name = value;
                OnPropertyChanged("Model_name");
            }
        }
        private string color_name;
        public string Color_name
        {
            get { return color_name; }
            set { color_name = value;
                OnPropertyChanged("Color_name");
            }
        }
        private string complectation_name;
        public string Complectation_name
        {
            get { return complectation_name; }
            set { complectation_name = value;
                OnPropertyChanged("Complectation_name");
            }
        }
        private string max_speed;
        public string Max_speed
        {
            get { return max_speed; }
            set { max_speed = value;
                OnPropertyChanged("Max_speed");
            }
        }
        private string power;
        public string Power
        {
            get { return power; }
            set
            {
                power = value;
                OnPropertyChanged("Power");
            }
        }
        private string torque;
        public string Torque
        {
            get { return torque; }
            set
            {
                torque = value;
                OnPropertyChanged("Torque");
            }
        }
        private string transmis_type;
        public string Transmis_type
        {
            get { return transmis_type; }
            set { transmis_type = value;

                OnPropertyChanged("Transmis_type");
            }
        }
        private string availability;
        public string Availability
        {
            get { return availability; }
            set
            {
                availability = value;
                OnPropertyChanged("Availability");
            }
        }
        private decimal price;
        public decimal Price
        {
            get { return price; }
            set { price = value;
                OnPropertyChanged("Price");
            }
        }
        private ObservableCollection<Bike_E> bike_list;
        public ObservableCollection<Bike_E> Bike_list
        {
            get
            {
                return bike_list;
            }
            set
            {
                bike_list = value;
                OnPropertyChanged("Bike_list");
            }
        }
        private void BikeModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Bike_list");
        }
    }
}
