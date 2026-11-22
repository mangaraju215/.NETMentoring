using System.Windows;
using System.Windows.Controls;
using Greetings;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, e) => UsernameTextBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                return;
            }

            GreetingTextBlock.Text = Greeting.Greet(UsernameTextBox.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (GreetButton != null)
            {
                GreetButton.IsEnabled = !string.IsNullOrWhiteSpace(UsernameTextBox.Text);
            }
        }
    }
}
