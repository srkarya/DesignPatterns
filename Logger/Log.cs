using System;
using System.IO;
using System.Text;

namespace Logger
{
    public sealed class Log : ILog
    {
        private static Log instance = null;

        public static Log GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Log();
                }
                return instance;
            }
        }

        private Log()
        {
        }

        public void LogException(string message)
        {
            string dateFormat = "yyyyMMddHHmmss";
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToString(dateFormat));
            string filePath = string.Format(@"{0}{1}\{2}", AppDomain.CurrentDomain.BaseDirectory, "Logs", fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);

            FileInfo fi = new FileInfo(filePath);
            if (!fi.Directory.Exists)
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(sb.ToString());
                sw.Flush();
            }
        }
    }
}
