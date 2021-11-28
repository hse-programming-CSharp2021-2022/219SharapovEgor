namespace task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string Function(string str)
        {
            var newstr = str.ToCharArray();
            for (int i = newstr.Length - 1; i >= 0; i--)
            {
                if (newstr[i] != ' ')
                {
                    newstr[i] = ' ';
                    break;
                }
            }
            return new string(newstr);
        }

        async private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Function(label1.Text);
            if (label1.Text[0] == ' ')
            {
                timer1.Stop();
                for (Opacity = 1; Opacity > 0; Opacity -= 0.1)
                {
                    await Task.Delay(100);
                }
                await Task.Delay(1500);
                label1.Text = "Кот уже ушел!";
                for (Opacity = 0; Opacity < 1; Opacity += 0.1)
                {
                    await Task.Delay(100);
                }
            }
        }
    }
}