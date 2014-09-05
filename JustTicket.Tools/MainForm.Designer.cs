namespace JustTicket.Tools
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tb_CityFilter = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_GetCityList = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.pb_VerificationCode = new System.Windows.Forms.PictureBox();
            this.btn_GetVerification = new System.Windows.Forms.Button();
            this.tb_VerificationCode = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_LoginResult = new System.Windows.Forms.Label();
            this.btn_GetPassenger = new System.Windows.Forms.Button();
            this.tb_TrainFilter = new System.Windows.Forms.TextBox();
            this.btn_TrainSearch = new System.Windows.Forms.Button();
            this.tb_To = new System.Windows.Forms.TextBox();
            this.tb_From = new System.Windows.Forms.TextBox();
            this.tb_Date = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btn_Buy = new System.Windows.Forms.Button();
            this.btn_CheckOrderInfo = new System.Windows.Forms.Button();
            this.tb_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_VerificationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Main
            // 
            this.tb_Main.Controls.Add(this.tabPage1);
            this.tb_Main.Controls.Add(this.tabPage2);
            this.tb_Main.Controls.Add(this.tabPage3);
            this.tb_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Main.Location = new System.Drawing.Point(0, 0);
            this.tb_Main.Name = "tb_Main";
            this.tb_Main.SelectedIndex = 0;
            this.tb_Main.Size = new System.Drawing.Size(1020, 597);
            this.tb_Main.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tb_CityFilter);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btn_GetCityList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(618, 568);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "City";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tb_CityFilter
            // 
            this.tb_CityFilter.Location = new System.Drawing.Point(490, 74);
            this.tb_CityFilter.Name = "tb_CityFilter";
            this.tb_CityFilter.Size = new System.Drawing.Size(100, 21);
            this.tb_CityFilter.TabIndex = 2;
            this.tb_CityFilter.TextChanged += new System.EventHandler(this.tb_CityFilter_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(3, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(612, 464);
            this.dataGridView1.TabIndex = 1;
            // 
            // btn_GetCityList
            // 
            this.btn_GetCityList.Location = new System.Drawing.Point(504, 20);
            this.btn_GetCityList.Name = "btn_GetCityList";
            this.btn_GetCityList.Size = new System.Drawing.Size(86, 23);
            this.btn_GetCityList.TabIndex = 1;
            this.btn_GetCityList.Text = "GetCityList";
            this.btn_GetCityList.UseVisualStyleBackColor = true;
            this.btn_GetCityList.Click += new System.EventHandler(this.btn_GetCityList_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(618, 568);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trains";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_CheckOrderInfo);
            this.tabPage3.Controls.Add(this.btn_Buy);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Controls.Add(this.tb_TrainFilter);
            this.tabPage3.Controls.Add(this.btn_TrainSearch);
            this.tabPage3.Controls.Add(this.tb_To);
            this.tabPage3.Controls.Add(this.tb_From);
            this.tabPage3.Controls.Add(this.tb_Date);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.btn_GetPassenger);
            this.tabPage3.Controls.Add(this.lb_LoginResult);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.btn_Login);
            this.tabPage3.Controls.Add(this.pb_VerificationCode);
            this.tabPage3.Controls.Add(this.btn_GetVerification);
            this.tabPage3.Controls.Add(this.tb_VerificationCode);
            this.tabPage3.Controls.Add(this.tb_Password);
            this.tabPage3.Controls.Add(this.tb_UserName);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1012, 571);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Passengers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(29, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Passengers";
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(86, 146);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(65, 23);
            this.btn_Login.TabIndex = 5;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // pb_VerificationCode
            // 
            this.pb_VerificationCode.Location = new System.Drawing.Point(320, 33);
            this.pb_VerificationCode.Name = "pb_VerificationCode";
            this.pb_VerificationCode.Size = new System.Drawing.Size(100, 50);
            this.pb_VerificationCode.TabIndex = 5;
            this.pb_VerificationCode.TabStop = false;
            // 
            // btn_GetVerification
            // 
            this.btn_GetVerification.Location = new System.Drawing.Point(498, 46);
            this.btn_GetVerification.Name = "btn_GetVerification";
            this.btn_GetVerification.Size = new System.Drawing.Size(65, 23);
            this.btn_GetVerification.TabIndex = 3;
            this.btn_GetVerification.Text = "Refresh";
            this.btn_GetVerification.UseVisualStyleBackColor = true;
            this.btn_GetVerification.Click += new System.EventHandler(this.btn_GetVerification_Click);
            // 
            // tb_VerificationCode
            // 
            this.tb_VerificationCode.Location = new System.Drawing.Point(452, 98);
            this.tb_VerificationCode.Name = "tb_VerificationCode";
            this.tb_VerificationCode.Size = new System.Drawing.Size(100, 21);
            this.tb_VerificationCode.TabIndex = 4;
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(190, 76);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(100, 21);
            this.tb_Password.TabIndex = 1;
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(190, 33);
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(100, 21);
            this.tb_UserName.TabIndex = 1;
            this.tb_UserName.Text = "tangxuyang.hi@163.com";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "VerificationCode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "UserName:";
            // 
            // lb_LoginResult
            // 
            this.lb_LoginResult.AutoSize = true;
            this.lb_LoginResult.Location = new System.Drawing.Point(188, 151);
            this.lb_LoginResult.Name = "lb_LoginResult";
            this.lb_LoginResult.Size = new System.Drawing.Size(0, 12);
            this.lb_LoginResult.TabIndex = 9;
            // 
            // btn_GetPassenger
            // 
            this.btn_GetPassenger.Location = new System.Drawing.Point(399, 151);
            this.btn_GetPassenger.Name = "btn_GetPassenger";
            this.btn_GetPassenger.Size = new System.Drawing.Size(87, 23);
            this.btn_GetPassenger.TabIndex = 6;
            this.btn_GetPassenger.Text = "GetPassengers";
            this.btn_GetPassenger.UseVisualStyleBackColor = true;
            this.btn_GetPassenger.Click += new System.EventHandler(this.btn_GetPassenger_Click);
            // 
            // tb_TrainFilter
            // 
            this.tb_TrainFilter.Location = new System.Drawing.Point(86, 401);
            this.tb_TrainFilter.Name = "tb_TrainFilter";
            this.tb_TrainFilter.Size = new System.Drawing.Size(100, 21);
            this.tb_TrainFilter.TabIndex = 11;
            // 
            // btn_TrainSearch
            // 
            this.btn_TrainSearch.Location = new System.Drawing.Point(406, 401);
            this.btn_TrainSearch.Name = "btn_TrainSearch";
            this.btn_TrainSearch.Size = new System.Drawing.Size(75, 23);
            this.btn_TrainSearch.TabIndex = 10;
            this.btn_TrainSearch.Text = "Search";
            this.btn_TrainSearch.UseVisualStyleBackColor = true;
            this.btn_TrainSearch.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // tb_To
            // 
            this.tb_To.Location = new System.Drawing.Point(406, 335);
            this.tb_To.Name = "tb_To";
            this.tb_To.Size = new System.Drawing.Size(100, 21);
            this.tb_To.TabIndex = 9;
            // 
            // tb_From
            // 
            this.tb_From.Location = new System.Drawing.Point(239, 336);
            this.tb_From.Name = "tb_From";
            this.tb_From.Size = new System.Drawing.Size(100, 21);
            this.tb_From.TabIndex = 8;
            // 
            // tb_Date
            // 
            this.tb_Date.Location = new System.Drawing.Point(86, 335);
            this.tb_Date.Name = "tb_Date";
            this.tb_Date.Size = new System.Drawing.Size(100, 21);
            this.tb_Date.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "To";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "From";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "Date";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 454);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(612, 114);
            this.dataGridView2.TabIndex = 18;
            // 
            // btn_Buy
            // 
            this.btn_Buy.Location = new System.Drawing.Point(821, 454);
            this.btn_Buy.Name = "btn_Buy";
            this.btn_Buy.Size = new System.Drawing.Size(75, 23);
            this.btn_Buy.TabIndex = 19;
            this.btn_Buy.Text = "Buy";
            this.btn_Buy.UseVisualStyleBackColor = true;
            this.btn_Buy.Click += new System.EventHandler(this.btn_Buy_Click);
            // 
            // btn_CheckOrderInfo
            // 
            this.btn_CheckOrderInfo.Location = new System.Drawing.Point(650, 453);
            this.btn_CheckOrderInfo.Name = "btn_CheckOrderInfo";
            this.btn_CheckOrderInfo.Size = new System.Drawing.Size(109, 23);
            this.btn_CheckOrderInfo.TabIndex = 20;
            this.btn_CheckOrderInfo.Text = "CheckOrderInfo";
            this.btn_CheckOrderInfo.UseVisualStyleBackColor = true;
            this.btn_CheckOrderInfo.Click += new System.EventHandler(this.btn_CheckOrderInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 597);
            this.Controls.Add(this.tb_Main);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tb_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_VerificationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tb_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_GetCityList;
        private System.Windows.Forms.TextBox tb_CityFilter;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tb_VerificationCode;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pb_VerificationCode;
        private System.Windows.Forms.Button btn_GetVerification;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_LoginResult;
        private System.Windows.Forms.Button btn_GetPassenger;
        private System.Windows.Forms.TextBox tb_TrainFilter;
        private System.Windows.Forms.Button btn_TrainSearch;
        private System.Windows.Forms.TextBox tb_To;
        private System.Windows.Forms.TextBox tb_From;
        private System.Windows.Forms.TextBox tb_Date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_Buy;
        private System.Windows.Forms.Button btn_CheckOrderInfo;
    }
}

