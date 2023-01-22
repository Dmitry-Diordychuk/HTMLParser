using System;
using System.Windows.Input;

namespace HTMLParser.Infrastructure;

public class RelayCommand : ICommand
{
	private Action<object> _execute;
	private Func<object, bool>? _canExecute;

	public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
	{
		_execute = execute;
		_canExecute = canExecute;
	}
	
	public event EventHandler? CanExecuteChanged
	{
		add => CommandManager.RequerySuggested += value;
		remove => CommandManager.RequerySuggested -= value;
	}

	public void Execute(object? parameter)
	{
		_execute.Invoke(parameter);
	}
	
	public bool CanExecute(object? parameter)
	{
		if (_canExecute == null)
		{
			return true;
		}
		
		bool? result = _canExecute?.Invoke(parameter);

		return result != null && result != false;
	}
}