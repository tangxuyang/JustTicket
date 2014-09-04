using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    /// <summary>
    /// 车次DTO
    /// </summary>
    [Obsolete("使用json.net")]
    public class QueryLeftNewDTO : DTO
    {
        /// <summary>
        /// 车号，类似240000G10106，页面不可见
        /// </summary>
        public string Train_NO
        {
            get
            {
                return Get("train_no");
            }
            set
            {
                Set("train_no",value);
            }
        }

        /// <summary>
        /// 车次号，通常使用的，如K154 
        /// </summary>
        public string Station_Train_Code
        {
            get
            {
                return Get("station_train_code");
            }
            set
            {
                Set("station_train_code", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Start_Station_Telecode
        {
            get
            {
                return Get("start_station_telecode");
            }
            set
            {
                Set("start_station_telecode", value);
            }
        }

        /// <summary>
        /// 始发站名字
        /// </summary>
        public string Start_Station_Name
        {
            get
            {
                return Get("start_station_name");
            }
            set
            {
                Set("start_station_name", value);
            }
        }

        /// <summary>
        /// 终点站。。。
        /// </summary>
        public string End_Station_Telecode
        {
            get
            {
                return Get("end_station_Telecode");
            }
            set
            {
                Set("end_station_Telecode", value);
            }
        }

        /// <summary>
        /// 终点站名字
        /// </summary>
        public string End_Station_Name
        {
            get
            {
                return Get("end_station_name");
            }
            set
            {
                Set("end_station_name",value);
            }
        }

        public string From_Station_Telecode
        {
            get
            {
                return Get("from_station_telecode");
            }
            set
            {
                Set("from_station_telecode", value);
            }
        }

        /// <summary>
        /// 出发站名字
        /// </summary>
        public string From_Station_Name
        {
            get
            {
                return Get("from_station_name");
            }
            set
            {
                Set("from_station_name",value);
            }
        }

        public string To_Station_Telecode
        {
            get
            {
                return Get("to_station_telcode");
            }
            set
            {
                Set("to_station_telcode", value);
            }
        }

        /// <summary>
        /// 目的地站名字
        /// </summary>
        public string To_Station_Name
        {
            get
            {
                return Get("to_station_name");
            }
            set
            {
                Set("to_station_name", value);
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string Start_Time
        {
            get
            {
                return Get("start_time");
            }
            set
            {
                Set("start_time", value);
            }
        }

        /// <summary>
        /// 到达时间
        /// </summary>
        public string Arrive_Time
        {
            get
            {
                return Get("arrive_time");
            }
            set
            {
                Set("arrive_time", value);
            }
        }

        public int Day_Difference
        {
            get
            {
                //Key = " day_difference "
                return int.Parse(Get("day_difference"));
            }
            set
            {
                Set("day_difference", value.ToString());
            }
        }

        public string Train_Class_Name
        {
            get
            {
                return Get("train_class_name");
            }
            set
            {
                Set("train_class_name", value);
            }
        }

        /// <summary>
        /// 历时
        /// </summary>
        public string LiShi
        {
            get
            {
                return Get("lishi");
            }
            set
            {
                Set("lishi", value);
            }
        }

        /// <summary>
        /// 可否晚上买
        /// </summary>
        public bool CanWebBuy
        {
            get
            {
                if (Get("canWebBuy") == "N")
                    return false;
                else
                    return true;
            }
            set
            {
                if (!value)
                    Set("canWebBuy", "N");
                else
                    Set("canWebBuy", "Y");
            }
        }

        public string LiShiValue
        {
            get
            {
                return Get("lishivalue");
            }
            set
            {
                Set("lishivalue", value);
            }
        }

        /// <summary>
        /// 猜测，余票欣喜
        /// </summary>
        public string YP_Info
        {
            get
            {
                return Get("yp_info");
            }
            set
            {
                Set("yp_info", value);
            }
        }

        public string Control_Train_Day
        {
            get
            {
                return Get("control_train_day");
            }
            set
            {
                Set("control_train_day", value);
            }
        }

        public string Start_Train_Date
        {
            get
            {
                return Get("start_train_date");
            }
            set
            {
                Set("start_train_date", value);
            }
        }

        public string Seat_feature
        {
            get
            {
                return Get("seat_feature");
            }
            set
            {
                Set("seat_feature", value);
            }
        }

        public string YP_EX
        {
            get
            {
                return Get("yp_ex");
            }
            set
            {
                Set("yp_ex", value);
            }
        }

        public string Train_Seat_Feature
        {
            get
            {
                return Get("train_seat_feature");
            }
            set
            {
                Set("train_seat_feature", value);
            }
        }

        public string Seat_Types
        {
            get
            {
                return Get("seat_types");
            }
            set
            {
                Set("seat_types", value);
            }
        }

        public string Location_Code
        {
            get
            {
                return Get("location_code");
            }
            set
            {
                Set("location_code", value);
            }
        }

        public int From_Station_NO
        {
            get
            {
                return int.Parse(Get("from_station_no"));
            }
            set
            {
                Set("from_station_no", value.ToString());
            }
        }

        public int To_Station_NO
        {
            get
            {
                return int.Parse(Get("to_station_no"));
            }
            set
            {
                Set("to_station_no", value.ToString());
            }
        }  

        public int Control_Day
        {
            get
            {
                return int.Parse(Get("control_day"));
            }
            set
            {
                Set("control_day", value.ToString());
            }
        }

        public string Sale_Time
        {
            get
            {
                return Get("sale_time");
            }
            set
            {
                Set("sale_time", value);
            }
        }

        public bool Is_Support_Card
        {
            get
            {
                if (Get("is_support_card") == "1")
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    Set("is_support_card", "1");
                else
                    Set("is_support_card", "0");
            }
        }

        /// <summary>
        /// 硬座数
        /// </summary>
        public string YZ_Num
        {
            get
            {
                return Get("yz_num");
            }
            set
            {
                Set("yz_num",value);
            }
        }

        /// <summary>
        /// 软座数
        /// </summary>
        public string RZ_Num
        {
            get
            {
                return Get("rz_num");
            }
            set
            {
                Set("rz_num", value);
            }
        }

        /// <summary>
        /// 硬卧数
        /// </summary>
        public string YW_Num
        {
            get
            {
                return Get("yw_num");
            }
            set
            {
                Set("yw_num", value);
            }
        }

        /// <summary>
        /// 软卧数
        /// </summary>
        public string RW_Num
        {
            get
            {
                return Get("rw_num");
            }
            set
            {
                Set("rw_num", value);
            }
        }

        /// <summary>
        /// 不清楚
        /// </summary>
        public string GR_Num
        {
            get
            {
                return Get("gr_num");
            }
            set
            {
                Set("gr_num", value);
            }
        }

        /// <summary>
        /// 一等座数
        /// </summary>
        public string ZY_Num
        {
            get
            {
                return Get("zy_num");
            }
            set
            {
                Set("zy_num", value);
            }
        }

        /// <summary>
        /// 二等座数
        /// </summary>
        public string ZE_Num
        {
            get
            {
                return Get("ze_num");
            }
            set
            {
                Set("ze_num", value);
            }
        }

        /// <summary>
        /// 特等座数
        /// </summary>
        public string TZ_Num
        {
            get
            {
                return Get("tz_num");
            }
            set
            {
                Set("tz_num", value);
            }
        }

        /// <summary>
        /// 高级软卧数
        /// </summary>
        public string GG_Num
        {
            get
            {
                return Get("gg_num");
            }
            set
            {
                Set("gg_num", value);
            }
        }

        /// <summary>
        /// 不清楚
        /// </summary>
        public string YB_Num
        {
            get
            {
                return Get("yb_num");
            }
            set
            {
                Set("yb_num", value);
            }
        }

        /// <summary>
        /// 无座数
        /// </summary>
        public string WZ_Num
        {
            get
            {
                return Get("wz_num");
            }
            set
            {
                Set("wz_num", value);
            }
        }

        /// <summary>
        /// 其他数
        /// </summary>
        public string QT_Num
        {
            get
            {
                return Get("qt_num");
            }
            set
            {
                Set("qt_num", value);
            }
        }

        /// <summary>
        /// 商务座
        /// </summary>
        public string SWZ_Num
        {
            get
            {
                return Get("swz_num");
            }
            set
            {
                Set("swz_num", value);
            }
        }

        public QueryLeftNewDTO(string str) : base(str)
        { }
    }
}
