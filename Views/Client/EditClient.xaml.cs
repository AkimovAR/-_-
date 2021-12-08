using System.Windows;
using motoStore.DAL;
using motoStore.Models;

namespace motoStore.Views.Client
{
    /// <summary>
    /// Interaction logic for EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        DALClient dal;
        Models.Client client;
        public EditClient(int Id)
        {
            InitializeComponent();
            dal = new DALClient();
            client = dal.Show(Id);
            initVaues();

        }

        private void btnUpdatet_Click(object sender, RoutedEventArgs e)
        {
            if (setValues())
            {
                if (dal.Edit(client))
                {
                    MessageBox.Show("Запись успешно обновлена");
                }
                else
                {
                    MessageBox.Show("При изменении записи возникли ошибки");
                }
            }
        }

        private void Clearbtn_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text =  "";
            txtSurname.Text ="";
            txtPhone.Text = "";
            txtAddress.Text ="";
            txtPassport.Text ="";
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void initVaues()
        {
            if (client != null)
            {
                txtName.Text =     client.Name;
                txtSurname.Text =  client.Surname;
                txtPhone.Text =    client.Cliphonenumber;
                txtAddress.Text =  client.Cliaddress;
                txtPassport.Text = client.Clipassport;
            }
        }

        bool setValues()
        {
            try
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string phone = txtPhone.Text;
                string address = txtAddress.Text;
                string passport = txtPassport.Text;

                client.Name = name;
                client.Surname = surname;
                client.Cliphonenumber = phone;
                client.Cliaddress = address;
                client.Clipassport = passport;
                return true;
            }
            catch
            {
                MessageBox.Show("Некорректно введенные даные");
                return false;
            }
            
        }
    }
}
