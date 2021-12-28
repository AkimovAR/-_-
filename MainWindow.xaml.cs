using System.Windows;
using motoStore.ViewModels;

namespace motoStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(int input)
        {
            InitializeComponent();          
            DataContext = new VM_MainWindow(new Models.Employee());
           
        }
    }
}
