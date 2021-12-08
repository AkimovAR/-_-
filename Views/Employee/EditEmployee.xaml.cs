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

namespace motoStore.Views.Employee
{
    /// <summary>
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        DALEmployee dAL;
        Models.Employee employee;
        DALShop dalshop;


        public EditEmployee(int Id)
        {
            InitializeComponent();
            dAL = new DALEmployee();
            dalshop = new DALShop();
            employee = dAL.Show(Id);
            initVaues();
            SetCombobox();
        }

       

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (SetValues())
            {
                if (dAL.Edit(employee))
                {
                    MessageBox.Show("Запись успешно обновлена");
                }
                else
                {
                    MessageBox.Show("При изменении записи возникли ошибки");
                }
            }
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtSurname.Text ="";
            txtPost.Text = "";
            txtPhone.Text = "";
            txtAddress.Text ="";
            txtPassport.Text ="";
            txtAccount.Text ="";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtSalary.Text = "";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        void initVaues()
        {
            if (employee != null)
            {
               txtName.Text = employee.Name;
               txtSurname.Text = employee.Surname;
               txtPost.Text = employee.Post;
               txtPhone.Text = employee.Empphonenumber;
               txtAddress.Text = employee.Empaddress;
               txtPassport.Text = employee.Emppassport;
               txtAccount.Text = employee.Account;
               txtEmail.Text = employee.Email;
               txtPassword.Text = employee.Password;
               txtSalary.Text = employee.Salary;
            }

        }
        bool SetValues()
        {
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
                    return true;
                }
                else
                {
                    MessageBox.Show("Не выбран магазин где работает сотрудник");
                    return false;
                }             
            }
            catch
            {
                MessageBox.Show("Некорректно введенные значения");
                return false;
            }          
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
            Bikeshop shop = bikeshops.FirstOrDefault(n => n.Id == employee.Motoshop_code);
            if (shop != null)
            {
                Shoplist.SelectedItem = shop.Motoshop_name;
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
