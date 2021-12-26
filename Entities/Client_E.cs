using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motoStore.Entities
{
    class Client_E :E_Notifier
    {
        private int id;
        public int Id 
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged("Id");
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged("Name");
            }
        }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        private string cliphonenumber;
        public string Cliphonenumber
        {
            get { return cliphonenumber; }
            set { cliphonenumber = value;
                OnPropertyChanged("Cliphonenumber");
            }
        }
        private string cliaddress;
        public string Cliaddress
        {
            get { return cliaddress; }
            set { cliaddress = value;
                OnPropertyChanged("Cliaddress");
            }
        }
        private string clipassport;
        public string Clipassport
        {
            get { return clipassport; }
            set { clipassport = value;
                OnPropertyChanged("Clipassport");
            }
        }
        private int clidiscount;
        public int Clidiscount
        {
            get { return clidiscount; }
            set { clidiscount = value;

                OnPropertyChanged("Clidiscount");
            }
        }
    
    private ObservableCollection<Client_E> clients_list;
    public ObservableCollection<Client_E> Clients_list
    {
        get
        {
            return clients_list;
        }
        set
        {
            clients_list = value;
            OnPropertyChanged("Clients_list");
        }
    }
    private void BikeModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged("Clients_list");
    }
}
}
