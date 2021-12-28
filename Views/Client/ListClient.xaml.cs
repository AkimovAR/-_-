using System.Windows;
using motoStore.DAL;
using motoStore.ViewModels;

namespace motoStore.Views.Client
{
    public partial class ListClient : Window
    {
        public ListClient()
        {
            InitializeComponent();
            DataContext = new VM_Client();
        }

    }
}
