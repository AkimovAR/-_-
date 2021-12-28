﻿using System;
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
using motoStore.DAL;

using motoStore.Models;
using motoStore.ViewModels;

namespace motoStore.Views.BikeShop
{
 
    public partial class AddShop : Window
    {
        public AddShop()
        {
            InitializeComponent();
            DataContext = new VM_BikeShop();
        }
    }
}
