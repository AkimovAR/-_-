using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using motoStore.DAL;
using motoStore.Models;
using motoStore.Views;

namespace motoStore.ViewModels
{
    class VM_Bike
    {
		private ICommand saveC;
		private ICommand resetC;
		private ICommand editC;
		private ICommand deleteC;
		private ICommand listBikeWin;
		private ICommand editBikeWin;
		private ICommand addBikeWin;

		private DALBike dBike;
		private Bike bike = null;
		public Bike_E Bike_E { get; set; }
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
			AddBike addBike = new AddBike();
			addBike.ShowDialog();
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
			EditBike editBike = new EditBike(id);
			editBike.ShowDialog();
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
			ListBikes bikes = new ListBikes();
			bikes.ShowDialog();
		}

		public VM_Bike()
		{
			bike = new Bike();
			dBike = new DALBike();
			var twm = dBike.ShowALL();
			Bike_E = new Bike_E();
			Refresh();
		}

		public void Reset()
		{
			Bike_E.Id = 0;
			Bike_E.Brand_name = "";
			Bike_E.Max_speed = "";
			Bike_E.Model_name = "";
			Bike_E.Power = "";
			Bike_E.Price = 0;
			Bike_E.Torque = "";
			Bike_E.Transmis_type = "";
			Bike_E.Color_name = "";
			Bike_E.Complectation_name = "";
			Bike_E.Availability = "";


		}

		public void Delete(int id)
		{
			if (MessageBox.Show("Подтверждаете удаление записи?", "Bike", MessageBoxButton.YesNo)
				== MessageBoxResult.Yes)
			{
				try
				{
					dBike.Remove(id);
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
			if (Bike_E != null)
			{
				bike.Id = Bike_E.Id;
				bike.Brand_name =Bike_E.Brand_name;
				bike.Max_speed = Bike_E.Max_speed;
				bike.Model_name = Bike_E.Model_name;
				bike.Power =Bike_E.Power;
				bike.Price =Bike_E.Price;
				bike.Torque = Bike_E.Torque;
				bike.Transmis_type = Bike_E.Transmis_type;
				bike.Color_name = Bike_E.Color_name;
				bike.Complectation_name =Bike_E.Complectation_name;
				bike.Availability =Bike_E.Availability;

				try
				{
					if (Bike_E.Id <= 0)
					{
						dBike.Add(bike);
						MessageBox.Show("Запись успешно добавлено в бд");
					}
					else
					{
						bike.Id = Bike_E.Id;
						dBike.Edit(bike);
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
			var model = dBike.Show(id);
			Bike_E.Id = model.Id;
			Bike_E.Brand_name = model.Brand_name;
			Bike_E.Max_speed = model.Max_speed;
			Bike_E.Model_name = model.Model_name;
			Bike_E.Power = model.Power;
			Bike_E.Price = model.Price;
			Bike_E.Torque = model.Torque;
			Bike_E.Transmis_type = model.Transmis_type;
			Bike_E.Color_name = model.Color_name;
			Bike_E.Complectation_name = model.Complectation_name;
			Bike_E.Availability = model.Availability;
		}

		public void Refresh()
		{
			Bike_E.Bike_list = new ObservableCollection<Bike_E>();
            if (dBike.ShowALL().Count > 0)
            {
				dBike.ShowALL().ForEach(data => Bike_E.Bike_list.Add(new Bike_E()
				{
					Id = data.Id,
					Brand_name = data.Brand_name,
					Model_name = data.Model_name,
					Color_name = data.Color_name,
					Complectation_name = data.Complectation_name,
					Max_speed = data.Max_speed,
					Power = data.Power,
					Torque = data.Torque,
					Transmis_type = data.Transmis_type,
					Availability = data.Availability,
					Price = data.Price
				}));
            }
			
		}
	}
}

