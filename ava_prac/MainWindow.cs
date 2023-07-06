using System;
using System.Reflection;
using Avalonia.Controls;

namespace ava_prac.Views;

public class MainWindow : Window
{    
	public MainWindow()
	{
		var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("iconfile") ?? throw new ArgumentException("Icon file could not be loaded!");
		Title = "Aioninan-App";
		Icon = new(s);
		Content = new MainView();
	}
}