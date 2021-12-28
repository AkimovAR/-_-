using motoStore.ViewModels;
using System.Windows;

namespace motoStore.Views.Employee
{
    public partial class EmployeeList : Window
    {
        public EmployeeList()
        {
            InitializeComponent();
            DataContext = new VM_Employee();
        }
    }
}
