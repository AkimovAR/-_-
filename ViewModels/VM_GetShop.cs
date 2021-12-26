using motoStore.DAL;
using motoStore.Entities;
using motoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace motoStore.ViewModels
{
    class VM_GetShop : E_Notifier
    {
        private ICommand choosecmd;

        public ICommand ChooseCommand
        {
            get
            {
                if(choosecmd == null)
                {
                    choosecmd = new RelCommand(param => Choose((int)param), null);
                }
                return choosecmd;
            }
        }
        DALShop dal;
        public VM_GetShop()
        {
            dal = new DALShop();
            Bikeshops = dal.ShowALL();
        }
        private int shop_id;
        public int Shop_id
        {
            get { return shop_id; }
            set
            {
                shop_id = value;
                OnPropertyChanged("Shop_id");
            }
        }
        private List<Bikeshop> bikeShops;
        public List<Bikeshop> Bikeshops
        {
            get
            {
                return bikeShops;
            }
            set
            {
                bikeShops = value;
                OnPropertyChanged("Bike_shops");
            }
        }
        public void Choose(int id)
        {
            Shop_id = id;
            MessageBox.Show("Магазин выбран");
        }

    }
}
