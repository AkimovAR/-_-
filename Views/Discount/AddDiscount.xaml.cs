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

namespace motoStore.Views.Discount
{
    /// <summary>
    /// Interaction logic for AddDiscount.xaml
    /// </summary>
    public partial class AddDiscount : Window
    {
        DALDiscount dal;
        public AddDiscount()
        {
            InitializeComponent();
            dal = new DALDiscount();
           
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Models.Discount discount = GetDiscount();
            if (discount != null)
            {
                Models.Discount same = dal.ShowALL().FirstOrDefault(n => n.DateDiscount.DayOfYear == discount.DateDiscount.DayOfYear);
                if (same == null)
                {
                    dal.Add(discount);
                    MessageBox.Show("Скидка на дату добвалена");
                }
                else
                {
                    MessageBox.Show("На выбранную дату скидка уже назначена");
                }

            }
        }
        Models.Discount GetDiscount()
        {
            try
            {
                Models.Discount discount = new Models.Discount();
                int size = int.Parse(txtSize.Text);
                DateTime dt = dpDate.SelectedDate.Value;
                discount.DateDiscount = dt;
                discount.SizeDiscount = size;
                if (size > 1 && size < 100)
                {
                 return discount;
                }
                else
                {
                    MessageBox.Show("Размер скидки должен быть в пределах от 1 до 99");
                    return null;
                }
            }
            catch
            {
                MessageBox.Show("Некорректно введенные данные");
                return null;
            }
        }

        private void txtSize_TextChanged(object sender, TextChangedEventArgs e)
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
