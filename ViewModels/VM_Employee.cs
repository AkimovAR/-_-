using motoStore.DAL;
using motoStore.Entities;
using motoStore.Models;
using motoStore.Views.BikeShop;
using motoStore.Views.Employee;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace motoStore.ViewModels
{
    class VM_Employee : E_Notifier
    {
		private ICommand saveC;
		private ICommand resetC;
		private ICommand editC;
		private ICommand deleteC;
		private ICommand listWin;
		private ICommand editWin;
		private ICommand addWin;
		private ICommand choose_shop;
		private DALEmployee dal;
		private DALShop dALShop;
		private Employee employee = null;
		public Employee_E entity { get; set; }
		private string shopname;
		public string ShopName
        {
            get { return shopname; }
            set
            {
				shopname = value;
				OnPropertyChanged("ShopName");
            }
        }
		private int shopcode;
		public int ShopCode
		{
			get { return shopcode; }
			set
			{
				shopcode = value;
				OnPropertyChanged("ShopCode");
			}
		}
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
			AddEmployee win = new AddEmployee();
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
			EditEmployee win = new EditEmployee(id);
			win.ShowDialog();
			Refresh();

		}
		public ICommand ListWinCommand
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
			ListEmployee win = new ListEmployee();
			win.ShowDialog();
		}

		public VM_Employee()
		{
			employee = new Employee();
			dal = new DALEmployee();
			dALShop = new DALShop();
			entity = new Employee_E();
			Refresh();
		}
		public VM_Employee(int id)
		{
			employee = new Employee();
			dal = new DALEmployee();
			entity = new Employee_E();
			dALShop = new DALShop();
			Edit(id);
			Refresh();
		}

		public void Reset()
		{
			entity.Id = 0;
			entity.Account = "";
			entity.Email = "";
			entity.Empaddress = "";
			entity.Emppassport = "";
			entity.Empphonenumber = "";
			entity.Motoshop_code = 0;
			entity.Name = "";
			entity.Motoshop_name = "";
			entity.Password = "";
			entity.Post = "";
			entity.Salary = "";
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
			if (entity != null)
			{
				employee.Id =entity.Id;
				employee.Motoshop_code =entity.Motoshop_code;
				employee.Name =entity.Name;
				employee.Password =entity.Password;
				employee.Post =entity.Post;
				employee.Salary =entity.Salary;
				employee.Surname =entity.Surname;
				employee.Account =entity.Account;
				employee.Email =entity.Email;
				employee.Empaddress =entity.Empaddress;
				employee.Emppassport =entity.Emppassport;
				employee.Empphonenumber = entity.Empphonenumber;
				try
				{
					if (entity.Id <= 0)
					{
						dal.Add(employee);
						MessageBox.Show("Запись успешно добавлено в бд");
					}
					else
					{
						employee.Id = entity.Id;
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
			entity.Id = model.Id;
			entity.Motoshop_code = model.Motoshop_code;
			Bikeshop bikeshop = bikeshops.FirstOrDefault(n => n.Id == model.Motoshop_code);
			if (bikeshop != null)
				entity.Motoshop_name = bikeshop.Motoshop_name;
			entity.Name = model.Name;
			entity.Password= model.Password;
			entity.Post = model.Post;
			entity.Salary= model.Salary;
			entity.Surname= model.Surname;
			entity.Account= model.Account;
			entity.Email= model.Email;
			entity.Empaddress= model.Empaddress;
			entity.Emppassport= model.Emppassport;
			entity.Empphonenumber= model.Empphonenumber;
		}

		public void Refresh()
		{

            if (entity.Employee_list == null)
            {
			entity.Employee_list = new ObservableCollection<Employee_E>();
            }
            else
            {
				entity.Employee_list.Clear();
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
					entity.Employee_list.Add(employee_E);
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
				ShopCode = 1;//shop.Id;
				ShopName = "asfasdfasdf"; //shop.Motoshop_name;	
                
							
			}
		}
	}
}
