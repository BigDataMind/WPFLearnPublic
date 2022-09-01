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

namespace _08._5MultiDataTrigger
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Student> stu = new List<Student>()
            {
               new Student(){ Name ="Tim",ID = 1,Age=18},
               new Student(){ Name ="Tom",ID = 2,Age=19},
               new Student(){ Name ="Timothy",ID = 3,Age=20},
               new Student(){ Name ="San Zhang",ID = 4,Age=21},
               new Student(){ Name ="Si Li",ID = 5,Age=22},
               new Student(){ Name ="Hua Li",ID = 6,Age=23},

            };

            this.listBoxStudent.ItemsSource = stu;
        }
    }

    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
