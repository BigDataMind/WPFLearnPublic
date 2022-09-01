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

namespace _01._1._1依赖属性包装器
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Student stu = new Student();
        public MainWindow()
        {
            InitializeComponent();
            
            //1-1 1-2
            //Binding binding = new Binding("Text") { Source = textBox1};

            //1-1
            //BindingOperations.SetBinding(stu, Student.NameProperty, binding);

            //1-2
            //textBox2.SetBinding(TextBox.TextProperty, binding);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //1-1
            //MessageBox.Show(stu.GetValue(Student.NameProperty).ToString());

            //1-3
            stu.Name = this.textBox1.Text;
            this.textBox2.Text = stu.Name;
        }
    }

    public class Student:DependencyObject
    {
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Student));

        //NameProperty 包装器 1-3
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
    }
}
