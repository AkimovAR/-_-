
using System.Windows;
using motoStore.DAL;
using motoStore.Models;

namespace motoStore.Views.BikeShop
{
    /// <summary>
    /// Interaction logic for EditShop.xaml
    /// </summary>
    public partial class EditShop : Window
    {
        DALShop dALShop;
        Bikeshop bikeshop;
        public EditShop(int Id)
        {
            InitializeComponent();
            dALShop = new DALShop();
            bikeshop = dALShop.Show(Id);
            initVaues();
        }

        private void Savbtn_Click(object sender, RoutedEventArgs e)
        {
            setValues();
            if (dALShop.Edit(bikeshop))
            {
                MessageBox.Show("Запись успешно обновлена");
            }
            else
            {
                MessageBox.Show("При изменении записи возникли ошибки");
            }
        }

        private void Clearbtn_Click(object sender, RoutedEventArgs e)
        {
            txtMotoshop_name.Text = "";
            txtAddress.Text = "";
            txtPhone_number.Text = "";
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        void initVaues()
        {
            if (bikeshop != null)
            {
                txtMotoshop_name.Text = bikeshop.Motoshop_name;
                txtAddress.Text = bikeshop.Address;
                txtPhone_number.Text = bikeshop.Phone_number;
            }
        }
        void setValues()
        {
            /*нужна проверка вводных значений*/
            string name = txtMotoshop_name.Text;
            string address = txtAddress.Text;
            string phone = txtPhone_number.Text;

            bikeshop.Motoshop_name = name;
            bikeshop.Address = address;
            bikeshop.Phone_number = phone;
    
        }
    }
}
