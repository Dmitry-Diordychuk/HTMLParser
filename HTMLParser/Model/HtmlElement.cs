using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HTMLParser.Model;

public class HtmlElement : INotifyPropertyChanged
{
	private string? _tag;
	
	public event PropertyChangedEventHandler? PropertyChanged;

	public string? Tag
	{
		get => _tag;
		set => SetField(ref _tag, value);
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value)) return false;
		field = value;
		OnPropertyChanged(propertyName);
		return true;
	}
}