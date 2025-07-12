using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_6_Cong
{
    public partial class fTableManager_6_Cong : Form
    {
        private fLogin_6_Cong flg_6_Cong;
        private string tableId_6_Cong;
        private double totalPrice_6_Cong = 0;
        public fTableManager_6_Cong(fLogin_6_Cong flg_6_Cong)
        {
            InitializeComponent();
            this.flg_6_Cong = flg_6_Cong;
            this.LoadTableData_6_Cong();
            this.LoadCategories_6_Cong();
        }

        public void LoadTableData_6_Cong()
        {
            string filePath_6_Cong = @"C:\BaiTapLon_LTGT\Data\ban_an.txt";
            if (File.Exists(filePath_6_Cong))
            {
                flpTable_6_Cong.Controls.Clear();
                var lines_6_Cong = File.ReadAllLines(filePath_6_Cong);
                // Bỏ qua dòng đầu tiên
                bool isFirstLine_6_Cong = true;
                // Duyệt qua từng dòng trong file
                foreach (var line_6_Cong in lines_6_Cong)
                {
                    // Bỏ qua dòng đầu tiên
                    if (isFirstLine_6_Cong)
                    {
                        isFirstLine_6_Cong = false;
                        continue; 
                    }

                    var columns_6_Cong = line_6_Cong.Split(',');

                    // Kiểm tra số lượng cột
                    if (columns_6_Cong.Length == 3)
                    {
                        string id_6_Cong = columns_6_Cong[0];
                        string tableName_6_Cong = columns_6_Cong[1];
                        string status_6_Cong = columns_6_Cong[2];

                        // Tạo nút cho bàn ăn
                        Button btn_6_Cong = new Button();
                        btn_6_Cong.Text = tableName_6_Cong + "\n" + status_6_Cong;
                        btn_6_Cong.Tag = id_6_Cong;
                        btn_6_Cong.Width = 100;
                        btn_6_Cong.Height = 100;
                        switch (status_6_Cong)
                        {
                            case "Trống":
                                btn_6_Cong.BackColor = Color.LightBlue;
                                break;
                            case "Đang sử dụng":
                                btn_6_Cong.BackColor = Color.LightYellow;
                                break;
                            case "Đã đặt trước":
                                btn_6_Cong.BackColor = Color.LightPink;
                                break;
                        }
                        // Đăng ký sự kiện click cho nút
                        btn_6_Cong.Click += new EventHandler(this.TableButton_Click_6_Cong);
                        flpTable_6_Cong.Controls.Add(btn_6_Cong);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìn thấy bàn ăn!");
            }
        }

        // Load danh mục món ăn từ file lên cbb_Category_6_Cong
        public void LoadCategories_6_Cong()
        {
            string filePath_6_Cong = @"C:\BaiTapLon_LTGT\Data\danh_muc.txt";
            if (File.Exists(filePath_6_Cong))
            {
                cbb_Category_6_Cong.Items.Clear();
                var lines_6_Cong = File.ReadAllLines(filePath_6_Cong);
                bool isFirstLine_6_Cong = true;
                foreach (var line_6_Cong in lines_6_Cong)
                {
                    if (isFirstLine_6_Cong)
                    {
                        isFirstLine_6_Cong = false;
                        continue;
                    }
                    var columns_6_Cong = line_6_Cong.Split(',');
                    cbb_Category_6_Cong.Items.Add(columns_6_Cong[1]);
                }
            }
            else
            {
                MessageBox.Show("File không tồn tại!");
            }
        }

        private void TableButton_Click_6_Cong(object sender, EventArgs e)
        {
            Button btn_6_Cong = sender as Button;
            tableId_6_Cong = btn_6_Cong.Tag.ToString();
            ShowBill_6_Cong(tableId_6_Cong);
        }

        // Xử lý sự kiện khi nhấn nút "Đặt bàn"
        private void ShowBill_6_Cong(string tableId_6_Cong)
        {
            string filePath_6_Cong = $@"C:\BaiTapLon_LTGT\Data\BillTable\{tableId_6_Cong}.txt";
            if (File.Exists(filePath_6_Cong))
            {
                lsv_Bill_6_Cong.Items.Clear();
                var lines_6_Cong = File.ReadAllLines(filePath_6_Cong);
                foreach (var line_6_Cong in lines_6_Cong)
                {
                    var columns_6_Cong = line_6_Cong.Split(',');
                    if (columns_6_Cong.Length == 3)
                    {
                        ListViewItem item_6_Cong = new ListViewItem(columns_6_Cong[0]);
                        item_6_Cong.SubItems.Add(columns_6_Cong[1]);
                        item_6_Cong.SubItems.Add(columns_6_Cong[2]);
                        item_6_Cong.SubItems.Add((int.Parse(columns_6_Cong[1])*int.Parse(columns_6_Cong[2])).ToString());
                        lsv_Bill_6_Cong.Items.Add(item_6_Cong);
                    }
                }
            }
            else
            {
                MessageBox.Show("File không tồn tại!");
            }
        }

        // Load danh sách món ăn từ file lên cbb_Food_6_Cong
        private void LoadFoods_6_Cong(string category_6_Cong)
        {
            string filePath_6_Cong = @"C:\BaiTapLon_LTGT\Data\thuc_an.txt";
            if (File.Exists(filePath_6_Cong))
            {
                cbb_Food_6_Cong.Items.Clear();
                var lines_6_Cong = File.ReadAllLines(filePath_6_Cong);
                bool isFirstLine_6_Cong = true;
                foreach (var line_6_Cong in lines_6_Cong)
                {
                    if (isFirstLine_6_Cong)
                    {
                        isFirstLine_6_Cong = false;
                        continue;
                    }
                    var columns_6_Cong = line_6_Cong.Split(',');
                    if (columns_6_Cong.Length == 4 && columns_6_Cong[3] == category_6_Cong)
                    {
                        cbb_Food_6_Cong.Items.Add(columns_6_Cong[1]);
                    }
                }
            }
            else
            {
                MessageBox.Show("File không tồn tại!");
            }
        }

        // Xử lý sự kiện khi chọn danh mục món ăn
        private void cbb_Category_6_Cong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory_6_Cong = cbb_Category_6_Cong.SelectedItem.ToString();
            LoadFoods_6_Cong(selectedCategory_6_Cong);
        }
        private void MnsInf_6_Cong_Click_1(object sender, EventArgs e)
        {
            fAccountProfile_6_Cong f_account_6_Cong = new fAccountProfile_6_Cong(flg_6_Cong);
            f_account_6_Cong.set_UserName_6_Cong(flg_6_Cong.get_UserName_6_Cong);
            f_account_6_Cong.ShowDialog();
        }

        private void MnsAdmin_6_Cong_Click(object sender, EventArgs e)
        {
            fAdmin_6_Cong f_ad_6_Cong = new fAdmin_6_Cong(this);
            f_ad_6_Cong.ShowDialog();
        }

        private void MnsLogout_6_Cong_Click(object sender, EventArgs e)
        {
            flg_6_Cong.get_txtb_UserName_6_Cong.Clear();
            flg_6_Cong.get_txtb_Password_6_Cong.Clear();
            this.Close();
        }

        // Xử lý sự kiện khi nhấn nút "Thêm món ăn"
        private void btn_AddFood_6_Cong_Click(object sender, EventArgs e)
        {
            String foodName_6_Cong = cbb_Food_6_Cong.SelectedItem.ToString();
            String foodCount_6_Cong = nm_CountFood_6_Cong.Value.ToString();
            string filePath_6_Cong = @"C:\BaiTapLon_LTGT\Data\thuc_an.txt";
            if (File.Exists(filePath_6_Cong))
            {
                var lines_6_Cong = File.ReadAllLines(filePath_6_Cong);
                foreach (var line_6_Cong in lines_6_Cong)
                {
                    var columns_6_Cong = line_6_Cong.Split(',');
                    if (columns_6_Cong.Length == 4 && columns_6_Cong[1] == foodName_6_Cong)
                    {
                        ListViewItem item_6_Cong = new ListViewItem(columns_6_Cong[1]);
                        item_6_Cong.SubItems.Add(foodCount_6_Cong);
                        item_6_Cong.SubItems.Add(columns_6_Cong[2]);
                        item_6_Cong.SubItems.Add((int.Parse(foodCount_6_Cong) * int.Parse(columns_6_Cong[2])).ToString());
                        totalPrice_6_Cong += int.Parse(foodCount_6_Cong) * int.Parse(columns_6_Cong[2]);
                        lsv_Bill_6_Cong.Items.Add(item_6_Cong);
                        updateFileBillTable_6_Cong(tableId_6_Cong, foodName_6_Cong, int.Parse(foodCount_6_Cong), int.Parse(columns_6_Cong[2]));
                        UpdateTableStatus_6_Cong(tableId_6_Cong, "Đang sử dụng");
                    }
                }
                txtTotal_6_Cong.Text = totalPrice_6_Cong.ToString();
            }
            else
            {
                MessageBox.Show("Bàn ăn không tồn tại!");
            }
        }
        
        private void updateFileBillTable_6_Cong(string tableId_6_Cong, string foodName_6_Cong, int foodCount_6_Cong, int price_6_Cong)
        {
            string filePath_6_Cong = $@"C:\BaiTapLon_LTGT\Data\BillTable\{tableId_6_Cong}.txt";
            string newLine_6_Cong = $"{foodName_6_Cong},{foodCount_6_Cong},{price_6_Cong}";
            File.AppendAllText(filePath_6_Cong, newLine_6_Cong + Environment.NewLine);
        }
        private void UpdateTableStatus_6_Cong(string tableId_6_Cong, string status_6_Cong)
        {
            string filePath_6_Cong = @"C:\BaiTapLon_LTGT\Data\ban_an.txt";
            if (File.Exists(filePath_6_Cong))
            {
                var lines_6_Cong = File.ReadAllLines(filePath_6_Cong);
                for (int i_6_Cong = 0; i_6_Cong < lines_6_Cong.Length; i_6_Cong++)
                {
                    var columns_6_Cong = lines_6_Cong[i_6_Cong].Split(',');
                    if (columns_6_Cong.Length == 3 && columns_6_Cong[0] == tableId_6_Cong)
                    {
                        lines_6_Cong[i_6_Cong] = $"{columns_6_Cong[0]},{columns_6_Cong[1]},{status_6_Cong}";
                        break;
                    }
                }
                File.WriteAllLines(filePath_6_Cong, lines_6_Cong);
                LoadTableData_6_Cong();
            }
            else
            {
                MessageBox.Show("File không tồn tại!");
            }
        }

        private void btn_Pay_6_Cong_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog_6_Cong = new SaveFileDialog())
            {
                saveFileDialog_6_Cong.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog_6_Cong.Title = "Save Bill";
                string today_6_Cong = DateTime.Now.ToString("dd/MM/yyyy");
                saveFileDialog_6_Cong.FileName = "doanh_thu_ngay_"+today_6_Cong+".txt";
                if (saveFileDialog_6_Cong.ShowDialog() == DialogResult.OK)
                {
                    string filePath_6_Cong = saveFileDialog_6_Cong.FileName;
                    using (StreamWriter writer_6_Cong = new StreamWriter(filePath_6_Cong, true))
                    {
                        foreach (ListViewItem item_6_Cong in lsv_Bill_6_Cong.Items)
                        {
                            string line_6_Cong = $"{tableId_6_Cong},{item_6_Cong.SubItems[0].Text},{item_6_Cong.SubItems[1].Text},{item_6_Cong.SubItems[3].Text}";
                            writer_6_Cong.WriteLine(line_6_Cong);
                        }
                    }
                }
            }
            string billFilePath_6_Cong = $@"C:\BaiTapLon_LTGT\Data\BillTable\{tableId_6_Cong}.txt";
            if (File.Exists(billFilePath_6_Cong))
            {
                File.WriteAllText(billFilePath_6_Cong, string.Empty);
            }
            lsv_Bill_6_Cong.Items.Clear();
            txtTotal_6_Cong.Text = "";
        }
    }
}
