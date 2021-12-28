using motoStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace motoStore.Views.Order
{
    /// <summary>
    /// Interaction logic for SelectBike.xaml
    /// </summary>
    public partial class SelectBike : Window
    {
        public SelectBike()
        {
            InitializeComponent();
            DataContext = new VM_GetBike();
        }
    }
}
