using motoStore.DAL;
using motoStore.Entities;
using motoStore.Models;
using motoStore.Views.BikeShop;
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
    class VM_BikeShop
    {
		private ICommand saveC;
		private ICommand resetC;
		private ICommand editC;
		private ICommand deleteC;
		private ICommand listWin;
		private ICommand editWin;
		private ICommand addWin;

		private DALShop dal;
		private Bikeshop bikeShop = null;
		public Bikeshop_E entity { get; set; }
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
			AddShop addShop = new AddShop();
			addShop.ShowDialog();
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
			EditShop editShop = new EditShop(id);
			editShop.ShowDialog();
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
			ListShop listShop = new ListShop();
			listShop.ShowDialog();
		}

		public VM_BikeShop()
		{
			bikeShop = new Bikeshop();
			dal = new DALShop();
			entity = new Bikeshop_E();
			Refresh();
		}

		public void Reset()
		{
			entity.Id = 0;
			entity.Address = "";
			entity.Motoshop_name = "";
			entity.Phone_number = "";
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
				bikeShop.Id = entity.Id;
				bikeShop.Address = entity.Address;
				bikeShop.Phone_number = entity.Phone_number;
				bikeShop.Motoshop_name = entity.Motoshop_name;
				try
				{
					if (entity.Id <= 0)
					{
						dal.Add(bikeShop);
						MessageBox.Show("Запись успешно добавлено в бд");
					}
					else
					{
						bikeShop.Id = entity.Id;
						dal.Edit(bikeShop);
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
			entity.Address = model.Address;
			entity.Phone_number = model.Phone_number;
			entity.Motoshop_name = model.Motoshop_name;
			
		}

		public void Refresh()
		{
			entity.Bikeshop_list = new ObservableCollection<Bikeshop_E>();
			if (dal.ShowALL().Count > 0)
			{
				dal.ShowALL().ForEach(data => entity.Bikeshop_list.Add(new Bikeshop_E()
				{
					Id = data.Id,
					Address = data.Address,
					Phone_number = data.Phone_number,
					Motoshop_name = data.Motoshop_name					
				}));
			}

		}
	}
}
