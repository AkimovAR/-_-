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
    class VM_GetEmployee : Notify
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
        DALEmployee dal;
        public VM_GetEmployee()
        {
            dal = new DALEmployee();
            Employees = dal.ShowALL();
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
        private List<Employee> employees;
        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }
        public void Choose(int id)
        {
            Id = id;
            MessageBox.Show("Сотрудник выбран");
        }
    }
}
