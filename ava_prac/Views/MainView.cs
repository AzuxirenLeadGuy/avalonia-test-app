using System;
using Avalonia.Controls;
using Avalonia.Layout;
namespace ava_prac.Views;

public class MainView : UserControl
{
    public MainView()
    {
        var apply_button = new Button() { Content = "Apply Theme!", HorizontalAlignment = HorizontalAlignment.Center, };
        var theme_box = new ComboBox()
        {
            ItemsSource = Enum.GetNames<ThemeKey>(),
            SelectedIndex = 0,
            HorizontalAlignment = HorizontalAlignment.Center,
        };
        Content = new StackPanel()
        {
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Center,
            Margin = new(25),
            Spacing = 25,
            Children =
            {
                new TextBlock() { Text = "Theme change test!" },
                new Slider() { Minimum = 1, Maximum = 100, },
                new Expander()
                {
                    Margin = new(25),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Content = new StackPanel()
                    {
                        Margin = new(25),
                        Spacing = 15,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Children =
                        {
                            new TextBlock() { Text = "Expander Test", },
                            new CheckBox() { Content = "Some box" },
                            new Button() { Content = "Some button" },
                            new ComboBox()
                            {
                                ItemsSource = new string[]{"Option 1", "Option 2", "Option 3"},
                                SelectedIndex = 0,
                            }
                        }
                    }
                },
                new TextBlock()
                {
                    Text = "Select your theme below!",
                    HorizontalAlignment = HorizontalAlignment.Center,
                },
                theme_box,
                apply_button
            }
        };
        apply_button.Tapped += (o, e) =>
        {
            var theme = (ThemeKey)theme_box.SelectedIndex;
            (App.Current as App)?.ApplyTheme(theme);
        };
    }
}