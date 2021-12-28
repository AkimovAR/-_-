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
    class Discount_E :Notify
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value;

                OnPropertyChanged("Id");
            }
        }
        private DateTime dateDiscount;
        public  DateTime DateDiscount
        {
            get { return dateDiscount; }
            set { dateDiscount = value;
                OnPropertyChanged("DateDiscount");
            }
        }
        private int sizeDiscount;
        public int SizeDiscount
        {
            get { return sizeDiscount; }
            set { sizeDiscount = value;
                OnPropertyChanged("SizeDiscount");
            }
        }
        private ObservableCollection<Discount_E> discount_list;
        public ObservableCollection<Discount_E> Discount_list
        {
            get
            {
                return discount_list;
            }
            set
            {
                discount_list = value;
                OnPropertyChanged("Discount_list");
            }
        }
        private void BikeModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Discount_list");
        }
    }
}
