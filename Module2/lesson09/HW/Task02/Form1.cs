namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "ListBox";

            listBox1.Visible = false;
            buttonDelete.Visible = false;
        }


        private string[] _lines = new string[] { "один", "два", "три", "четыре", "пять"};
        private string[] _newLines = null;

        private void buttonInit_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(_lines);
            _newLines = _lines;
            buttonDelete.Visible = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Список пуст или\nнет выделенного элемента!");
                return;
            }

            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}