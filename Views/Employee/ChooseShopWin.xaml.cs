using motoStore.ViewModels;
using System.Windows;

namespace motoStore.Views.Employee
{
    /// <summary>
    /// Interaction logic for ChooseShopWin.xaml
    /// </summary>
    public partial class ChooseShopWin : Window
    {
        public ChooseShopWin()
        {
            InitializeComponent();
            DataContext = new VM_GetShop();
        }
    }
}
