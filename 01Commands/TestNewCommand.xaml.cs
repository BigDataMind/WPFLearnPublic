using System.Windows;
using System.Windows.Input;

namespace _01Commands
{
    /// <summary>
    /// TestNewCommand.xaml 的交互逻辑
    /// </summary>
    public partial class TestNewCommand : Window
    {
        public TestNewCommand()
        {
            InitializeComponent();

            #region 使用代码生成命令绑定

            //Create the binding
            //CommandBinding bindingNew = new CommandBinding(ApplicationCommands.New);

            //Attach  the event handler
            //bindingNew.Executed += NewCommand;

            //Register the binding
            //this.CommandBindings.Add(bindingNew);

            #endregion


        }

        private void NewCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New command triggered by " + e.Source.ToString());
        }
    }
}
