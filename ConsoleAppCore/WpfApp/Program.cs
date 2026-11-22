using System;
using System.Windows;
using System.Windows.Controls;
using Greetings;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        var username = new TextBox();
        var label = new Label { Content = "_Username", Target = username };
        var greet = new Button
        {
            Content = "_Greet",
            IsDefault = true,
            IsEnabled = false,
            HorizontalAlignment = HorizontalAlignment.Left,
            Padding = new Thickness(12, 4, 12, 4),
            Margin = new Thickness(0, 8, 0, 8)
        };
        var output = new TextBlock { TextWrapping = TextWrapping.Wrap };
        var layout = new StackPanel { Margin = new Thickness(16) };
        layout.Children.Add(label);
        layout.Children.Add(username);
        layout.Children.Add(greet);
        layout.Children.Add(output);

        var window = new Window
        {
            Title = "WPF Greeting",
            Width = 460,
            Height = 220,
            WindowStartupLocation = WindowStartupLocation.CenterScreen,
            Content = new ScrollViewer { Content = layout }
        };
        username.TextChanged += (sender, e) => greet.IsEnabled = !string.IsNullOrWhiteSpace(username.Text);
        greet.Click += (sender, e) => output.Text = Greeting.Format(username.Text);
        window.Loaded += (sender, e) => username.Focus();

        new Application().Run(window);
    }
}
