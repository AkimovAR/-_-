using motoStore.DAL;
using motoStore.Entities;
using motoStore.Models;
using motoStore.Views.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq; 

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

		private DALOrder dalOrder;
		private DALBike dalBike;
		private DALClient dalClient;
		private DALEmployee dalEmployee;
		private DALDiscount dalDiscount;

		private Order order = null;
		public Order_E entity { get; set; }
		public Bike_E bike_entity { get; set; }
		public Employee_E employee_entity { get; set; }
		public Client_E client_entity { get; set; }

		private ICommand choose_client;
		public ICommand SelectClientCommand
		{
			get
			{
				if (choose_client == null)
					choose_client = new RelCommand(param => SelectClient(), null);

				return choose_client;
			}
		}
		private ICommand choose_bike;
		public ICommand SelectBikeCommand
		{
			get
			{
				if (choose_bike == null)
					choose_bike = new RelCommand(param => SelectBike(), null);

				return choose_bike;
			}
		}

		private ICommand choose_employee;
		public ICommand SelectEmployeeCommand
		{
			get
			{
				if (choose_employee == null)
					choose_employee = new RelCommand(param => SelectEmployee(), null);

				return choose_employee;
			}
		}
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
			Refresh();
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
			dalOrder = new DALOrder();
			dalBike = new DALBike();
			dalClient = new DALClient();
			dalDiscount = new DALDiscount();
			dalEmployee = new DALEmployee();
			entity = new Order_E();
			bike_entity = new Bike_E();
			client_entity = new Client_E();
			employee_entity = new Employee_E();
			Refresh();
		}
		public VM_Order(int Id)
		{
			order = new Order();
			dalOrder = new DALOrder();
			dalBike = new DALBike();
			dalClient = new DALClient();
			dalDiscount = new DALDiscount();
			dalEmployee = new DALEmployee();
			entity = new Order_E();
			bike_entity = new Bike_E();
			client_entity = new Client_E();
			employee_entity = new Employee_E();
			Edit(Id);
			Refresh();
		}

		public void Reset()
		{
			entity.Id = 0;
			entity.Bike_name = "";
			entity.Client_name = "";
			entity.Employee_name = "";
			entity.Order_date = DateTime.MinValue;
			entity.Order_price = "";
			entity.Bike_code = 0;
			entity.Client_code =0;
			entity.Employee_code = 0;
		}

		public void Delete(int id)
		{
			if (MessageBox.Show("Подтверждаете удаление записи?", "Order", MessageBoxButton.YesNo)
				== MessageBoxResult.Yes)
			{
				try
				{
					dalOrder.Remove(id);
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
				List<Discount> discounts = dalDiscount.ShowALL();

				order.Id = entity.Id;
				order.Bike_code = entity.Bike_code;
				var bike = dalBike.Show(entity.Bike_code);
				if (bike != null)
				{
					order.Order_price = bike.Price.ToString();
				}
				order.Client_code = entity.Client_code;
				order.Employee_code = entity.Employee_code;
				order.Order_date = entity.Order_date;
				Discount discount = discounts.FirstOrDefault(n => n.DateDiscount.Day == entity.Order_date.Day);
                if (discount != null)
                {
					double number;

					bool success = Double.TryParse(order.Order_price, out number);

					if (success) 
                    {
                        if (discount.SizeDiscount <= number)
                        {
							double t = number - discount.SizeDiscount;
							order.Order_price = t.ToString();
                        }
						
                    }
						

                }
				try
				{
					if (entity.Id <= 0)
					{
						dalOrder.Add(order);
						MessageBox.Show("Запись успешно добавлено в бд");
					}
					else
					{
						order.Id = entity.Id;
						dalOrder.Edit(order);
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

			var model = dalOrder.Show(id);
			entity.Id = model.Id;
			entity.Order_date = model.Order_date;
			entity.Bike_code = model.Bike_code;
			var bike = dalBike.Show(entity.Bike_code);
            if (bike != null)
            {
				entity.Bike_name = bike.Model_name + " " + bike.Brand_name + "  Стоимость " + bike.Price;
				bike_entity.Id = bike.Id;
				bike_entity.Brand_name = bike.Brand_name;
				bike_entity.Max_speed = bike.Max_speed;
				bike_entity.Model_name = bike.Model_name;
				bike_entity.Power = bike.Power;
				bike_entity.Price = bike.Price;
				bike_entity.Torque = bike.Torque;
				bike_entity.Transmis_type = bike.Transmis_type;
				bike_entity.Color_name = bike.Color_name;
				bike_entity.Complectation_name = bike.Complectation_name;
				bike_entity.Availability = bike.Availability;
			}
			entity.Order_price = model.Order_price;
			
			
			entity.Client_code = model.Client_code;
			var client = dalClient.Show(entity.Client_code);
            if (client != null)
            {
				entity.Client_name = client.Name + " " + client.Surname + " " + client.Cliaddress;
				client_entity.Id = client.Id;
				client_entity.Surname = client.Surname;
				client_entity.Cliaddress = client.Cliaddress;				
				client_entity.Name = client.Name;
				client_entity.Cliphonenumber = client.Cliphonenumber;
			}
			entity.Employee_code = model.Employee_code;
			var empl = dalEmployee.Show(entity.Employee_code);
            if (empl != null)
            {
				entity.Employee_name = empl.Name + " " + empl.Surname + " " + empl.Post;
				employee_entity.Name = empl.Name;
				employee_entity.Post = empl.Post;
				employee_entity.Surname = empl.Surname;
				employee_entity.Empphonenumber = empl.Empphonenumber;
				
			}

		}

		public void Refresh()
		{
            if (entity.Order_list == null)
            {
			  entity.Order_list = new ObservableCollection<Order_E>();
            }
            else
            {
				entity.Order_list.Clear();
            }

			if (dalOrder.ShowALL().Count > 0)
			{
				foreach(var item in dalOrder.ShowALL())
                {
					Order_E order_e = new Order_E();
					List<Client> clients = dalClient.ShowALL();
					List<Employee> employees = dalEmployee.ShowALL();
					List<Bike> bikes = dalBike.ShowALL();
					order_e.Id = item.Id;
					order_e.Order_date = item.Order_date;
					order_e.Order_price = item.Order_price;
					order_e.Bike_code = item.Bike_code;
					order_e.Bike_name = "";
					Bike bike = bikes.FirstOrDefault(n=>n.Id==item.Bike_code);
					if (bike != null)
					{
						order_e.Bike_name = bike.Model_name + " " + bike.Brand_name + "  Стоимость " + bike.Price;
					}
					order_e.Client_code = item.Client_code;
					order_e.Client_name = "";
					Client client = clients.FirstOrDefault(n=>n.Id==item.Client_code);
					if (client != null)
					{
						order_e.Client_name = client.Name + " " + client.Surname + " " + client.Cliaddress;
					}
					order_e.Employee_name = "";
					order_e.Employee_code = item.Employee_code;
					Employee empl = employees.FirstOrDefault(n => n.Id == item.Employee_code); 
					if (empl != null)
					{
						order_e.Employee_name = empl.Name + " " + empl.Surname + " " + empl.Post;
					}
					entity.Order_list.Add(order_e);
				}
				
			}
		}
		public void SelectEmployee()
		{
			SelectEmployee win = new SelectEmployee();
			VM_GetEmployee vm = (VM_GetEmployee)win.DataContext;

			win.ShowDialog();

			if (vm.Id > 0)
			{
				Employee emp = dalEmployee.Show(vm.Id);
				entity.Employee_code = emp.Id;
				entity.Employee_name = emp.Name + " " + emp.Surname+" "+emp.Post;
			}
		}
		public void SelectClient()
		{
			SelectClient win = new Views.Order.SelectClient();
			VM_GetClient vm = (VM_GetClient)win.DataContext;

			win.ShowDialog();

			if (vm.Id > 0)
			{
				Client cl = dalClient.Show(vm.Id);
				entity.Client_code = cl.Id;
				entity.Client_name = cl.Name+" "+ cl.Surname+" "+cl.Cliaddress;
			}
		}
		public void SelectBike()
        {
			SelectBike win = new Views.Order.SelectBike();
			VM_GetBike vm = (VM_GetBike)win.DataContext;

			win.ShowDialog();

			if (vm.Id > 0)
			{
				Bike bk = dalBike.Show(vm.Id);
				entity.Bike_code = bk.Id;
				entity.Bike_name = bk.Brand_name + " " + bk.Model_name + " " + bk.Price;
			}
		}
	}
}
