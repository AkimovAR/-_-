using motoStore.DAL;
using motoStore.Entities;
using motoStore.Models;
using motoStore.Views.BikeShop;
using motoStore.Views.Employee;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace motoStore.ViewModels
{
    class VM_Employee
    {
		private ICommand saveC;
        private ICommand resetC;
		private ICommand editC;
		private ICommand deleteC;
		private ICommand choose_shop;
		private DALEmployee dal;
		private DALShop dALShop;
        private Employee employee;
		
        public Employee_E Entity { get; set; }
        public ICommand SelectShopCommand
        {
            get
			{
				if (choose_shop == null)
					choose_shop = new RelCommand(param => SelectShop(), null);

				return choose_shop;
            }
        }
		public ICommand ResetCommand
		{
			get
			{
				if (resetC == null)
					resetC = new RelCommand(param => Test(), null);

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

	
		public VM_Employee()
		{
			employee = new Employee();
			dal = new DALEmployee();
			dALShop = new DALShop();
			Entity = new Employee_E();
			Refresh();
		}
	

		public void Reset()
		{
			Entity.Id = 0;
			Entity.Account = "";
			Entity.Email = "";
			Entity.Empaddress = "";
			Entity.Emppassport = "";
			Entity.Empphonenumber = "";
			Entity.Motoshop_code = 0;
			Entity.Name = "";
			Entity.Motoshop_name = "";
			Entity.Password = "";
			Entity.Post = "";
			Entity.Salary = "";
		}

		public void Delete(int id)
		{
			if (MessageBox.Show("Подтверждаете удаление записи?", "Bike", MessageBoxButton.YesNo)
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
			if (Entity != null)
			{
				employee.Id = Entity.Id;
				employee.Motoshop_code = Entity.Motoshop_code;
				employee.Name = Entity.Name;
				employee.Password = Entity.Password;
				employee.Post = Entity.Post;
				employee.Salary = Entity.Salary;
				employee.Surname = Entity.Surname;
				employee.Account = Entity.Account;
				employee.Email = Entity.Email;
				employee.Empaddress = Entity.Empaddress;
				employee.Emppassport = Entity.Emppassport;
				employee.Empphonenumber = Entity.Empphonenumber;
				try
				{
					if (Entity.Id <= 0)
					{
						dal.Add(employee);
						MessageBox.Show("Запись успешно добавлено в бд");
					}
					else
					{
						employee.Id = Entity.Id;
						dal.Edit(employee);
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

			List<Bikeshop> bikeshops = dALShop.ShowALL();
			var model = dal.Show(id);

			Entity.Id = model.Id;
			Entity.Motoshop_code = model.Motoshop_code;
			Bikeshop bikeshop = bikeshops.FirstOrDefault(n => n.Id == model.Motoshop_code);
			if (bikeshop != null)
            {
			  Entity.Motoshop_name = bikeshop.Motoshop_name;
            }
			Entity.Name = model.Name;
			Entity.Password = model.Password;
			Entity.Post = model.Post;
			Entity.Salary = model.Salary;
			Entity.Surname = model.Surname;
			Entity.Account = model.Account;
			Entity.Email = model.Email;
			Entity.Empaddress = model.Empaddress;
			Entity.Emppassport = model.Emppassport;
			Entity.Empphonenumber = model.Empphonenumber;
		}
		public void Test()
        {
			MessageBox.Show(Entity.Name);
        }

		public void Refresh()
		{
            if (Entity.Employee_list == null)
            {
			Entity.Employee_list = new ObservableCollection<Employee_E>();
            }
            else
            {
				Entity.Employee_list.Clear();

			}
			if (dal.ShowALL().Count > 0)
			{
				List<Bikeshop> bikeshops = dALShop.ShowALL();
				foreach(var item in dal.ShowALL())
                {
					Employee_E employee_E = new Employee_E();
					employee_E.Id =item.Id;
					employee_E.Motoshop_code =item.Motoshop_code;
					Bikeshop bikeshop = bikeshops.FirstOrDefault(n => n.Id == item.Motoshop_code);
					if (bikeshop != null)
						employee_E.Motoshop_name = bikeshop.Motoshop_name;
					employee_E.Name =item.Name;
					employee_E.Password =item.Password;
					employee_E.Post =item.Post;
					employee_E.Salary = item.Salary;
					employee_E.Surname =item.Surname;
					employee_E.Account =item.Surname;
					employee_E.Email = item.Email;
					employee_E.Empaddress =item.Empaddress;
					employee_E.Emppassport =item.Emppassport;
					employee_E.Empphonenumber =item.Empphonenumber;
					Entity.Employee_list.Add(employee_E);
				}
				
			}

		}
		public void SelectShop()
		{
			ChooseShopWin chooseShopWin = new ChooseShopWin();
			VM_GetShop vM_GetShop = (VM_GetShop)chooseShopWin.DataContext;

			chooseShopWin.ShowDialog();

			if (vM_GetShop.Shop_id > 0)
			{
				Bikeshop shop = dALShop.ShowALL().FirstOrDefault(n=>n.Id== vM_GetShop.Shop_id);
				Entity.Motoshop_code = shop.Id;
				Entity.Motoshop_name =  shop.Motoshop_name;				
			}
		}
	}
}
