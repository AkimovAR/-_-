using System;
using System.Windows.Input;

namespace motoStore.ViewModels
{
   public class RelCommand : ICommand
    {
		private readonly Action<object> _execute;
		private readonly Predicate<object> _canExecute;

		public RelCommand(Action<object> execute)
			: this(execute, null)
		{
		}

		public RelCommand(Action<object> execute, Predicate<object> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");
			_execute = execute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}
	}
}
