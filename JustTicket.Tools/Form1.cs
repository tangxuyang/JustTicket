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
using JustTicket.Tools.DTO;
using Newtonsoft.Json;

namespace JustTicket.Tools
{
    public partial class Form1 : Form
    {
        Engine2 engine;
        private List<PassengerDTO> passengers;
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
            dt.Columns.Add("YP_Info");
            dt.Columns.Add("Location_Code");

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
            //List<QueryLeftNewDTO> dtos = DTOHelper.GetDTOPartialInArrayItem<QueryLeftNewDTO>(trains, "queryLeftNewDTO");
            var data = JsonConvert.DeserializeObject<TrainsSearchResultDTO>(trains).data;

            List<QueryLeftNewDTO2> dtos = new List<QueryLeftNewDTO2>();
            foreach(var v in data)
            {
                dtos.Add(v.queryLeftNewDTO);

            }

            foreach (var dto in dtos)
            {
                //QueryLeftNewDTO dto = new QueryLeftNewDTO(queryLeftNewDTOStr);
                DataRow row = dt.NewRow();
                row["车次"] = dto.station_train_code;
                row["YP_Info"] = dto.yp_info;
                row["Location_Code"] = dto.location_code;
                row["出发站_到达站"] = dto.from_station_name + "-" + dto.to_station_name;
                row["出发时间"] = dto.start_time;
                row["历时"] = dto.lishi;
                row["商务座"] = dto.swz_num;
                row["特等座"] = dto.tz_num;
                row["一等座"] = dto.zy_num;
                row["二等座"] = dto.ze_num;
                row["高级软卧"] = dto.gg_num;
                row["软卧"] = dto.rw_num;
                row["硬卧"] = dto.yw_num;
                row["软座"] = dto.rz_num;
                row["硬座"] = dto.yz_num;
                row["无座"] = dto.wz_num;
                row["其他"] = dto.qt_num;
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

        private void btn_GetVerification_Click(object sender, EventArgs e)
        {
            string verificationCodeUrl = "https://kyfw.12306.cn/otn/passcodeNew/getPassCodeNew?module=login&amp;rand=sjrand";
            string fileName = "verificationCode.png";
            string action = "<actions><DownFile IsDeleteExist=\"true\"><Method>Get</Method><Url>"+verificationCodeUrl+"</Url><FileName>"+fileName+"</FileName></DownFile></actions>";

            Engine2 engine = new Engine2();
            engine.Execute(action);

            FileStream fs = new FileStream(fileName, FileMode.Open);
            Bitmap bitmap = new Bitmap(fs);
            pb_VerificationCode.Image = bitmap;
            fs.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string userName = tb_UserName.Text;
            string password = tb_Password.Text;
            string verificationCode = tb_VerificationCode.Text;
            string requestBody = string.Format("loginUserDTO.user_name={0}&amp;userDTO.password={1}&amp;randCode={2}",userName,password,verificationCode);
            string action = @"
            <actions>
                <GlobalVariables>
                    <Result></Result>
                </GlobalVariables>
                <RequestString Name=""login"">
                    <Url>https://kyfw.12306.cn/otn/login/loginAysnSuggest</Url>
                    <Method>Post</Method>
                        <RequestBody>"+requestBody+"</RequestBody>"+
            @"</RequestString>
            <Assignment>
                <Variable>Result</Variable>
                <Value>$login.Result</Value>
            </Assignment>
            <StringReplace Name=""sr"">
              <SourceString>{Result}</SourceString>
              <OldString>&quot;</OldString>
              <NewString>\&quot;</NewString>
            </StringReplace>
            <Assignment>
              <Variable>Result</Variable>
              <Value>$sr.ResultString</Value>
            </Assignment>
            <If Condition=""&quot;{Result}&quot;.Contains(&quot;\&quot;loginCheck\&quot;:\&quot;Y\&quot;&quot;)"">
              <Begin>
                <DownFile IsDeleteExist=""true"">
                  <Url>
                    https://kyfw.12306.cn/otn/confirmPassenger/getPassengerDTOs
                  </Url>
                  <Method>Post</Method>
                  <FileName>passengers.txt</FileName>
                </DownFile>
              </Begin>
            </If>
   </actions>";

            engine.Execute(action);

            string fileName = "passengers.txt";
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string content = sr.ReadToEnd();
                sr.Close();
                //normal_passengers
                int index = content.IndexOf("normal_passengers");
                index = content.IndexOf('[', index);//find [ index
                int index2 = content.IndexOf(']', index);
                content = content.Substring(index, index2 - index + 1);

                passengers = DTOHelper.GetDTOs<PassengerDTO>(content);

                #region 显示在DataGridView中

                //DataTable dt = new DataTable();
                //dt.Columns.Add("Name");
                //dt.Columns.Add("Sex");

                //DataRow row;
                //foreach(var passenger in passengers)
                //{
                //    row = dt.NewRow();
                //    row["Name"] = passenger.Passenger_Name;
                //    row["Sex"] = passenger.Sex_Name;
                //    dt.Rows.Add(row);
                //}

                //BindingSource bs = new BindingSource();
                //bs.DataSource = dt;
                //dataGridView3.DataSource = bs;
                #endregion

                int i = 0;
                index = 0;
                int top = 20;
                foreach(var passenger in passengers)
                {
                    CheckBox cb = new CheckBox();
                    cb.Width = 80;
                    if((80*i+20)>groupBox1.Width-20)
                    {
                        top += 20;
                        i = 0;
                    }
                    cb.Left = 80*i+20;
                    cb.Top = top;
                    cb.Text = passenger.Passenger_Name;
                    cb.Name = index.ToString();
                    groupBox1.Controls.Add(cb);
                    i++;
                    index++;
                }
            }
        }
    }    
}
