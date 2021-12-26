using System.ComponentModel;

namespace motoStore.Entities
{
   public class E_Notifier
    {
		public event PropertyChangedEventHandler E_Changed;

		protected void OnPropertyChanged(string E_Name)
		{
			if (E_Changed != null)
			{
				E_Changed(this, new PropertyChangedEventArgs(E_Name));
			}
		}
	}
}
