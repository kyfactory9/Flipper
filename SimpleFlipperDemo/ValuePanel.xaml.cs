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

namespace SimpleFlipperDemo
{
    /// <summary>
    /// Interaction logic for ValuePanel.xaml
    /// </summary>
    public partial class ValuePanel : UserControl
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(ValuePanel));
        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register("Unit", typeof(string), typeof(ValuePanel));
        public static readonly DependencyProperty ValueNameProperty = DependencyProperty.Register("ValueName", typeof(string), typeof(ValuePanel));

        public static readonly DependencyProperty ValueTextSizeProperty = DependencyProperty.Register("ValueTextSize", typeof(double), typeof(ValuePanel), new FrameworkPropertyMetadata(100.0));
        public static readonly DependencyProperty UnitTextSizeProperty = DependencyProperty.Register("UnitTextSize", typeof(double), typeof(ValuePanel), new FrameworkPropertyMetadata(30.0));
        public static readonly DependencyProperty ValueNameTextSizeProperty = DependencyProperty.Register("ValueNameTextSize", typeof(double), typeof(ValuePanel), new FrameworkPropertyMetadata(30.0));

        public static readonly DependencyProperty ValueColorProperty = DependencyProperty.Register("ValueColor", typeof(Brush), typeof(ValuePanel), new FrameworkPropertyMetadata(Brushes.White));

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        public string ValueName
        {
            get { return (string)GetValue(ValueNameProperty); }
            set { SetValue(ValueNameProperty, value); }
        }

        public double ValueTextSize
        {
            get { return (double)GetValue(ValueTextSizeProperty); }
            set { SetValue(ValueTextSizeProperty, value); }
        }

        public double UnitTextSize
        {
            get { return (double)GetValue(UnitTextSizeProperty); }
            set { SetValue(UnitTextSizeProperty, value); }
        }

        public double ValueNameTextSize
        {
            get { return (double)GetValue(ValueNameTextSizeProperty); }
            set { SetValue(ValueNameTextSizeProperty, value); }
        }

        public Brush ValueColor
        {
            get { return (Brush)GetValue(ValueColorProperty); }
            set { SetValue(ValueColorProperty, value); }
        }

        public ValuePanel()
        {
            InitializeComponent();
        }
    }
}
