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

namespace motoStore
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            if(txtLogin.Text=="admin"&& txtPassword.Text == "admin")
            {
                MainWindow mainWindow = new MainWindow(1);
                this.Hide();
                mainWindow.ShowDialog();
                this.Close();
            }
            else
            {

                MainWindow mainWindow = new MainWindow(0);
                this.Hide();
                mainWindow.ShowDialog();
                this.Close();
            }
           

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
