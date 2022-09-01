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

namespace _01DataTemplate
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

        //选择变化事件处理器
        private void listBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarListItemView view = e.AddedItems[0] as CarListItemView;
            if (view != null)
            {
                this.detailView.Car = view.Car;
            }
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

            foreach (Car car in cars)
            {
                CarListItemView view = new CarListItemView();
                view.Car = car;
                this.listBoxCars.Items.Add(view);
            }
        }
    }


}
