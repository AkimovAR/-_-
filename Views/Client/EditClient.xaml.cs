using motoStore.ViewModels;
using System.Windows;
namespace motoStore.Views.Client
{
    /// <summary>
    /// Interaction logic for EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
      
        public EditClient(int Id)
        {
            InitializeComponent();
            DataContext = new VM_Client(Id);
        }
    }
}
