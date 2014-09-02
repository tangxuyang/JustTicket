using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JustTicket.Engining;
using System.IO;

namespace JustTicket.Tools
{
    public partial class Form1 : Form
    {
        Engine2 engine;
        public Form1()
        {
            InitializeComponent();
            engine = new Engine2();
        }

        private void btn_GetCityList_Click(object sender, EventArgs e)
        {
            string fileName = "city.txt";
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            string str = "<actions><DownFile><Method>Get</Method><FileName>city.txt</FileName><Url>https://kyfw.12306.cn/otn/resources/js/framework/station_name.js?station_version=1.806</Url></DownFile></actions>";
            engine.Execute(str);

            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            sr.Close();
            content = content.Split('\'')[1];

            string[] strs = content.Split('@');
            DataTable dt = new DataTable();
            dt.Columns.Add("CityName");
            dt.Columns.Add("CityCode");
            DataRow row = null;
            foreach(var v in strs)
            {
                if (string.IsNullOrEmpty(v))
                    continue;

                string[] ss = v.Split('|');
                row = dt.NewRow();
                row["CityName"] = ss[1];
                row["CityCode"] = ss[2];

                dt.Rows.Add(row);
            }

            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dataGridView1.DataSource = source;
            
        }

        private void tb_CityFilter_TextChanged(object sender, EventArgs e)
        {
            BindingSource source = dataGridView1.DataSource as BindingSource;
            if (source == null)
                return;

            string filterString = tb_CityFilter.Text;


            source.Filter = string.Format("CityName like '%{0}%' or CityCode like '%{0}%'", filterString);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string fileName = "trains.txt";
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            string date = tb_Date.Text;
            string from = tb_From.Text;
            string to = tb_To.Text;
            ///otn/leftTicket/queryT?leftTicketDTO.train_date=2014-09-02&leftTicketDTO.from_station=SHH&leftTicketDTO.to_station=SQF&purpose_codes=ADULT
            string url = string.Format("https://kyfw.12306.cn/otn/leftTicket/queryT?leftTicketDTO.train_date={0}&amp;leftTicketDTO.from_station={1}&amp;leftTicketDTO.to_station={2}&amp;purpose_codes=ADULT",date,from,to);

            string action = "<actions><DownFile><Method>Get</Method><FileName>trains.txt</FileName><Url>"+url+"</Url></DownFile></actions>";

            Engine2 engine = new Engine2();
            engine.Execute(action);

            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string trains = sr.ReadToEnd();
            sr.Close();
            //queryLeftNewDTO

            //int index = 0;
            //int left, right, length;
            //string queryLeftNewDTOStr;
            DataTable dt = new DataTable();
            dt.Columns.Add("车次");
            dt.Columns.Add("出发站_到达站");
            dt.Columns.Add("出发时间");
            dt.Columns.Add("历时");
            dt.Columns.Add("商务座");
            dt.Columns.Add("特等座");
            dt.Columns.Add("一等座");
            dt.Columns.Add("二等座");
            dt.Columns.Add("高级软卧");
            dt.Columns.Add("软卧");
            dt.Columns.Add("硬卧");
            dt.Columns.Add("软座");
            dt.Columns.Add("硬座");
            dt.Columns.Add("无座");
            dt.Columns.Add("其他");
            
            //while((index = trains.IndexOf("queryLeftNewDTO",index))>-1)
            //{
            //    left = trains.IndexOf("{", index);
            //    right = trains.IndexOf("}", index) - 1;
            //    length = right - left;
            //    queryLeftNewDTOStr = trains.Substring(left + 1, length);
            List<QueryLeftNewDTO> dtos = DTOHelper.GetDTOPartialInArrayItem<QueryLeftNewDTO>(trains, "queryLeftNewDTO");
            foreach (var dto in dtos)
            {
                //QueryLeftNewDTO dto = new QueryLeftNewDTO(queryLeftNewDTOStr);
                DataRow row = dt.NewRow();
                row["车次"] = dto.Station_Train_Code;
                row["出发站_到达站"] = dto.From_Station_Name + "-" + dto.To_Station_Name;
                row["出发时间"] = dto.Start_Time;
                row["历时"] = dto.LiShi;
                row["商务座"] = dto.SWZ_Num;
                row["特等座"] = dto.TZ_Num;
                row["一等座"] = dto.ZY_Num;
                row["二等座"] = dto.ZE_Num;
                row["高级软卧"] = dto.GG_Num;
                row["软卧"] = dto.RW_Num;
                row["硬卧"] = dto.YW_Num;
                row["软座"] = dto.RZ_Num;
                row["硬座"] = dto.YZ_Num;
                row["无座"] = dto.WZ_Num;
                row["其他"] = dto.QT_Num;
                dt.Rows.Add(row);
            }
            //    index = right;
            //}
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView2.DataSource = bs;

        }

        private void tb_TrainSearch_TextChanged(object sender, EventArgs e)
        {
            string trainNo = tb_TrainFilter.Text;
            string filter = "车次 like '%" + trainNo + "%'";
            BindingSource bs = dataGridView2.DataSource as BindingSource;
            bs.Filter = filter;
        }
    }    
}
