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
    /// Interaction logic for ListEmployee.xaml
    /// </summary>
    public partial class ListEmployee : Window
    {
        DALEmployee dal;
        public ListEmployee()
        {
            InitializeComponent();
            dal = new DALEmployee();
            employeesGrid.ItemsSource = dal.ShowALL();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
            updateDG();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (employeesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < employeesGrid.SelectedItems.Count; i++)
                {
                    Models.Employee employee = employeesGrid.SelectedItems[i] as Models.Employee;
                    if (employee != null)
                    {

                        EditEmployee editEmployee = new EditEmployee(employee.Id);
                        editEmployee.ShowDialog();

                    }
                }
            }
            updateDG();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (employeesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < employeesGrid.SelectedItems.Count; i++)
                {
                    Models.Employee employee = employeesGrid.SelectedItems[i] as Models.Employee;
                    if (employee != null)
                    {

                        if (dal.Remove(employee))
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
            employeesGrid.ItemsSource = null;
            employeesGrid.ItemsSource = dal.ShowALL();
        }
    }
}
