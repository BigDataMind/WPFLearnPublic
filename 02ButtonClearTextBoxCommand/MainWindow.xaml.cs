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

namespace _02ButtonClearTextBoxCommand
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCommand();
        }

        //声明定义命令
        private RoutedCommand clearCommand = new RoutedCommand("Clear", typeof(MainWindow));

        private void InitializeCommand()
        {
            //把命令赋值给命令源并指定快捷键 Alt+C
            this.button1.Command = this.clearCommand;
            this.clearCommand.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            //指定命令目标
            this.button1.CommandTarget = this.textBoxA;

            //创建命令关联
            CommandBinding cb = new CommandBinding();
            cb.Command = this.clearCommand;  //只关注clearCommand相关的事情
            cb.CanExecute += new CanExecuteRoutedEventHandler(Cb_CanExecute);
            cb.Executed += new ExecutedRoutedEventHandler(Cb_Executed);

            //把命令关联安置在外围控件上
            this.stackPanel.CommandBindings.Add(cb);
        }
        
        //当命令送达目标后，此方法被调用
        private void Cb_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.textBoxA.Clear();

            //避免向上传影响性能
            e.Handled = true;
        }


        //当探测命令是否可执行时，此方法被调用
        private void Cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxA.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }

            e.Handled = true;
        }
    }

    
}
