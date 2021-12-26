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
using motoStore.DAL;

using motoStore.Models;

namespace motoStore.Views.BikeShop
{
    /// <summary>
    /// Interaction logic for AddShop.xaml
    /// </summary>
    public partial class AddShop : Window
    {
        DALShop dalshop;
        public AddShop()
        {
            InitializeComponent();
            dalshop = new DALShop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bikeshop shop = GetData();
            if (shop != null)
            {
                try
                {
                    dalshop.Add(shop);
                    MessageBox.Show("Запись успешно добавлнена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При добавлении обьекта в  произошла ошибка");
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private Bikeshop GetData()
        {

            Bikeshop shop = new Bikeshop();
            try
            {
                /*
             
             код для проверки
             но мне влом
             
             */
                string name = txtMotoshop_name.Text;
                string address = txtAddress.Text;
                string phone = txtPhone_number.Text;

                shop.Motoshop_name = name;
                shop.Address = address;
                shop.Phone_number = phone;

                return shop;


            }
            catch
            {
                MessageBox.Show("Не корректно введенные данные");
                return null;
            }
        }
    }
}
