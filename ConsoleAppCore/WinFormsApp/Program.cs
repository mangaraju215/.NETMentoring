using System;
using System.Drawing;
using System.Windows.Forms;
using Greetings;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        using (var form = new Form
        {
            Text = "WinForms Greeting",
            StartPosition = FormStartPosition.CenterScreen,
            ClientSize = new Size(440, 170)
        })
        {
            var label = new Label { Text = "&Username", AutoSize = true };
            var username = new TextBox { Dock = DockStyle.Top, AccessibleName = "Username" };
            var greet = new Button { Text = "&Greet", AutoSize = true, Enabled = false };
            var output = new Label { Dock = DockStyle.Fill, AutoEllipsis = true };
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(16), ColumnCount = 1, RowCount = 4 };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.Controls.Add(label, 0, 0);
            layout.Controls.Add(username, 0, 1);
            layout.Controls.Add(greet, 0, 2);
            layout.Controls.Add(output, 0, 3);

            username.TextChanged += (sender, e) => greet.Enabled = !string.IsNullOrWhiteSpace(username.Text);
            greet.Click += (sender, e) => output.Text = Greeting.Greet(username.Text);
            form.AcceptButton = greet;
            form.Controls.Add(layout);
            form.ActiveControl = username;
            Application.Run(form);
        }
    }
}
