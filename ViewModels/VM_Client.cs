using motoStore.DAL;
using motoStore.Entities;
using motoStore.Models;
using motoStore.Views.Client;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace motoStore.ViewModels
{
    class VM_Client
    {
		private ICommand saveC;
		private ICommand resetC;
		private ICommand editC;
		private ICommand deleteC;
		private ICommand listBikeWin;
		private ICommand editBikeWin;
		private ICommand addBikeWin;

		private DALClient dclient;
		private Client client = null;
		public Client_E Client_E { get; set; }
		public ICommand ResetCommand
		{
			get
			{
				if (resetC == null)
					resetC = new RelCommand(param => Reset(), null);

				return resetC;
			}
		}

		public ICommand SaveCommand
		{
			get
			{
				if (saveC == null)
					saveC = new RelCommand(param => Save(), null);

				return saveC;
			}
		}

		public ICommand EditCommand
		{
			get
			{
				if (editC == null)
					editC = new RelCommand(param => Edit((int)param), null);

				return editC;
			}
		}

		public ICommand DeleteCommand
		{
			get
			{
				if (deleteC == null)
					deleteC = new RelCommand(param => Delete((int)param), null);

				return deleteC;
			}
		}

		public ICommand AddWinCommand
		{
			get
			{
				if (addBikeWin == null)
					addBikeWin = new RelCommand(param => AddWin(), null);

				return addBikeWin;
			}
		}
		public void AddWin()
		{
			AddClient addClient = new AddClient();
			addClient.ShowDialog();
			Refresh();
		}

		public ICommand EditWinCommand
		{
			get
			{
				if (editBikeWin == null)
					editBikeWin = new RelCommand(param => EditWin((int)param), null);

				return editBikeWin;
			}
		}
		public void EditWin(int id)
		{
			EditClient editClient = new EditClient(id);
			editClient.ShowDialog();
			Refresh();
		}
		public ICommand ListBikeWinCommand
		{
			get
			{
				if (listBikeWin == null)
					listBikeWin = new RelCommand(param => ListWin(), null);

				return listBikeWin;
			}
		}
		public void ListWin()
		{
			ListClient clients = new ListClient();
			clients.ShowDialog();
		}

		public VM_Client()
		{
			client = new Client();
			dclient = new DALClient();
			var clients = dclient.ShowALL();
			Client_E = new Client_E();
			Refresh();
		}
		public VM_Client(int id)
		{
			client = new Client();
			dclient = new DALClient();
			Client_E = new Client_E();
			Edit(id);
			Refresh();
		}

		public void Reset()
		{
			Client_E.Id = 0;
			Client_E.Cliaddress = "";
			Client_E.Clidiscount = 0;
			Client_E.Clipassport = "";
			Client_E.Cliphonenumber = "";
			Client_E.Name = "";
			Client_E.Surname = "";
		}

		public void Delete(int id)
		{
			if (MessageBox.Show("Подтверждаете удаление записи?", "Bike", MessageBoxButton.YesNo)
				== MessageBoxResult.Yes)
			{
				try
				{
					dclient.Remove(id);
					MessageBox.Show("Запись успешно удалена.");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Возникла ошибка при удалении. " + ex.InnerException);
				}
				finally
				{
					Refresh();
				}
			}
		}

		public void Save()
		{
			if (Client_E != null)
			{
				client.Id = Client_E.Id;
				client.Surname = Client_E.Surname;
				client.Cliaddress = Client_E.Cliaddress;
				client.Clipassport = Client_E.Clipassport;
				client.Cliphonenumber = Client_E.Cliphonenumber;
				client.Clidiscount = Client_E.Clidiscount;
				client.Name = Client_E.Name;
				try
				{
					if (Client_E.Id <= 0)
					{
						dclient.Add(client);
						MessageBox.Show("Запись успешно добавлено в бд");
					}
					else
					{
						client.Id = Client_E.Id;
						dclient.Edit(client);
						MessageBox.Show("Запись успешно обновлена");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Возникли ошибки при запросе в бд");
				}
				finally
				{
					Refresh();
					Reset();
				}
			}
		}

		public void Edit(int id)
		{
			var model = dclient.Show(id);
			Client_E.Id = model.Id;
			Client_E.Cliaddress = model.Cliaddress;
			Client_E.Clidiscount = model.Clidiscount;
			Client_E.Name = model.Name;
			Client_E.Clipassport = model.Clipassport;
			Client_E.Surname = model.Surname;
			Client_E.Cliphonenumber = model.Cliphonenumber;
		}

		public void Refresh()
		{
            if (Client_E.Clients_list == null)
            {
			   Client_E.Clients_list = new ObservableCollection<Client_E>();
            }
            else
            {
				Client_E.Clients_list.Clear();
            }
			if (dclient.ShowALL().Count > 0)
			{
				dclient.ShowALL().ForEach(data => Client_E.Clients_list.Add(new Client_E()
				{
					Id = data.Id,
					Surname = data.Surname,
					Name = data.Name,
					Cliaddress = data.Cliaddress,
					Clipassport = data.Clipassport,
					Cliphonenumber = data.Cliphonenumber,
					Clidiscount = data.Clidiscount			
				}));
			}

		}
	}
}
