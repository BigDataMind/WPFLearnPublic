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

namespace _02DataTemplate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialCarList();
        }

        private void InitialCarList()
        {
            List<Car> cars = new List<Car>()
            {
                new Car(){ Name = "奥迪",Automaker="法拉第",Year="1990",TopSpeed="340"},
                new Car(){ Name = "宝马",Automaker="法拉第",Year="1991",TopSpeed="360"},
                new Car(){ Name = "奔驰",Automaker="法拉第",Year="1992",TopSpeed="380"},
                new Car(){ Name = "兰博基尼",Automaker="法拉第",Year="1993",TopSpeed="400"}
            };

            //填充数据
            this.listBoxCars.ItemsSource = cars;

        }

        
    }
}
