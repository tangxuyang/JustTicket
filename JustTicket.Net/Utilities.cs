using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JustTicket.Net
{
    public class Utilities
    {
        /// <summary>
        /// 从流中获取字符串
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string GetString(Stream stream)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StreamReader sr = new StreamReader(stream);
            while (!sr.EndOfStream)
            {
                stringBuilder.Append(sr.ReadLine());
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 保存流为文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string SaveAsFile(Stream stream,string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.CreateNew);
            byte[] buffer = new byte[10240];
            int n;
            while ((n = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, n);
            }
            fileStream.Close();
            
            return Path.GetFullPath(filename);
        }
    }
}
