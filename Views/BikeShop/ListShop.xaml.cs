using System.Windows;
using motoStore.DAL;
using motoStore.Models;
using motoStore.ViewModels;

namespace motoStore.Views.BikeShop
{
    /// <summary>
    /// Interaction logic for ListShop.xaml
    /// </summary>
    public partial class ListShop : Window
    {
        public ListShop()
        {
            InitializeComponent();
            DataContext = new VM_BikeShop();
        }

      
    }
}
