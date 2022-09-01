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

namespace WpfApplTimeButton_03
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

        //事件处理器
        private void ReportTimeHandler(object sender, ReprotTimeEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            string timeStr = e.ClickTime.ToLongTimeString();
            string content = string.Format("{0} 到时 {1}", timeStr, element.Name);
            this.listBox.Items.Add(content);

            //Bucket stop here
            if (element == this.grid_2)
            {
                e.Handled = true;
            }

        }

    }

    //用于承载时间的事件参数
    public class ReprotTimeEventArgs : RoutedEventArgs
    {
        public ReprotTimeEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }

        public DateTime ClickTime { get; set; }
    }


    public class TimeButton : Button
    {
        //声明注册路由事件
        public static readonly RoutedEvent ReportTimeEvent =
            EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReprotTimeEventArgs>), typeof(TimeButton));

        //CLR事件包装器
        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }

        //激发路由事件
        protected override void OnClick()
        {
            base.OnClick();
            ReprotTimeEventArgs args = new ReprotTimeEventArgs(ReportTimeEvent, this);
            args.ClickTime = DateTime.Now;
            this.RaiseEvent(args);
        }
    }
}
