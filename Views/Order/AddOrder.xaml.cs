using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using motoStore.DAL;
using System.Text.RegularExpressions;
using motoStore.ViewModels;

namespace motoStore.Views.Order
{
    public partial class AddOrder : Window
    {
      
        public AddOrder()
        {
            InitializeComponent();
            DataContext = new VM_Order();

        }

      
    }
}
