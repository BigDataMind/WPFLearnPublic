using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _03窗口之间交互
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private List<Document> documents = new List<Document>();

        public List<Document> Documents
        {
            get { return documents; }
            set { documents = value; }
        }
    }
}
