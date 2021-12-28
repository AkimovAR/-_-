using motoStore.Models;
using motoStore.Views;
using motoStore.Views.BikeShop;
using motoStore.Views.Client;
using motoStore.Views.Discount;
using motoStore.Views.Employee;
using motoStore.Views.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace motoStore.ViewModels
{
    class VM_MainWindow
    {
		private ICommand _clientCommand;
		private ICommand _bikeCommand;
		private ICommand _discountCommand;
		private ICommand _shopCommand;
		private ICommand _orderCommand;
		private ICommand _employeeCommand;
		private ICommand _stockCommand;
		private Employee Current;


		public VM_MainWindow(Employee user)
		{
			Current = user;
		}
		public ICommand EmployeeCommand
		{
			get
			{
				if (_employeeCommand == null)
					_employeeCommand = new RelCommand(param => EmployeeWindow(), null);

				return _employeeCommand;
			}
		}

		public ICommand ClientCommand
		{
			get
			{
				if (_clientCommand == null)
					_clientCommand = new RelCommand(param => ClientWindow(), null);

				return _clientCommand;
			}
		}

		public ICommand BikesCommand
		{
			get
			{
				if (_bikeCommand == null)
					_bikeCommand = new RelCommand(param => BikesWindow(), null);

				return _bikeCommand;
			}
		}

		public ICommand DiscountCommand
		{
			get
			{
				if (_discountCommand == null)
					_discountCommand = new RelCommand(param => DiscountWindow(), null);

				return _discountCommand;
			}
		}

		public ICommand ShopCommand
		{
			get
			{
				if (_shopCommand == null)
					_shopCommand = new RelCommand(param => ShopWindow(), null);

				return _shopCommand;
			}
		}

		public ICommand OrderCommand
		{
			get
			{
				if (_orderCommand == null)
					_orderCommand = new RelCommand(param => OrderWindow(), null);

				return _orderCommand;
			}
		}

		

		public void EmployeeWindow()
		{
			EmployeeList win = new EmployeeList();
			win.ShowDialog();
		}
		public void ClientWindow()
		{
			ListClient view = new ListClient();
			view.ShowDialog();
		}
		public void BikesWindow()
		{

			ListBikes win = new ListBikes();
			win.ShowDialog();
		}
		public void DiscountWindow()
		{
			ListDiscount win = new ListDiscount();
			win.ShowDialog();
		}
		public void ShopWindow()
		{
			ListShop win = new ListShop();
			win.ShowDialog();
		}
		public void OrderWindow()
		{
			ListOrder win = new ListOrder();
			win.ShowDialog();
		}
		
	}
}
