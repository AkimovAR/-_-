
using System;
using System.Windows;
using motoStore.DAL;
namespace motoStore.Views.Stock
{
   
    public partial class EditStock : Window
    {
        DALStock dal;
        Models.Stock stock;
        public EditStock(int Id)
        {
            InitializeComponent();
            dal = new DALStock();
            stock = dal.Show(Id);
            initVaues();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            setValues();
            if (dal.Edit(stock))
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
            txtName.Text = "";
            txtName.Text = "";
            txtCondidtion.Text = "";
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        void initVaues()
        {
            if (stock != null)
            {
                txtName.Text = stock.Stock_name;
                txtCondidtion.Text = stock.Conditions;
                datepicker.SelectedDate = stock.Stock_date;
            }
        }

        void setValues()
        {
            try
            {
              
                string Stock_name = txtName.Text;
                DateTime datepst = datepicker.SelectedDate.Value;
                string conditions = txtCondidtion.Text;

                stock.Stock_name = Stock_name;
                stock.Stock_date = datepst;
                stock.Conditions = conditions;

            }
            catch
            {
                MessageBox.Show("Не корректно введенные данные");
            }

        }
    }
}
