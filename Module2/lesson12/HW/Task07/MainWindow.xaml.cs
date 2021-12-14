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

namespace Task07
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            points = new PointCollection();
            polyline.Points = points;
        }

        PointCollection points;

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            polyline.Points.Add(new Point(sliderX.Value + 10, 320 - sliderY.Value));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            polyline.Points.Clear();
        }

    }
}
