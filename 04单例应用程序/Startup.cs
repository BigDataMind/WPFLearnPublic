using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic.ApplicationServices;

namespace _04单例应用程序
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            SingleInstanceApplicationWrapper wrapper = new SingleInstanceApplicationWrapper();
            wrapper.Run(args);
        }
    }

    public class SingleInstanceApplicationWrapper : WindowsFormsApplicationBase
    {
        public SingleInstanceApplicationWrapper()
        {
            //启用单实例应用程序
            this.IsSingleInstance = true;
        }

        //创建WPF应用程序类实例
        private WpfApp app;
        protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs eventArgs)
        {
            string extension = ".testDoc";
            string title = "SingleInstanceApplication";
            string extensionDescription = "A Test Document";
            // Uncomment this line to create the file registration.
            // In Windows Vista, you'll need to run the application
            // as an administrator.            
            FileRegistrationHelper.SetFileAssociation(
              extension, title + "." + extensionDescription);

            app = new WpfApp();
            app.Run();
            return false;
            
        }

        /// <summary>
        /// 调用命令行参数显示新窗口
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs e)
        {
            if (e.CommandLine.Count>0)
            {
                app.ShowDocument(e.CommandLine[0]);
            }
        }


    }

    public class  WpfApp :Application
    {
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);

            //加载主窗口
            DocumentList list = new DocumentList();
            this.MainWindow = list;
            list.Show();

            //通过指定参数加载文档窗口
            if (e.Args.Length>0)
            {
                ShowDocument(e.Args[0]);
            }

        }

        // An ObservableCollection is a List that provides notification
        // when items are added, deleted, or removed. It's preferred for data binding.
        private ObservableCollection<DocumentReference> documents =
            new ObservableCollection<DocumentReference>();
        public ObservableCollection<DocumentReference> Documents
        {
            get { return documents; }
            set { documents = value; }
        }

        public void ShowDocument(string fileName)
        {
            try
            {
                Document doc = new Document();
                DocumentReference docRef = new DocumentReference(doc, fileName);
                doc.LoadFile(docRef);
                doc.Owner = this.MainWindow;
                doc.Show();
                doc.Activate();
                Documents.Add(docRef);


            }
            catch
            {

                MessageBox.Show("不能加载文档窗口");
            }
        }
    }

}
