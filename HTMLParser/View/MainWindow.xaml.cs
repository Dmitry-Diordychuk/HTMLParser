using System.IO;
using System.Windows;

namespace HTMLParser.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			TextBox.Text = File.ReadAllText("TestHTML.txt");
		}
	}
}