using motoStore.DAL;
using motoStore.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace motoStore.ViewModels
{
    class VM_GetBike : Notify
    {
        private ICommand choosecmd;

        public ICommand ChooseCommand
        {
            get
            {
                if (choosecmd == null)
                {
                    choosecmd = new RelCommand(param => Choose((int)param), null);
                }
                return choosecmd;
            }
        }
        DALBike dal;
        public VM_GetBike()
        {
            dal = new DALBike();
            Bikes = dal.ShowALL();
        }
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Bike_id");
            }
        }
        private List<Bike> bikes;
        public List<Bike> Bikes
        {
            get
            {
                return bikes;
            }
            set
            {
                bikes = value;
                OnPropertyChanged("Bikes");
            }
        }
        public void Choose(int id)
        {
            Id = id;
            MessageBox.Show("Мотоцикл выбран");
        }

    }
}
