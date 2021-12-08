using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;
using motoStore.DAL;

namespace motoStore.Views.Discount
{
    /// <summary>
    /// Interaction logic for ListDiscount.xaml
    /// </summary>
    public partial class ListDiscount : Window
    {
        DALDiscount dal;
        public ListDiscount()
        {
            InitializeComponent();
            dal = new DALDiscount();
            updateDG();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddDiscount addDiscount = new AddDiscount();
            addDiscount.ShowDialog();
            updateDG();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (discountGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < discountGrid.SelectedItems.Count; i++)
                {
                    Models.Discount discount = discountGrid.SelectedItems[i] as Models.Discount;
                    if (discount != null)
                    {

                        if (dal.Remove(discount))
                        {
                            MessageBox.Show("Запись успешно удалена");
                        }
                        else
                        {
                            MessageBox.Show("При удалении зписи возники ошибки");
                        }

                    }
                }
            }
            updateDG();
        }
        private void updateDG()
        {
            discountGrid.ItemsSource = null;
            discountGrid.ItemsSource = dal.ShowALL();
        }
    }
}
