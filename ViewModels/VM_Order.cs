using motoStore.DAL;
using motoStore.Entities;
using motoStore.Models;
using motoStore.Views.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace motoStore.ViewModels
{
    class VM_Order
    {
		private ICommand saveC;
		private ICommand resetC;
		private ICommand editC;
		private ICommand deleteC;
		private ICommand listWin;
		private ICommand editWin;
		private ICommand addWin;

		private DALOrder dal;
		private Order order = null;
		public Order_E entity { get; set; }
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
				if (addWin == null)
					addWin = new RelCommand(param => AddWin(), null);

				return addWin;
			}
		}
		public void AddWin()
		{
			AddOrder win = new AddOrder();
			win.ShowDialog();
			Refresh();
		}

		public ICommand EditWinCommand
		{
			get
			{
				if (editWin == null)
					editWin = new RelCommand(param => EditWin((int)param), null);

				return editWin;
			}
		}
		public void EditWin(int id)
		{
			OrderDetails win = new OrderDetails(id);
			win.ShowDialog();
		}
		public ICommand ListBikeWinCommand
		{
			get
			{
				if (listWin == null)
					listWin = new RelCommand(param => ListWin(), null);

				return listWin;
			}
		}
		public void ListWin()
		{
			ListOrder win = new ListOrder();
			win.ShowDialog();
		}

		public VM_Order()
		{
			order = new Order();
			dal = new DALOrder();
			entity = new Order_E();
			Refresh();
		}

		public void Reset()
		{
			entity.Id = 0;
			entity.Order_date = DateTime.MinValue;
			entity.Order_price = "";
			entity.Bike_code = 0;
			entity.Client_code =0;
			entity.Employee_code = 0;
			entity.Stock_code = 0;	
		}

		public void Delete(int id)
		{
			if (MessageBox.Show("Подтверждаете удаление записи?", "Order", MessageBoxButton.YesNo)
				== MessageBoxResult.Yes)
			{
				try
				{
					dal.Remove(id);
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
			if (entity != null)
			{
				order.Id = entity.Id;
				order.Bike_code = entity.Bike_code;
				order.Client_code = entity.Client_code;
				order.Employee_code = entity.Employee_code;
				order.Order_date = entity.Order_date;
				order.Order_price = entity.Order_price;
				order.Stock_code = entity.Stock_code;			
				try
				{
					if (entity.Id <= 0)
					{
						dal.Add(order);
						MessageBox.Show("Запись успешно добавлено в бд");
					}
					else
					{
						order.Id = entity.Id;
						dal.Edit(order);
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
			var model = dal.Show(id);
			entity.Id = model.Id;
			entity.Order_date = model.Order_date;
			entity.Order_price = model.Order_price;
			entity.Stock_code = model.Stock_code;
			entity.Bike_code = model.Bike_code;
			entity.Client_code = model.Client_code;
			entity.Employee_code = model.Employee_code;		
		}

		public void Refresh()
		{
			entity.Order_list = new ObservableCollection<Order_E>();
			if (dal.ShowALL().Count > 0)
			{
				dal.ShowALL().ForEach(data => entity.Order_list.Add(new Order_E()
				{
					Id = data.Id,
					Order_date = data.Order_date,
					Order_price = data.Order_price,
					Stock_code = data.Stock_code,
					Bike_code = data.Bike_code,
					Client_code = data.Client_code,
					Employee_code = data.Employee_code
			})); ;
			}
		}
	}
}
