using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string str = "\"train_no\":\"5500000T5243\",\"station_train_code\":\"T52\",\"start_station_telecode\":\"SHH\",\"start_station_name\":\"上海\",\"end_station_telecode\":\"WMR\",\"end_station_name\":\"??³ľ????\",\"from_station_telecode\":\"SHH\",\"from_station_name\":\"上海\",\"to_station_telecode\":\"SQF\",\"to_station_name\":\"商丘\",\"start_time\":\"20:25\",\"arrive_time\":\"04:50\",\"day_difference\":\"1\",\"train_class_name\":\"\",\"lishi\":\"08:25\",\"canWebBuy\":\"N\",\"lishiValue\":\"505\",\"yp_info\":\"1000003000400000000010000000003000000000\",\"control_train_day\":\"20300303\",\"start_train_date\":\"20140902\",\"seat_feature\":\"W3431333\",\"yp_ex\":\"10401030\",\"train_seat_feature\":\"3\",\"seat_types\":\"1413\",\"location_code\":\"H1\",\"from_station_no\":\"01\",\"to_station_no\":\"10\",\"control_day\":19,\"sale_time\":\"1200\",\"is_support_card\":\"0\",\"yz_num\":\"无\",\"rz_num\":\"--\",\"yw_num\":\"无\",\"rw_num\":\"无\",\"gr_num\":\"--\",\"zy_num\":\"--\",\"ze_num\":\"--\",\"tz_num\":\"--\",\"gg_num\":\"--\",\"yb_num\":\"--\",\"wz_num\":\"无\",\"qt_num\":\"--\",\"swz_num\":\"--\"";


            QueryLeftNewDTO dto = new QueryLeftNewDTO(str);

            var pros = dto.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            foreach(var p in pros)
            {
                Console.WriteLine(p.Name+":"+p.GetValue(dto));
            }

            Console.ReadLine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
