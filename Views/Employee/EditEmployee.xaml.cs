using System;
using System.Windows;
using motoStore.ViewModels;

namespace motoStore.Views.Employee
{  
    public partial class EditEmployee : Window
    {      
        public EditEmployee(int Id)
        {
            InitializeComponent();
            DataContext = new VM_Employee(Id);
            
        }
    }
}
