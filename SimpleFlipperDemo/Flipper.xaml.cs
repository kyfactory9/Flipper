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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleFlipperDemo
{
    /// <summary>
    /// Interaction logic for Flipper.xaml
    /// </summary>
    public partial class Flipper : UserControl
    {
        private bool bFlip = true;

        DoubleAnimation outAnimation = null;
        DoubleAnimation inAnimation = null;

        public Flipper()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            rear.RenderTransform = new ScaleTransform(1, 0);

            outAnimation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(200));
            inAnimation = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(200));
            inAnimation.BeginTime = TimeSpan.FromMilliseconds(200);
        }

        public void SetFrontContent(UIElement content)
        {
            front.Child = content;
        }

        public void SetRearContent(UIElement content)
        {
            rear.Child = content;
        }

        private void FlipContent(UIElement content1, UIElement content2)
        {
            if ((content1 == null) || (content2 == null)) return;

            Storyboard sbFlip = new Storyboard();
            Storyboard.SetTargetProperty(sbFlip, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

            content1.RenderTransform = new ScaleTransform(1, 1);
            content2.RenderTransform = new ScaleTransform(1, 0);

            Storyboard.SetTargetName(outAnimation, (content1 as FrameworkElement).Name);
            Storyboard.SetTargetName(inAnimation, (content2 as FrameworkElement).Name);

            sbFlip.Children.Add(outAnimation);
            sbFlip.Children.Add(inAnimation);

            sbFlip.Begin(this);
        }

        public void Flip()
        {
            if(!bFlip)
            {
                FlipContent(rear, front);
            }
            else
            {
                FlipContent(front, rear);
            }

            bFlip = !bFlip;
        }
    }
}
