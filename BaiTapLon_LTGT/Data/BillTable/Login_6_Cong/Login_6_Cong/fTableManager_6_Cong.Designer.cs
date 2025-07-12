namespace Login_6_Cong
{
    partial class fTableManager_6_Cong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTableManager_6_Cong));
            this.menuStrip_6_Cong = new System.Windows.Forms.MenuStrip();
            this.MnsAdmin_6_Cong = new System.Windows.Forms.ToolStripMenuItem();
            this.MnsAccinf_6_Cong = new System.Windows.Forms.ToolStripMenuItem();
            this.MnsInf_6_Cong = new System.Windows.Forms.ToolStripMenuItem();
            this.MnsLogout_6_Cong = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3_6_Cong = new System.Windows.Forms.Panel();
            this.lsv_Bill_6_Cong = new System.Windows.Forms.ListView();
            this.clFoodname_6_Cong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clCount_6_Cong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clPrice_6_Cong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clTotal_6_Cong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4_6_Cong = new System.Windows.Forms.Panel();
            this.txtTotal_6_Cong = new System.Windows.Forms.TextBox();
            this.btn_Pay_6_Cong = new System.Windows.Forms.Button();
            this.panel2_6_Cong = new System.Windows.Forms.Panel();
            this.nm_CountFood_6_Cong = new System.Windows.Forms.NumericUpDown();
            this.btn_AddFood_6_Cong = new System.Windows.Forms.Button();
            this.cbb_Food_6_Cong = new System.Windows.Forms.ComboBox();
            this.cbb_Category_6_Cong = new System.Windows.Forms.ComboBox();
            this.flpTable_6_Cong = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip_6_Cong.SuspendLayout();
            this.panel3_6_Cong.SuspendLayout();
            this.panel4_6_Cong.SuspendLayout();
            this.panel2_6_Cong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_CountFood_6_Cong)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip_6_Cong
            // 
            this.menuStrip_6_Cong.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_6_Cong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnsAdmin_6_Cong,
            this.MnsAccinf_6_Cong});
            this.menuStrip_6_Cong.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_6_Cong.Name = "menuStrip_6_Cong";
            this.menuStrip_6_Cong.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip_6_Cong.Size = new System.Drawing.Size(893, 28);
            this.menuStrip_6_Cong.TabIndex = 0;
            this.menuStrip_6_Cong.Text = "menuStrip1";
            // 
            // MnsAdmin_6_Cong
            // 
            this.MnsAdmin_6_Cong.Name = "MnsAdmin_6_Cong";
            this.MnsAdmin_6_Cong.Size = new System.Drawing.Size(67, 24);
            this.MnsAdmin_6_Cong.Text = "Admin";
            this.MnsAdmin_6_Cong.Click += new System.EventHandler(this.MnsAdmin_6_Cong_Click);
            // 
            // MnsAccinf_6_Cong
            // 
            this.MnsAccinf_6_Cong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnsInf_6_Cong,
            this.MnsLogout_6_Cong});
            this.MnsAccinf_6_Cong.Name = "MnsAccinf_6_Cong";
            this.MnsAccinf_6_Cong.Size = new System.Drawing.Size(151, 24);
            this.MnsAccinf_6_Cong.Text = "Thông tin tài khoản";
            // 
            // MnsInf_6_Cong
            // 
            this.MnsInf_6_Cong.Name = "MnsInf_6_Cong";
            this.MnsInf_6_Cong.Size = new System.Drawing.Size(210, 26);
            this.MnsInf_6_Cong.Text = "Thông tin cá nhân";
            this.MnsInf_6_Cong.Click += new System.EventHandler(this.MnsInf_6_Cong_Click_1);
            // 
            // MnsLogout_6_Cong
            // 
            this.MnsLogout_6_Cong.Name = "MnsLogout_6_Cong";
            this.MnsLogout_6_Cong.Size = new System.Drawing.Size(210, 26);
            this.MnsLogout_6_Cong.Text = "Đăng xuất";
            this.MnsLogout_6_Cong.Click += new System.EventHandler(this.MnsLogout_6_Cong_Click);
            // 
            // panel3_6_Cong
            // 
            this.panel3_6_Cong.Controls.Add(this.lsv_Bill_6_Cong);
            this.panel3_6_Cong.Location = new System.Drawing.Point(455, 97);
            this.panel3_6_Cong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3_6_Cong.Name = "panel3_6_Cong";
            this.panel3_6_Cong.Size = new System.Drawing.Size(413, 274);
            this.panel3_6_Cong.TabIndex = 3;
            // 
            // lsv_Bill_6_Cong
            // 
            this.lsv_Bill_6_Cong.BackColor = System.Drawing.Color.Snow;
            this.lsv_Bill_6_Cong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clFoodname_6_Cong,
            this.clCount_6_Cong,
            this.clPrice_6_Cong,
            this.clTotal_6_Cong});
            this.lsv_Bill_6_Cong.HideSelection = false;
            this.lsv_Bill_6_Cong.Location = new System.Drawing.Point(0, 0);
            this.lsv_Bill_6_Cong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsv_Bill_6_Cong.Name = "lsv_Bill_6_Cong";
            this.lsv_Bill_6_Cong.Size = new System.Drawing.Size(412, 271);
            this.lsv_Bill_6_Cong.TabIndex = 0;
            this.lsv_Bill_6_Cong.UseCompatibleStateImageBehavior = false;
            this.lsv_Bill_6_Cong.View = System.Windows.Forms.View.Details;
            // 
            // clFoodname_6_Cong
            // 
            this.clFoodname_6_Cong.Text = "Tên món";
            this.clFoodname_6_Cong.Width = 94;
            // 
            // clCount_6_Cong
            // 
            this.clCount_6_Cong.Text = "Số Lượng";
            this.clCount_6_Cong.Width = 77;
            // 
            // clPrice_6_Cong
            // 
            this.clPrice_6_Cong.Text = "Đơn giá";
            this.clPrice_6_Cong.Width = 96;
            // 
            // clTotal_6_Cong
            // 
            this.clTotal_6_Cong.Text = "Thành tiền";
            this.clTotal_6_Cong.Width = 138;
            // 
            // panel4_6_Cong
            // 
            this.panel4_6_Cong.Controls.Add(this.txtTotal_6_Cong);
            this.panel4_6_Cong.Controls.Add(this.btn_Pay_6_Cong);
            this.panel4_6_Cong.Location = new System.Drawing.Point(455, 378);
            this.panel4_6_Cong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4_6_Cong.Name = "panel4_6_Cong";
            this.panel4_6_Cong.Size = new System.Drawing.Size(413, 59);
            this.panel4_6_Cong.TabIndex = 4;
            // 
            // txtTotal_6_Cong
            // 
            this.txtTotal_6_Cong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal_6_Cong.Location = new System.Drawing.Point(4, 7);
            this.txtTotal_6_Cong.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal_6_Cong.Name = "txtTotal_6_Cong";
            this.txtTotal_6_Cong.ReadOnly = true;
            this.txtTotal_6_Cong.Size = new System.Drawing.Size(276, 30);
            this.txtTotal_6_Cong.TabIndex = 8;
            // 
            // btn_Pay_6_Cong
            // 
            this.btn_Pay_6_Cong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pay_6_Cong.Location = new System.Drawing.Point(287, 2);
            this.btn_Pay_6_Cong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Pay_6_Cong.Name = "btn_Pay_6_Cong";
            this.btn_Pay_6_Cong.Size = new System.Drawing.Size(124, 47);
            this.btn_Pay_6_Cong.TabIndex = 3;
            this.btn_Pay_6_Cong.Text = "Thanh toán";
            this.btn_Pay_6_Cong.UseVisualStyleBackColor = true;
            this.btn_Pay_6_Cong.Click += new System.EventHandler(this.btn_Pay_6_Cong_Click);
            // 
            // panel2_6_Cong
            // 
            this.panel2_6_Cong.Controls.Add(this.nm_CountFood_6_Cong);
            this.panel2_6_Cong.Controls.Add(this.btn_AddFood_6_Cong);
            this.panel2_6_Cong.Controls.Add(this.cbb_Food_6_Cong);
            this.panel2_6_Cong.Controls.Add(this.cbb_Category_6_Cong);
            this.panel2_6_Cong.Location = new System.Drawing.Point(455, 27);
            this.panel2_6_Cong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2_6_Cong.Name = "panel2_6_Cong";
            this.panel2_6_Cong.Size = new System.Drawing.Size(413, 64);
            this.panel2_6_Cong.TabIndex = 2;
            // 
            // nm_CountFood_6_Cong
            // 
            this.nm_CountFood_6_Cong.Location = new System.Drawing.Point(337, 23);
            this.nm_CountFood_6_Cong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nm_CountFood_6_Cong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_CountFood_6_Cong.Name = "nm_CountFood_6_Cong";
            this.nm_CountFood_6_Cong.Size = new System.Drawing.Size(51, 22);
            this.nm_CountFood_6_Cong.TabIndex = 3;
            this.nm_CountFood_6_Cong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_AddFood_6_Cong
            // 
            this.btn_AddFood_6_Cong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddFood_6_Cong.Location = new System.Drawing.Point(228, 10);
            this.btn_AddFood_6_Cong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_AddFood_6_Cong.Name = "btn_AddFood_6_Cong";
            this.btn_AddFood_6_Cong.Size = new System.Drawing.Size(83, 47);
            this.btn_AddFood_6_Cong.TabIndex = 2;
            this.btn_AddFood_6_Cong.Text = "Thêm món";
            this.btn_AddFood_6_Cong.UseVisualStyleBackColor = true;
            this.btn_AddFood_6_Cong.Click += new System.EventHandler(this.btn_AddFood_6_Cong_Click);
            // 
            // cbb_Food_6_Cong
            // 
            this.cbb_Food_6_Cong.FormattingEnabled = true;
            this.cbb_Food_6_Cong.Location = new System.Drawing.Point(25, 33);
            this.cbb_Food_6_Cong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_Food_6_Cong.Name = "cbb_Food_6_Cong";
            this.cbb_Food_6_Cong.Size = new System.Drawing.Size(161, 24);
            this.cbb_Food_6_Cong.TabIndex = 1;
            // 
            // cbb_Category_6_Cong
            // 
            this.cbb_Category_6_Cong.FormattingEnabled = true;
            this.cbb_Category_6_Cong.Location = new System.Drawing.Point(25, 2);
            this.cbb_Category_6_Cong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_Category_6_Cong.Name = "cbb_Category_6_Cong";
            this.cbb_Category_6_Cong.Size = new System.Drawing.Size(161, 24);
            this.cbb_Category_6_Cong.TabIndex = 0;
            this.cbb_Category_6_Cong.SelectedIndexChanged += new System.EventHandler(this.cbb_Category_6_Cong_SelectedIndexChanged);
            // 
            // flpTable_6_Cong
            // 
            this.flpTable_6_Cong.AutoScroll = true;
            this.flpTable_6_Cong.Location = new System.Drawing.Point(12, 27);
            this.flpTable_6_Cong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpTable_6_Cong.Name = "flpTable_6_Cong";
            this.flpTable_6_Cong.Size = new System.Drawing.Size(437, 410);
            this.flpTable_6_Cong.TabIndex = 5;
            // 
            // fTableManager_6_Cong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(893, 450);
            this.Controls.Add(this.flpTable_6_Cong);
            this.Controls.Add(this.panel2_6_Cong);
            this.Controls.Add(this.panel4_6_Cong);
            this.Controls.Add(this.panel3_6_Cong);
            this.Controls.Add(this.menuStrip_6_Cong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_6_Cong;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "fTableManager_6_Cong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý";
            this.menuStrip_6_Cong.ResumeLayout(false);
            this.menuStrip_6_Cong.PerformLayout();
            this.panel3_6_Cong.ResumeLayout(false);
            this.panel4_6_Cong.ResumeLayout(false);
            this.panel4_6_Cong.PerformLayout();
            this.panel2_6_Cong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nm_CountFood_6_Cong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_6_Cong;
        private System.Windows.Forms.ToolStripMenuItem MnsAdmin_6_Cong;
        private System.Windows.Forms.ToolStripMenuItem MnsAccinf_6_Cong;
        private System.Windows.Forms.ToolStripMenuItem MnsInf_6_Cong;
        private System.Windows.Forms.ToolStripMenuItem MnsLogout_6_Cong;
        private System.Windows.Forms.Panel panel3_6_Cong;
        private System.Windows.Forms.Panel panel4_6_Cong;
        private System.Windows.Forms.ListView lsv_Bill_6_Cong;
        private System.Windows.Forms.Panel panel2_6_Cong;
        private System.Windows.Forms.Button btn_AddFood_6_Cong;
        private System.Windows.Forms.ComboBox cbb_Food_6_Cong;
        private System.Windows.Forms.ComboBox cbb_Category_6_Cong;
        private System.Windows.Forms.NumericUpDown nm_CountFood_6_Cong;
        private System.Windows.Forms.FlowLayoutPanel flpTable_6_Cong;
        private System.Windows.Forms.Button btn_Pay_6_Cong;
        private System.Windows.Forms.ColumnHeader clFoodname_6_Cong;
        private System.Windows.Forms.ColumnHeader clCount_6_Cong;
        private System.Windows.Forms.ColumnHeader clPrice_6_Cong;
        private System.Windows.Forms.ColumnHeader clTotal_6_Cong;
        private System.Windows.Forms.TextBox txtTotal_6_Cong;
    }
}