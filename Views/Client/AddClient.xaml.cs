using System;

using System.Windows;

using motoStore.DAL;

using motoStore.Models;
using motoStore.ViewModels;

namespace motoStore.Views.Client
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
            DataContext = new VM_Client();
        }

     

        
    }
}
