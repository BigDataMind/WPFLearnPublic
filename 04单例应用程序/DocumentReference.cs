using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04单例应用程序
{
    public class DocumentReference
    {
        private Document document;

        public Document Document
        {
            get { return document; }
            set { document = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DocumentReference(Document document, string name)
        {
            Document = document;
            Name = name;
            
        }
    }
}
