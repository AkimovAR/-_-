using motoStore.DAL;
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
    /// Interaction logic for OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : Window
    {
        DALBike       dalBike;
        DALClient     dalClient;
        DALEmployee   dalEmployee;
        DALDiscount   dalDiscount;
        DALOrder      dalOrder;
        DALShop       dalShop;

        Models.Client client;
        Models.Bike bike;
        Models.Employee employee;
        Models.Discount discount;
        Models.Stock stock;
        Models.Bikeshop shop;




        public OrderDetails(int Id)
        {
            InitializeComponent();
            dalBike = new DALBike();
            dalClient = new DALClient();
            dalEmployee = new DALEmployee();
            dalDiscount = new DALDiscount();
            dalOrder = new DALOrder();
            dalShop = new DALShop();
            initData(Id);
        }
        void initData(int id)
        {
            Models.Order order = dalOrder.Show(id);
            if (order != null)
            {
                client = dalClient.Show(order.Client_code);
                bike = dalBike.Show(order.Bike_code);
                employee = dalEmployee.Show(order.Employee_code);
                if (employee != null)
                {
                    shop = dalShop.Show(employee.Motoshop_code);
                }
                if(shop!=null && client!=null && bike!=null && employee != null)
                {
                    txtclientName.Text = client.Name;
                    txtClientSurname.Text = client.Surname;
                    txtClientPhone.Text = client.Cliphonenumber;
                    txtClientAddress.Text = client.Cliaddress;

                    txtShopAddress.Text = shop.Address;
                    txtShopPhone.Text = shop.Phone_number;
                    txtMotoshop_name.Text = shop.Motoshop_name;

                    txtEmployeeName.Text = employee.Name;
                    txtEmployeeSurname.Text = employee.Surname;
                    txtEmployeePhone.Text = employee.Empphonenumber;
                    txtEmployeePost.Text = employee.Post;

                    txtMotoModel.Text = bike.Model_name;
                    txtMotoBrand.Text = bike.Brand_name;
                    txtMotoColor.Text = bike.Color_name;
                    txtMotoPrice.Text = bike.Price.ToString();
                    txtMotoPower.Text = bike.Power;
                    txtMotoTorq.Text = bike.Torque;
                    txtMotoTransmission.Text = bike.Transmis_type;
                    txtMotoAviable.Text = bike.Availability;
   
                }



            }
        }
    }
}
