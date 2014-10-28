using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using JustTicket.Tools.DTO;
using System.IO;
using Newtonsoft.Json;

namespace JustTicket.Tools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string fileName = "queryT.txt";
            //FileStream fs = new FileStream(fileName, FileMode.Open);
            //StreamReader sr = new StreamReader(fs);
            //string str = sr.ReadToEnd();
            //var result =  JsonConvert.DeserializeObject<TrainsSearchResultDTO>(str);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
