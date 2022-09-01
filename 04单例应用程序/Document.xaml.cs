using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace _04单例应用程序
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Document : Window
    {
        private DocumentReference docRef;
        public Document()
        {
            InitializeComponent();
        }

        public void LoadFile(DocumentReference docRef)
        {
            this.docRef = docRef;
            this.Content = File.ReadAllText(docRef.Name);
            this.Title = docRef.Name;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ((WpfApp)Application.Current).Documents.Remove(docRef);
        }
    }
}
