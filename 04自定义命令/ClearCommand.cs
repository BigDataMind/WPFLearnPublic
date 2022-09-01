using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _04自定义命令
{
    public class ClearCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        //命令执行，带有与业务逻辑相关的Clear逻辑
        public void Execute(object parameter)
        {
            IView view = parameter as IView;
            if (view != null)
            {
                view.Clear();
            }
        }
    }

    //自定义命令源
    public class MyCommandSource : UserControl, ICommandSource
    {
        public ICommand Command { get; set; }

        public object CommandParameter { get; set; }

        public IInputElement CommandTarget { get; set; }

        //在组件被单击时连带执行命令
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            //在命令目标上执行命令
            if (this.CommandTarget != null)
            {
                this.Command.Execute(this.CommandTarget);
            }
        }
    }
}
