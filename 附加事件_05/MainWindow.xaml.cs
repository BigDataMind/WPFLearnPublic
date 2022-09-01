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

namespace 附加事件_05
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //为外层grid添加路由事件侦听器
            Student.AddNameChangedHandler(this.gridMain, new RoutedEventHandler(this.StudentNameChangedEventHandler));
        }

        //grid捕抓到NameChangedEvent后的处理器
        private void StudentNameChangedEventHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Student).Id.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student() { Id = 101, Name = "Tim" };
            stu.Name = "Tom";

            //准备事件消息并发送路由事件
            RoutedEventArgs args = new RoutedEventArgs(Student.NameChangedEvent, stu);
            this.button1.RaiseEvent(args);
        }

        
    }

    public class Student
    {
        //声明定义路由事件
        public static readonly RoutedEvent NameChangedEvent =
            EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Student));
        
        //为界面元素添加路由事件侦听
        public static void AddNameChangedHandler(DependencyObject d,RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if (e != null)
            {
                e.AddHandler(Student.NameChangedEvent,h);
            }
        }

        //移除侦听
        public static void RemoveNameChangedHandler(DependencyObject d,RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if (e != null)
            {
                e.RemoveHandler(Student.NameChangedEvent, h);
            }
        }        
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
