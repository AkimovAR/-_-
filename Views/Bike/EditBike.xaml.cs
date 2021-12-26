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
using System.Windows;
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
            DataContext =new VM_Bike();
            dao = new DALBike();
            bike = dao.Show(id);
            initVaues();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetValues();
            if (dao.Edit(bike))
            {
                MessageBox.Show("Запись успешно обновлена");
            }
            else
            {
                MessageBox.Show("При изменении записи возникли ошибки");
            }

        }

        void initVaues()
        {
            if (bike != null)
            {
                txtBrand.Text = bike.Brand_name;
                txtModel.Text = bike.Model_name;
                txtColor.Text = bike.Color_name;
                txtCompl.Text = bike.Complectation_name;
                 txtSpeed.Text = bike.Max_speed;
                txtPower.Text = bike.Power;
                txtTransmission.Text = bike.Transmis_type;
                txtTorq.Text = bike.Torque;
                txtAviable.Text = bike.Availability;
                txtPrice.Text = bike.Price.ToString();
            }
          
        }
        void SetValues()
        {
            /*нужно проверка вводных значений*/
            string brand = txtBrand.Text;
            string model = txtModel.Text;
            string color = txtColor.Text;
            string compl = txtCompl.Text;
            string speed = txtSpeed.Text;
            string power = txtPower.Text;
            string transmiss = txtTransmission.Text;
            string torq = txtTorq.Text;
            string aviable = txtAviable.Text;
            string pricestr = txtPrice.Text;
            decimal price = Decimal.Parse(pricestr);

            bike.Brand_name = brand;
            bike.Model_name = model;
            bike.Color_name = color;
            bike.Complectation_name = compl;
            bike.Max_speed = speed;
            bike.Power = power;
            bike.Torque = torq;
            bike.Transmis_type = transmiss;
            bike.Availability = aviable;
            bike.Price = price;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtBrand.Text = "";
            txtModel.Text = "";
            txtColor.Text = "";
            txtCompl.Text = "";
            txtSpeed.Text = "";
            txtPower.Text = "";
            txtTransmission.Text = "";
            txtTorq.Text = "";
            txtAviable.Text = "";
            txtPrice.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
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
    }
}
