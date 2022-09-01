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

namespace _01._3附加属性
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Human human = new Human();
            School.SetGradeProperty(human, 6);
            int grade = School.GetGradeProperty(human);
            MessageBox.Show(grade.ToString());
        }
    }

    class School :DependencyObject
    {


        public static int GetGradeProperty(DependencyObject obj)
        {
            return (int)obj.GetValue(MyPropertyProperty);
        }

        public static void SetGradeProperty(DependencyObject obj, int value)
        {
            obj.SetValue(MyPropertyProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.RegisterAttached("MyProperty", typeof(int), typeof(School), new PropertyMetadata(0));


    }

    class Human :DependencyObject
    {

    }
}
