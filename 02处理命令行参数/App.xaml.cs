using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _02处理命令行参数
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // At this point, the main window has been created but not shown.
            FileViewer win = new FileViewer();

            if (e.Args.Length > 0)
            {
                string file = e.Args[0];
                if (File.Exists(file))
                {
                    // Configure the main window.                    
                    win.LoadFile(file);
                }
            }

            // This window will automatically be set as the Application.MainWindow.
            win.Show();
        }
    }
    
}
