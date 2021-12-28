
using System.Windows;
using motoStore.ViewModels;

namespace motoStore.Views.BikeShop
{
    public partial class EditShop : Window
    {
        public EditShop(int Id)
        {
            InitializeComponent();
            DataContext = new VM_BikeShop(Id);
        }
    }
}
