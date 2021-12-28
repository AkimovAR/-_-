using motoStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace motoStore.Views.Order
{
    /// <summary>
    /// Interaction logic for SelectEmployee.xaml
    /// </summary>
    public partial class SelectEmployee : Window
    {
        public SelectEmployee()
        {
            InitializeComponent();
            DataContext = new VM_GetEmployee();
        }
    }
}
