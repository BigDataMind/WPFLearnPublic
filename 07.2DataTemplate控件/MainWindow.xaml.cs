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

namespace _07._2DataTemplate控件
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
            TextBlock tb = this.cp.ContentTemplate.FindName("textBlock", this.cp) as TextBlock;
            MessageBox.Show(tb.Text);

            //直接使用底层数据 
            //Student stu = this.cp.Content as Student;
            //MessageBox.Show(stu.Name);
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public bool HasJob { get; set; }
    }
}
