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

namespace VisualBrush_03
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double o = 1.0; //不透明度计数器
        private void CloneVisual(object sender, RoutedEventArgs e)
        {
            VisualBrush vBrush = new VisualBrush(this.realButon);
            Rectangle rect = new Rectangle();
            rect.Width = realButon.ActualWidth;
            rect.Height = realButon.ActualHeight;
            rect.Fill = vBrush;
            rect.Opacity = o; //不透明度
            o -= 0.2;

            this.stackPanelRight.Children.Add(rect);
        }
    }
}
