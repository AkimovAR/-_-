using motoStore.DAL;
using motoStore.Entities;
using motoStore.Models;
using motoStore.Views.Discount;
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
    class VM_Discount
    {
		private ICommand saveC;
		private ICommand resetC;
		private ICommand editC;
		private ICommand deleteC;
		private ICommand listWin;
		private ICommand editWin;
		private ICommand addWin;

		private DALDiscount dal;
		private Discount discount = null;
		public Discount_E entity { get; set; }
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
			AddDiscount addwin = new AddDiscount();
			addwin.ShowDialog();
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
			ListDiscount win = new ListDiscount();
			win.ShowDialog();
		}

		public VM_Discount()
		{
			discount = new Discount();
			dal = new DALDiscount();
			entity = new Discount_E();
			Refresh();
		}

		public void Reset()
		{
			entity.Id = 0;
			entity.DateDiscount = DateTime.MinValue;
			entity.SizeDiscount = 0;
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
				discount.Id = entity.Id;
				discount.DateDiscount = entity.DateDiscount;
				discount.SizeDiscount = entity.SizeDiscount;
				
				try
				{
					if (entity.Id <= 0)
					{
						dal.Add(discount);
						MessageBox.Show("Запись успешно добавлено в бд");
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

		public void Refresh()
		{
			entity.Discount_list = new ObservableCollection<Discount_E>();
			if (dal.ShowALL().Count > 0)
			{
				dal.ShowALL().ForEach(data => entity.Discount_list.Add(new Discount_E()
				{
					Id = data.Id,
					DateDiscount = data.DateDiscount,
					SizeDiscount = data.SizeDiscount
				}));
			}

		}
	}
}
