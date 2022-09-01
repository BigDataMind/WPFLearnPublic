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

namespace 冒泡路由_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected int eventCounter = 0;
       

        private void SomethingClick(object sender, MouseButtonEventArgs e)
        {
            eventCounter++;
            string message = "#" + eventCounter.ToString() + ":\r\n" +
                "Sender: " + sender.ToString() + "\r\n" +
                "Source: " + e.Source + "\r\n" +
                "Original Source: " + e.OriginalSource;
            lstMessages.Items.Add(message);
            e.Handled = (bool)chkHandle.IsChecked;
        }

        private void cmbClear_Click(object sender, RoutedEventArgs e)
        {
            eventCounter = 0;
            lstMessages.Items.Clear();
        }
    }
}
