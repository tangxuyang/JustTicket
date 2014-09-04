using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    /// <summary>
    /// 乘客DTO
    /// </summary>
    [Obsolete("使用json.net")]
    public class PassengerDTO : DTO
    {
        public string Code
        {
            get
            {
                return Get("code");
            }
            set
            {
                Set("code", value);
            }
        }

        /// <summary>
        /// 乘客名字
        /// </summary>
        public string Passenger_Name
        {
            get
            {
                return Get("passenger_name");
            }
            set
            {
                Set("passenger_name", value);
            }
        }

        /// <summary>
        /// 性别编码
        /// </summary>
        public string Sex_Code
        {
            get
            {
                return Get("sex_code");
            }
            set
            {
                Set("sex_code", value);
            }
        }

        /// <summary>
        /// 性别名称
        /// </summary>
        public string Sex_Name
        {
            get
            {
                return Get("sex_name");
            }
            set
            {
                Set("sex_name", value);
            }
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Born_Date
        {
            get
            {
                return Get("born_date");
            }
            set
            {
                Set("born_date", value);
            }
        }

        /// <summary>
        /// 国家编码
        /// </summary>
        public string Country_Code
        {
            get
            {
                return Get("country_code");
            }
            set
            {
                Set("country_code", value);
            }
        }

        /// <summary>
        /// 乘客ID类型编码
        /// </summary>
        public string Passenger_ID_Type_Code
        {
            get
            {
                return Get("passenger_id_type_code");
            }
            set
            {
                Set("passenger_id_type_code", value);
            }
        }

        /// <summary>
        /// 乘客ID类型名称
        /// </summary>
        public string Passenger_ID_Type_Name
        {
            get
            {
                return Get("passenger_id_type_name");
            }
            set
            {
                Set("passenger_id_type_name", value);
            }
        }

        /// <summary>
        /// 乘客ID号
        /// </summary>
        public string Passenger_ID_NO
        {
            get
            {
                return Get("passenger_id_no");
            }
            set
            {
                Set("passenger_id_no", value);
            }
        }

        /// <summary>
        /// 乘客类型
        /// </summary>
        public string Passenger_Type
        {
            get
            {
                return Get("passenger_type");
            }
            set
            {
                Set("passenger_type", value);
            }
        }

        /// <summary>
        /// 乘客标识
        /// </summary>
        public string Passenger_Flag
        {
            get
            {
                return Get("passenger_flag");
            }
            set
            {
                Set("passenger_flag", value);
            }
        }

        /// <summary>
        /// 乘客类型名称
        /// </summary>
        public string Passenger_Type_Name
        {
            get
            {
                return Get("passenger_type_name");
            }
            set
            {
                Set("passenger_type_name", value);
            }
        }

        /// <summary>
        /// 乘客手机号
        /// </summary>
        public string Mobile_NO
        {
            get
            {
                return Get("mobile_no");
            }
            set
            {
                Set("mobile_no", value);
            }
        }

        /// <summary>
        /// 乘客电话号
        /// </summary>
        public string Phone_NO
        {
            get
            {
                return Get("phone_no");
            }
            set
            {
                Set("phone_no", value);
            }
        }

        /// <summary>
        /// 乘客电子邮箱
        /// </summary>
        public string Email
        {
            get
            {
                return Get("email");
            }
            set
            {
                Set("email", value);
            }
        }

        /// <summary>
        /// 乘客地址
        /// </summary>
        public string Address
        {
            get
            {
                return Get("address");
            }
            set
            {
                Set("address", value);
            }
        }

        /// <summary>
        /// 乘客姓名拼音首字母
        /// </summary>
        public string First_Letter
        {
            get
            {
                return Get("first_letter");
            }
            set
            {
                Set("first_letter", value);
            }
        }

        /// <summary>
        /// 乘客。。。
        /// </summary>
        public string Total_Times
        {
            get
            {
                return Get("total_times");
            }
            set
            {
                Set("total_times", value);
            }
        }

        /// <summary>
        /// 。。。
        /// </summary>
        public string Index_ID
        {
            get
            {
                return Get("index_id");
            }
            set
            {
                Set("index_id", value);
            }
        }

        public PassengerDTO(string str):base(str)
        { }
    }
}
