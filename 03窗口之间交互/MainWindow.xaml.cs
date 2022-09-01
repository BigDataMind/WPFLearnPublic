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

namespace _03窗口之间交互
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

        private void cmdCreate_Click(object sender, RoutedEventArgs e)
        {
            Document doc = new Document();

            //使Documnt实例窗口显示在主窗口上
            doc.Owner = this; 
            doc.Show();
            ((App)Application.Current).Documents.Add(doc);
        }

        private void cmdUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (Document doc in ((App)Application.Current).Documents)
            {
                doc.SetContent("Refreshed at " + DateTime.Now.ToLongTimeString() + ".");
            }
        }
    }
}
