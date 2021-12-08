using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using motoStore.Models;

using motoStore.DAL;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace motoStore.Views.Employee
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        DALEmployee dal;
        DALShop dalshop;
        public AddEmployee()
        {

            InitializeComponent();
            dal = new DALEmployee();
            dalshop = new DALShop();
            SetCombobox();


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Models.Employee emp = GetData();
            if (emp != null)
            {
                try
                {
                    dal.Add(emp);
                    MessageBox.Show("Запись успешно добавлнена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При добавлении обьекта в  произошла ошибка");
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }
        void SetCombobox()
        {
            List<Bikeshop> bikeshops = dalshop.ShowALL();
            if (bikeshops != null)
            {
                foreach (var item in bikeshops)
                {
                    Shoplist.Items.Add(item.Motoshop_name);
                }
            }
            
        }
        int GetFromCombobox()
        {
            try
            {
                string nameshop = Shoplist.Text;
                Bikeshop shop = dalshop.ShowALL().FirstOrDefault(n => n.Motoshop_name == nameshop);
                return shop.Id;
            }
            catch
            {
                return 0;
            }
            
        }
        private Models.Employee GetData()
        {

            Models.Employee employee = new Models.Employee();
            try
            {         
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string post = txtPost.Text;
                string phone = txtPhone.Text;
                string address = txtAddress.Text;
                string passport = txtPassport.Text;
                string account = txtAccount.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                string salaru = txtSalary.Text;

                int shopnum = GetFromCombobox();

                if (shopnum > 0)
                {
                    employee.Name = name;
                    employee.Surname = surname;
                    employee.Post = post;
                    employee.Empphonenumber = phone;
                    employee.Empaddress = address;
                    employee.Emppassport = passport;
                    employee.Account = account;
                    employee.Email = email;
                    employee.Password = password;
                    employee.Salary = salaru;
                    employee.Motoshop_code = shopnum;
                    return employee;
                }
                else
                {
                    MessageBox.Show("Не выбран магазин где работает сотрудник");
                    return null;
               
                }
              
            }
            catch
            {
                MessageBox.Show("Не удалось считать введенные данные");
                return null;
            }
        }

        private void txtSalary_TextChanged(object sender, TextChangedEventArgs e)
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
