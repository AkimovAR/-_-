using System.Windows;
using motoStore.ViewModels;

namespace motoStore.Views.Employee
{
    public partial class ListEmployee : Window
    {
        public ListEmployee()
        {
            InitializeComponent();
            DataContext = new VM_Employee();
        }
    }
}
