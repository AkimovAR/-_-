using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;
using motoStore.DAL;
using motoStore.ViewModels;

namespace motoStore.Views.Discount
{
    /// <summary>
    /// Interaction logic for ListDiscount.xaml
    /// </summary>
    public partial class ListDiscount : Window
    {
        public ListDiscount()
        {
            InitializeComponent();
            DataContext = new VM_Discount();
        }

       
    }
}
