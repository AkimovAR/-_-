using motoStore.DAL;
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
    class VM_GetClient : Notify
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
        DALClient dal;
        public VM_GetClient()
        {
            dal = new DALClient();
            Clients = dal.ShowALL();
        }
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
        private List<Client> clients;
        public List<Client> Clients
        {
            get
            {
                return clients;
            }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }
        public void Choose(int id)
        {
            Id = id;
            MessageBox.Show("Клиент выбран");
        }
    }
}
