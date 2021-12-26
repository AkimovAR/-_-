
using System;
using System.Windows;
using motoStore.DAL;
namespace motoStore.Views.Stock
{
    /// <summary>
    /// Interaction logic for AddStock.xaml
    /// </summary>
    public partial class AddStock : Window
    {
        DALStock dal;
        public AddStock()
        {
            InitializeComponent();
            dal = new DALStock();
        }

        private void btnAddStock_Click(object sender, RoutedEventArgs e)
        {
            Models.Stock stock = new Models.Stock();
            stock = GetData();
            if (stock != null)
            {
                try
                {
                    dal.Add(stock);
                    MessageBox.Show("Запись успешно добавлена");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении записи в базу данных");
                }
            }
        }

        private void Clearbtn_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtName.Text = "";
            txtCondidtion.Text = "";
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private Models.Stock GetData()
        {

            Models.Stock stock = new Models.Stock();
            try
            {
                /*
             
             код для проверки
             но мне влом
             
             */
                string Stock_name = txtName.Text;
                DateTime datepst =  datepicker.SelectedDate.Value;
                string conditions = txtCondidtion.Text;

                stock.Stock_name = Stock_name;
                stock.Stock_date = datepst;
                stock.Conditions = conditions;
                return stock;

            }
            catch
            {
                MessageBox.Show("Не корректно введенные данные");
                return null;
            }
        }
    }
}
