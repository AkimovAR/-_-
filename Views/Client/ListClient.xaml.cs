using System.Windows;
using motoStore.DAL;
using motoStore.Models;

namespace motoStore.Views.Client
{
    /// <summary>
    /// Interaction logic for ListClient.xaml
    /// </summary>
    public partial class ListClient : Window
    {
        DALClient dal;
        public ListClient()
        {
            InitializeComponent();
            dal = new DALClient();
            clientGrid.ItemsSource = dal.ShowALL();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.ShowDialog();
            updateDG();

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (clientGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < clientGrid.SelectedItems.Count; i++)
                {
                    Models.Client client = clientGrid.SelectedItems[i] as Models.Client;
                    if (client != null)
                    {

                        EditClient editclient = new EditClient(client.Id);
                        editclient.ShowDialog();

                    }
                }
            }
            updateDG();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (clientGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < clientGrid.SelectedItems.Count; i++)
                {
                    Models.Client client = clientGrid.SelectedItems[i] as Models.Client;
                    if (client != null)
                    {

                        if (dal.Remove(client.Id))
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
            clientGrid.ItemsSource = null;
            clientGrid.ItemsSource = dal.ShowALL();
        }
    }
}
