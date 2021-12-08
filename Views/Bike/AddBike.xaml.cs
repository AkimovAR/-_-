using motoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using motoStore.DAL;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace motoStore.Views
{
    /// <summary>
    /// Interaction logic for AddBike.xaml
    /// </summary>
    public partial class AddBike : Window
    {
        DALBike dao;
        public AddBike()
        {
            InitializeComponent();
            dao = new DALBike();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bike bike = GetData();
            if (bike != null)
            {
                try
                {
                   
                    dao.Add(bike);
                    MessageBox.Show("Запись успешно добавлнена");
                }
                catch (Exception ex)
                {
                       MessageBox.Show("При добавлении обьекта в произошла ошибка");

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            txtBrand.Text = "";
            txtModel.Text ="";
            txtColor.Text ="";
            txtCompl.Text ="";
            txtSpeed.Text ="";
            txtPower.Text ="";
            txtTransmission.Text="";
            txtTorq.Text="";
            txtAviable.Text="";
            txtPrice.Text="";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private Bike GetData()
        {

            Bike bike = new Bike();
            try
            {
              
                string brand =      txtBrand.Text;
                string model =      txtModel.Text;
                string color =      txtColor.Text;
                string compl =      txtCompl.Text;
                string speed =      txtSpeed.Text;
                string power =      txtPower.Text;
                string transmiss =  txtTransmission.Text;
                string torq =       txtTorq.Text;
                string aviable =    txtAviable.Text;
                string pricestr =   txtPrice.Text;
                decimal price = Decimal.Parse(pricestr);

                bike.Brand_name = brand;
                bike.Model_namre = model;
                bike.Color_name = color;
                bike.Complectation_name = compl;
                bike.Max_speed = speed;
                bike.Power = power;
                bike.Torque = torq;
                bike.Transmis_type = transmiss;
                bike.Availability = aviable;
                bike.Price = price;
                return bike;


            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
                return null;
            }
        }

        private void txtPower_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int iValue = -1;

            if (Int32.TryParse(textBox.Text, out iValue) == false)
            {
                TextChange textChange = e.Changes.ElementAt<TextChange>(0);
                int iAddedLength = textChange.AddedLength;
                int iOffset = textChange.Offset;

                textBox.Text = textBox.Text.Remove(iOffset, iAddedLength);
            }
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int iValue = -1;

            if (Int32.TryParse(textBox.Text, out iValue) == false)
            {
                TextChange textChange = e.Changes.ElementAt<TextChange>(0);
                int iAddedLength = textChange.AddedLength;
                int iOffset = textChange.Offset;

                textBox.Text = textBox.Text.Remove(iOffset, iAddedLength);
            }
        }

        private void txtSpeed_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int iValue = -1;

            if (Int32.TryParse(textBox.Text, out iValue) == false)
            {
                TextChange textChange = e.Changes.ElementAt<TextChange>(0);
                int iAddedLength = textChange.AddedLength;
                int iOffset = textChange.Offset;

                textBox.Text = textBox.Text.Remove(iOffset, iAddedLength);
            }
        }

        private void txtTorq_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int iValue = -1;

            if (Int32.TryParse(textBox.Text, out iValue) == false)
            {
                TextChange textChange = e.Changes.ElementAt<TextChange>(0);
                int iAddedLength = textChange.AddedLength;
                int iOffset = textChange.Offset;

                textBox.Text = textBox.Text.Remove(iOffset, iAddedLength);
            }
        }
    }
}
