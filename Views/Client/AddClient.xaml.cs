using System;

using System.Windows;

using motoStore.DAL;

using motoStore.Models;

namespace motoStore.Views.Client
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        DALClient dal;
        public AddClient()
        {
            InitializeComponent();
            dal = new DALClient();
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            Models.Client client = GetData();
            if (client != null)
            {
                try
                {
                dal.Add(client);
                    MessageBox.Show("Запись успешно добавлена");
                }catch(Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении записи в базу данных");
                }
            }
        }

        private void Clearbtn_Click(object sender, RoutedEventArgs e)
        {
             txtName.Text     ="";
             txtSurname.Text  ="";
             txtPhone.Text    ="";
             txtAddress.Text  ="";
             txtPassport.Text ="";
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private Models.Client GetData()
        {

            Models.Client client = new Models.Client();
            try
            {      
                string name =    txtName.Text;
                string surname = txtSurname.Text;
                string phone =   txtPhone.Text;
                string address = txtAddress.Text;
                string passport= txtPassport.Text;

                client.Name = name;
                client.Surname = surname;
                client.Cliphonenumber = phone;
                client.Cliaddress = address;
                client.Clipassport = passport;
                return client;

            }
            catch
            {
                MessageBox.Show("Не корректно введенные данные");
                return null;
            }
        }

        
    }
}
