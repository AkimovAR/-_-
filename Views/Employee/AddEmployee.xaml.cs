using System.Windows;
using motoStore.ViewModels;

namespace motoStore.Views.Employee
{
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
            DataContext = new VM_Employee();
        }

       
    }
}
