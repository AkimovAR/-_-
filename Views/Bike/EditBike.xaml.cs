using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using motoStore.DAL;
using motoStore.Models;
using motoStore.ViewModels;

namespace motoStore.Views
{
    /// <summary>
    /// Interaction logic for EditBike.xaml
    /// </summary>
    public partial class EditBike : Window
    {
        DALBike dao;
        Bike bike;
        
        public EditBike(int id)
        {
            InitializeComponent();
            DataContext = new VM_Bike(id);
        }

     
    }
}
