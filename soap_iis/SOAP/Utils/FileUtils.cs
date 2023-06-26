using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SOAP.Utils
{
    public static class FileUtils
    {
        public static void CreateFile(string path,  string content)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            using(StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(content);
                sw.Flush();
            }
        }
    }
}