namespace JustTicket.Tools
{
    partial class Form1
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_GetCityList = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tb_CityFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Date = new System.Windows.Forms.TextBox();
            this.tb_From = new System.Windows.Forms.TextBox();
            this.tb_To = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tb_TrainFilter = new System.Windows.Forms.TextBox();
            this.tb_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Main
            // 
            this.tb_Main.Controls.Add(this.tabPage1);
            this.tb_Main.Controls.Add(this.tabPage2);
            this.tb_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Main.Location = new System.Drawing.Point(0, 0);
            this.tb_Main.Name = "tb_Main";
            this.tb_Main.SelectedIndex = 0;
            this.tb_Main.Size = new System.Drawing.Size(626, 594);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tb_TrainFilter);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.btn_Search);
            this.tabPage2.Controls.Add(this.tb_To);
            this.tabPage2.Controls.Add(this.tb_From);
            this.tabPage2.Controls.Add(this.tb_Date);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(618, 568);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trains";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_GetCityList
            // 
            this.btn_GetCityList.Location = new System.Drawing.Point(504, 20);
            this.btn_GetCityList.Name = "btn_GetCityList";
            this.btn_GetCityList.Size = new System.Drawing.Size(86, 23);
            this.btn_GetCityList.TabIndex = 0;
            this.btn_GetCityList.Text = "GetCityList";
            this.btn_GetCityList.UseVisualStyleBackColor = true;
            this.btn_GetCityList.Click += new System.EventHandler(this.btn_GetCityList_Click);
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
            // tb_CityFilter
            // 
            this.tb_CityFilter.Location = new System.Drawing.Point(490, 74);
            this.tb_CityFilter.Name = "tb_CityFilter";
            this.tb_CityFilter.Size = new System.Drawing.Size(100, 21);
            this.tb_CityFilter.TabIndex = 2;
            this.tb_CityFilter.TextChanged += new System.EventHandler(this.tb_CityFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "To";
            // 
            // tb_Date
            // 
            this.tb_Date.Location = new System.Drawing.Point(80, 29);
            this.tb_Date.Name = "tb_Date";
            this.tb_Date.Size = new System.Drawing.Size(100, 21);
            this.tb_Date.TabIndex = 1;
            // 
            // tb_From
            // 
            this.tb_From.Location = new System.Drawing.Point(233, 30);
            this.tb_From.Name = "tb_From";
            this.tb_From.Size = new System.Drawing.Size(100, 21);
            this.tb_From.TabIndex = 1;
            // 
            // tb_To
            // 
            this.tb_To.Location = new System.Drawing.Point(400, 29);
            this.tb_To.Name = "tb_To";
            this.tb_To.Size = new System.Drawing.Size(100, 21);
            this.tb_To.TabIndex = 1;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(400, 95);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(3, 159);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(612, 406);
            this.dataGridView2.TabIndex = 3;
            // 
            // tb_TrainFilter
            // 
            this.tb_TrainFilter.Location = new System.Drawing.Point(80, 95);
            this.tb_TrainFilter.Name = "tb_TrainFilter";
            this.tb_TrainFilter.Size = new System.Drawing.Size(100, 21);
            this.tb_TrainFilter.TabIndex = 4;
            this.tb_TrainFilter.TextChanged += new System.EventHandler(this.tb_TrainSearch_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 594);
            this.Controls.Add(this.tb_Main);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tb_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox tb_To;
        private System.Windows.Forms.TextBox tb_From;
        private System.Windows.Forms.TextBox tb_Date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_TrainFilter;
    }
}

