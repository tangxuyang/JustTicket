using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JustTicket.Net;
using JustTicket;
using System.IO;

namespace JustTicketWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HttpCommunicator com = new HttpCommunicator();
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            string fileName = "test" + DateTime.Now.Ticks + ".png";
                

                //获取验证码
            string filename = Utilities.SaveAsFile(com.SendRequest(Strings.VerificationCodeUrl), fileName);
                 
                pictureBox1.Image = null;
                pictureBox1.Image = new Bitmap(filename);
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //com.Method = "POST";
            //string verificationCode = textBox1.Text;
            //com. = "loginUserDTO.user_name=txyzqc&userDTO.password=1qaz2wsx&randCode=" + verificationCode;

            //Stream stream = com.SendRequest(Strings.LoginUrl);
            //string result = Utilities.GetString(stream);
            //if (result.Contains("loginCheck") && result.Contains("Y"))
            //{
            //    MessageBox.Show("登陆成功");
            //}
            //else
            //{
            //    MessageBox.Show("登陆失败");
            //}
        }
    }
}
