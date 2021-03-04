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
using System.Windows.Threading;

namespace SimpleFlipperDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ValuePanel content1;
        ValuePanel content2;

        MainWindowModel model;

        DispatcherTimer timer;

        bool bFlip = true;

        public MainWindow()
        {
            InitializeComponent();

            model = this.Resources["model"] as MainWindowModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            content1 = new ValuePanel();
            content2 = new ValuePanel();

            content1.ValueName = "Temperature";
            content1.Unit = "℃";
            content1.ValueColor = Brushes.OrangeRed;

            content2.ValueName = "Humidity";
            content2.Unit = "%";
            content2.ValueColor = Brushes.SkyBlue;

            Binding content1_binding_value = new Binding("Temp");
            content1.SetBinding(ValuePanel.ValueProperty, content1_binding_value);

            Binding content2_binding_value = new Binding("Humi");
            content2.SetBinding(ValuePanel.ValueProperty, content2_binding_value);

            flipper.SetFrontContent(content1);
            flipper.SetRearContent(content2);

            ChangeRearValue();  // Initialize value panel

            StartTimer();
        }

        private void ChangeRearValue()
        {
            Random r = new Random();

            if(bFlip)
            {
                double temperature = r.Next(100, 200) * 0.1;
                model.Temp = string.Format("{0:F1}", temperature);
            }
            else
            {
                double humi = r.Next(0, 1000) * 0.1;
                model.Humi = string.Format("{0:F1}", humi);
            }

            bFlip = !bFlip;
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ChangeRearValue();

            flipper.Flip();
        }
    }
}
