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
using System.Text.RegularExpressions;

namespace motoStore.Views.Order
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        DALBike dalBike;
        DALClient dalClient;
        DALEmployee dalEmployee;
        DALDiscount dalDiscount;
        DALStock dalStock;
        DALOrder dalOrder;
        public AddOrder()
        {
            InitializeComponent();
            dalBike = new DALBike();
            dalClient = new DALClient();
            dalEmployee = new DALEmployee();
            dalDiscount = new DALDiscount();
            dalStock = new DALStock();
            dalOrder = new DALOrder();
            SetClientcmb();
            SetEmployeecmb();
            SetBikecmb();
            SetStock();

        }

        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idclient = GetValueFromcmb(cmbClient);
                int idBike = GetValueFromcmb(cmbBike);
                int idemployee = GetValueFromcmb(cmbEmployee);
                int idstock = GetValueFromcmb(cmbStock);
                if (idBike > 0 && idclient > 0 && idemployee > 0 && idstock>0)
                {
                    Models.Order order = new Models.Order();
                    order.Bike_code = idBike;
                    order.Client_code = idclient;
                    order.Employee_code = idemployee;
                    order.Stock_code = idstock;
                    Models.Bike bike = dalBike.ShowALL().FirstOrDefault(n => n.Id == idBike);
                    order.Order_price = bike.Price.ToString();
                    DateTime selectedDate = dp.SelectedDate.Value;
                    List<Models.Discount> discounts = new List<Models.Discount>();
                    discounts = dalDiscount.ShowALL();
                    decimal lowerprice = 0;
                    order.Order_date = dp.SelectedDate.Value;
                    foreach (var item in discounts)
                    {
                        if (item.DateDiscount.DayOfYear == selectedDate.DayOfYear)
                        {
                            lowerprice = (bike.Price / 100) * item.SizeDiscount;
                            order.Order_price = (bike.Price - lowerprice).ToString();
                            break;
                        }
                    }
                    dalOrder.Add(order);
                    MessageBox.Show("Запись добавлена успешно");
                }
                else
                {
                    MessageBox.Show("Не корректный ввод данных");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Возникли ошибки при добавлении записи");
            }
           

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        void SetClientcmb()
        {
            List<Models.Client> clients = dalClient.ShowALL();
            if (clients != null)
            {
                foreach(var item in clients)
                {
                    cmbClient.Items.Add(item.Id + " "+ item.Name + " "+item.Surname);

                }
            }
        }
        void SetEmployeecmb()
        {
            List<Models.Employee> employees = dalEmployee.ShowALL();
            if (employees != null)
            {
                foreach (var item in employees)
                {
                    cmbEmployee.Items.Add(item.Id + " " + item.Name + " " + item.Surname);
                }
            }
        }
        void SetBikecmb()
        {
            List<Models.Bike> bikes = dalBike.ShowALL();
            if (bikes != null)
            {
                foreach (var item in bikes)
                {
                    cmbBike.Items.Add(item.Id + " " + item.Brand_name + " " + item.Model_namre + " " + item.Price);
                }
            }
        }
        void SetStock()
        {
            List<Models.Stock> stocks = dalStock.ShowALL();
            if (stocks != null)
            {
                foreach (var item in stocks)
                {
                    cmbStock.Items.Add(item.Id + " " + item.Stock_name + " " + item.Conditions + " " + item.Stock_date.ToString());
                }
            }
        }

        int GetValueFromcmb(ComboBox box)
        {
            try
            {
                if (box.SelectedItem != null)
                    {
                       string resultString = Regex.Match(box.Text, @"\d+").Value;
                        int res = int.Parse(resultString);
                        return res;
                    }
                }
                catch
                {
                    return -1;
                }
                return -1; 
           
        }
       

    }
}
