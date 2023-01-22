using System;
using System.Collections.ObjectModel;
using System.Windows;
using HtmlAgilityPack;
using HTMLParser.Infrastructure;
using HTMLParser.Model;
using HtmlAttribute = HtmlAgilityPack.HtmlAttribute;

namespace HTMLParser.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
	private HtmlParser _parser;
	private HtmlElement _selectedElement;
	private HtmlAttribute _selectedAttribute;
	public ObservableCollection<HtmlElement> HtmlPath { get; } = new();

	private RelayCommand? _addHtmlElementCommand;
	private RelayCommand? _removeHtmlElementCommand;

	public HtmlElement SelectedElement
	{
		get => _selectedElement;
		set
		{
			if (AddHtmlElementCommand.CanExecute(value))
			{
				AddHtmlElementCommand.Execute(value);
			}
		}
	}

	public HtmlAttribute SelectedAttribute
	{
		get => _selectedAttribute;
		set => SetField(ref _selectedAttribute, value);
	}

	public RelayCommand AddHtmlElementCommand
	{
		get
		{
			return _addHtmlElementCommand ??= new RelayCommand((o) =>
			{
				if (o is HtmlElement element)
				{
					if (element.Clone() is HtmlElement clone)
					{
						HtmlPath.Add(clone);
					}
				}
			});
		}
	}
	
	public RelayCommand RemoveHtmlElementCommand
	{
		get
		{
			return _removeHtmlElementCommand ??= new RelayCommand((o) =>
			{
				if (o is HtmlElement element)
				{
					HtmlPath.Remove(element);
				}
			});
		}
	}
	
}