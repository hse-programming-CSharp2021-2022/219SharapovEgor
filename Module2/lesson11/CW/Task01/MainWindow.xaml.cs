using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var newButton = new Button();
            newButton.Width = 50;
            newButton.Height = 50;
            newButton.Content = "ПРявя КНОПЬКА";
            newButton.HorizontalAlignment = HorizontalAlignment.Right;
            newButton.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(newButton);
            newButton.Click += rightButton_Click;
            newButton.Margin = new Thickness(100,100,100,100);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Кнопка нажата!");
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Правая кнопка нажата!?");
        }
    }
}
