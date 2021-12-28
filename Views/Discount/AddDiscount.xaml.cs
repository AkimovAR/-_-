using System.Windows;
using motoStore.ViewModels;

namespace motoStore.Views.Discount
{
  
    public partial class AddDiscount : Window
    {
        public AddDiscount()
        {
            InitializeComponent();
            DataContext = new VM_Discount();  
        }

        
    }
}
