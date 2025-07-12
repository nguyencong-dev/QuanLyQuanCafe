using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Login_6_Cong
{
    public partial class fAdmin_6_Cong: Form
    {
        private fTableManager_6_Cong ftb_6_Cong;
        private int selectedRowIndex_6_Cong = -1;
        public fAdmin_6_Cong(fTableManager_6_Cong ftb_6_Cong)
        {
            InitializeComponent();
            this.ftb_6_Cong = ftb_6_Cong;
            LoadCategories_6_Cong();
        }

        private void btnEditFood_6_Cong_Paint(object sender, PaintEventArgs e)
        {

        }

        // Xử lý sự kiện LoadCategories khi form được tải lên
        private void LoadCategories_6_Cong()
        {
            string filePath_6_Cong = @"C:\BaiTapLon_LTGT\Data\danh_muc.txt";
            if (File.Exists(filePath_6_Cong))
            {
                cbFoodCategory_6_Cong.Items.Clear();
                var lines_6_Cong = File.ReadAllLines(filePath_6_Cong);
                bool isFirstLine_6_Cong = true;
                foreach (var line_6_Cong in lines_6_Cong)
                {
                    // Bỏ qua header
                    if (isFirstLine_6_Cong)
                    {
                        isFirstLine_6_Cong = false;
                        continue;
                    }
                    var columns = line_6_Cong.Split(',');
                    cbFoodCategory_6_Cong.Items.Add(columns[1]);
                }
            }
            else
            {
                MessageBox.Show("File không tồn tại!");
            }
        }

        private void btnShowFood_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn file txt
                string filePath_thucAn_6_Cong = @"C:\BaiTapLon_LTGT\Data\thuc_an.txt";

                // Kiểm tra file tồn tại
                if (!File.Exists(filePath_thucAn_6_Cong))
                {
                    MessageBox.Show("File không tồn tại: " + filePath_thucAn_6_Cong);
                    return;
                }

                // Đọc tất cả dòng từ file
                string[] lines_thucAn_6_Cong = File.ReadAllLines(filePath_thucAn_6_Cong, Encoding.UTF8);

                // Kiểm tra file rỗng
                if (lines_thucAn_6_Cong.Length == 0)
                {
                    MessageBox.Show("Không có thức ăn");
                    return;
                }

                // Lưu dữ liệu vào danh sách (List<string[]>)
                List<string[]> dataList_thucAn_6_Cong = new List<string[]>();

                // Lấy header (dòng đầu tiên)
                string[] headers_thucAn_6_Cong = lines_thucAn_6_Cong[0].Split(',');
                dataList_thucAn_6_Cong.Add(headers_thucAn_6_Cong);// Thêm header vào danh sách

                // Lấy các dòng dữ liệu còn lại
                for (int i_6_cong = 1; i_6_cong < lines_thucAn_6_Cong.Length; i_6_cong++)
                {
                    string[] rowData_6_Cong = lines_thucAn_6_Cong[i_6_cong].Split(',');
                    if (rowData_6_Cong.Length != headers_thucAn_6_Cong.Length)
                    {
                        MessageBox.Show($"Dòng {i_6_cong + 1} có dữ liệu không khớp!");
                        return;
                    }
                    dataList_thucAn_6_Cong.Add(rowData_6_Cong); // Thêm từng dòng vào danh sách
                }

                // Tạo DataTable từ danh sách
                DataTable dt_6_Cong = new DataTable();

                // Thêm cột từ header
                foreach (string header_6_Cong in dataList_thucAn_6_Cong[0])
                {
                    dt_6_Cong.Columns.Add(header_6_Cong);
                }

                // Thêm dữ liệu từ danh sách (bỏ qua dòng header)
                for (int i_6_Cong = 1; i_6_Cong < dataList_thucAn_6_Cong.Count; i_6_Cong++)
                {
                    dt_6_Cong.Rows.Add(dataList_thucAn_6_Cong[i_6_Cong]);
                }

                // Gán dữ liệu vào DataGridView
                dtgvFood_6_Cong.DataSource = dt_6_Cong;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDeleteFood_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn file txt
                string filePath_thucAn_6_Cong = @"C:\BaiTapLon_LTGT\Data\thuc_an.txt";

                // Kiểm tra xem có hàng nào được chọn không
                if (dtgvFood_6_Cong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để xóa!","Thông báo");
                    return;
                }

                // Lấy chỉ số hàng được chọn 
                selectedRowIndex_6_Cong = dtgvFood_6_Cong.SelectedRows[0].Index;

                // Lấy DataTable hiện tại từ DataGridView
                DataTable dt_6_Cong = (DataTable)dtgvFood_6_Cong.DataSource;

                // Xóa hàng trong DataTable
                dt_6_Cong.Rows.RemoveAt(selectedRowIndex_6_Cong);

                // Cập nhật lại DataGridView
                dtgvFood_6_Cong.DataSource = null; // Xóa dữ liệu trong datagridview cũ
                dtgvFood_6_Cong.DataSource = dt_6_Cong;   // Gán lại DataTable đã cập nhật

                // Ghi lại dữ liệu vào file thuc_an.txt
                List<string> newLines_6_Cong = new List<string>();
                // Thêm header
                newLines_6_Cong.Add(string.Join(",", dt_6_Cong.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                // Thêm các dòng dữ liệu
                foreach (DataRow row_6_Cong in dt_6_Cong.Rows)
                {
                    newLines_6_Cong.Add(string.Join(",", row_6_Cong.ItemArray));
                }

                // Ghi lại vào file
                File.WriteAllLines(filePath_thucAn_6_Cong, newLines_6_Cong, Encoding.UTF8);

                MessageBox.Show("Đã xóa dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void btnEditFood_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn file txt
                string filePath_thucAn_6_Cong = @"C:\BaiTapLon_LTGT\Data\thuc_an.txt";

                // Kiểm tra xem có hàng nào được chọn không
                if (selectedRowIndex_6_Cong == -1 || dtgvFood_6_Cong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để sửa!");
                    return;
                }

                // Lấy DataTable hiện tại từ DataGridView
                DataTable dt_6Cong = (DataTable)dtgvFood_6_Cong.DataSource;

                // Kiểm tra dữ liệu nhập vào từ các control
                if (string.IsNullOrEmpty(txtFoodName_6_Cong.Text) || cbFoodCategory_6_Cong.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên Món và Danh Mục!");
                    return;
                }

                // Cập nhật chỉ các cột "Tên Món", "Giá", "Danh Mục" từ các control
                dt_6Cong.Rows[selectedRowIndex_6_Cong]["ID"] = txtFoodId_6_Cong.Text;
                dt_6Cong.Rows[selectedRowIndex_6_Cong]["Tên Món"] = txtFoodName_6_Cong.Text;
                dt_6Cong.Rows[selectedRowIndex_6_Cong]["Giá"] = nmrPrice_6_Cong.Value.ToString();
                dt_6Cong.Rows[selectedRowIndex_6_Cong]["Danh Mục"] = cbFoodCategory_6_Cong.SelectedItem.ToString();

                // Ghi lại dữ liệu vào file
                List<string> newLines_6_Cong = new List<string>();
                // Thêm header
                newLines_6_Cong.Add(string.Join(",", dt_6Cong.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                foreach (DataRow row in dt_6Cong.Rows)
                {
                    newLines_6_Cong.Add(string.Join(",", row.ItemArray));
                }
                // Ghi lại vào file
                File.WriteAllLines(filePath_thucAn_6_Cong, newLines_6_Cong, Encoding.UTF8);

                MessageBox.Show("Đã cập nhật dữ liệu thành công!");

                // Reset các control
                txtFoodId_6_Cong.Clear();
                txtFoodName_6_Cong.Clear();
                nmrPrice_6_Cong.Value = 0;
                cbFoodCategory_6_Cong.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        // Xử lý sự kiện khi chọn hàng trong DataGridView   
        private void dtgvFood_6_Cong_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvFood_6_Cong.SelectedRows.Count > 0)
            {
                selectedRowIndex_6_Cong = dtgvFood_6_Cong.SelectedRows[0].Index;
                DataTable dt_6_Cong = (DataTable)dtgvFood_6_Cong.DataSource;

                if (dt_6_Cong != null && selectedRowIndex_6_Cong < dt_6_Cong.Rows.Count)
                {
                    // Hiển thị thông tin lên các control
                    txtFoodId_6_Cong.Text = dt_6_Cong.Rows[selectedRowIndex_6_Cong]["ID"].ToString();
                    txtFoodName_6_Cong.Text = dt_6_Cong.Rows[selectedRowIndex_6_Cong]["Tên Món"].ToString();
                    nmrPrice_6_Cong.Value = decimal.Parse(dt_6_Cong.Rows[selectedRowIndex_6_Cong]["Giá"].ToString());

                    // Gán giá trị cho ComboBox với kiểm tra
                    string danhMuc = dt_6_Cong.Rows[selectedRowIndex_6_Cong]["Danh Mục"].ToString();
                    cbFoodCategory_6_Cong.SelectedItem = danhMuc;
                }
            }
        }

        private void btnAddFood_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath_thucAn_6_Cong = @"C:\BaiTapLon_LTGT\Data\thuc_an.txt";

                // Kiểm tra dữ liệu nhập vào từ các control
                if (string.IsNullOrEmpty(txtFoodName_6_Cong.Text) || cbFoodCategory_6_Cong.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên Món và Danh Mục!");
                    return;
                }

                DataTable dt_6_Cong = (DataTable)dtgvFood_6_Cong.DataSource;

                // Kiểm tra ID và Tên Món đã tồn tại hay chưa
                foreach (DataRow row_6_Cong in dt_6_Cong.Rows)
                {
                    if (row_6_Cong["ID"].ToString() == txtFoodId_6_Cong.Text || row_6_Cong["Tên Món"].ToString() == txtFoodName_6_Cong.Text)
                    {
                        MessageBox.Show("ID hoặc Tên Món đã tồn tại!");
                        return;
                    }
                }

                // Tạo một hàng mới
                DataRow newRow_6_Cong = dt_6_Cong.NewRow();
                newRow_6_Cong["ID"] = txtFoodId_6_Cong.Text;
                newRow_6_Cong["Tên Món"] = txtFoodName_6_Cong.Text;
                newRow_6_Cong["Giá"] = nmrPrice_6_Cong.Value.ToString();
                newRow_6_Cong["Danh Mục"] = cbFoodCategory_6_Cong.SelectedItem.ToString();

                // Thêm hàng mới vào DataTable
                dt_6_Cong.Rows.Add(newRow_6_Cong);

                // Ghi lại dữ liệu vào file
                List<string> newLines_6_Cong = new List<string>();
                foreach (DataRow row in dt_6_Cong.Rows)
                {
                    newLines_6_Cong.Add(string.Join(",", row.ItemArray));
                }
                newLines_6_Cong.Add(string.Join(",", dt_6_Cong.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                File.WriteAllLines(filePath_thucAn_6_Cong, newLines_6_Cong, Encoding.UTF8);

                MessageBox.Show("Đã thêm dữ liệu thành công!");

                // Reset các control
                txtFoodId_6_Cong.Clear();
                txtFoodName_6_Cong.Clear();
                nmrPrice_6_Cong.Value = 0;
                cbFoodCategory_6_Cong.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Xử lý sự kiện khi nhấn nút hiển thị bàn
        private void btnShowTable_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath_table_6_Cong = @"C:\BaiTapLon_LTGT\Data\ban_an.txt";

                // Kiểm tra file tồn tại
                if (!File.Exists(filePath_table_6_Cong))
                {
                    MessageBox.Show("File không tồn tại: " + filePath_table_6_Cong);
                    return;
                }

                // Đọc tất cả dòng từ file
                string[] lines_table_6_Cong = File.ReadAllLines(filePath_table_6_Cong, Encoding.UTF8);

                if (lines_table_6_Cong.Length == 0)
                {
                    MessageBox.Show("File rỗng!");
                    return;
                }

                // Lưu dữ liệu vào danh sách
                List<string[]> dataList_table_6_Cong = new List<string[]>();
                // Lấy header
                string[] headers_table_6_Cong = lines_table_6_Cong[0].Split(',');
                dataList_table_6_Cong.Add(headers_table_6_Cong);

                // Lấy các dòng dữ liệu còn lại
                for (int i_6_Cong = 1; i_6_Cong < lines_table_6_Cong.Length; i_6_Cong++)
                {
                    string[] rowData_6_Cong = lines_table_6_Cong[i_6_Cong].Split(',');
                    if (rowData_6_Cong.Length != headers_table_6_Cong.Length)
                    {
                        MessageBox.Show($"Dòng {i_6_Cong + 1} có dữ liệu không khớp!");
                        return;
                    }
                    dataList_table_6_Cong.Add(rowData_6_Cong);
                }

                DataTable dt_6_Cong = new DataTable();
                // Thêm cột từ header
                foreach (string header_6_Cong in dataList_table_6_Cong[0])
                {
                    dt_6_Cong.Columns.Add(header_6_Cong);
                }

                // Thêm dữ liệu từ danh sách (bỏ qua dòng header)
                for (int i_6_Cong = 1; i_6_Cong < dataList_table_6_Cong.Count; i_6_Cong++)
                {
                    dt_6_Cong.Rows.Add(dataList_table_6_Cong[i_6_Cong]);
                }

                // Gán dữ liệu vào dtgvTable_6_Cong
                dtgvTable_6_Cong.DataSource = dt_6_Cong;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void CreateTableFile_6_Cong(string tableCode_6_Cong)
        {
            string directoryPath_6_Cong = @"C:\BaiTapLon_LTGT\Data\BillTable";
            string filePath_6_Cong = Path.Combine(directoryPath_6_Cong, $"{tableCode_6_Cong}.txt");

            try
            {
                // Đảm bảo thư mục tồn tại
                Directory.CreateDirectory(directoryPath_6_Cong);

                // Tạo file mà không ghi nội dung vào file
                using (FileStream fs_6_Cong = File.Create(filePath_6_Cong)) ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteTableFile_6_Cong(string tableCode_6_Cong)
        {
            string directoryPath_6_Cong = @"C:\BaiTapLon_LTGT\Data\BillTable";
            string filePath_6_Cong = Path.Combine(directoryPath_6_Cong, $"{tableCode_6_Cong}.txt");

            try
            {
                File.Delete(filePath_6_Cong);   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi nhấn nút thêm bàn
        private void btnAddTable_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath_table_6_Cong = @"C:\BaiTapLon_LTGT\Data\ban_an.txt";

                // Kiểm tra dữ liệu nhập vào từ các control
                if (string.IsNullOrEmpty(txtTableName_6_Cong.Text) || cbTableStatus_6_Cong.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên Bàn và Trạng Thái!");
                    return;
                }

                DataTable dt_6_Cong = (DataTable)dtgvTable_6_Cong.DataSource;

                // Kiểm tra ID và Tên Bàn đã tồn tại hay chưa
                foreach (DataRow row_6_Cong in dt_6_Cong.Rows)
                {
                    if (row_6_Cong["ID"].ToString() == txtTableId_6_Cong.Text || row_6_Cong["Tên Bàn"].ToString() == txtTableName_6_Cong.Text)
                    {
                        MessageBox.Show("ID hoặc Tên Bàn đã tồn tại!");
                        return;
                    }
                }

                // Tạo một hàng mới
                DataRow newRow_6_Cong = dt_6_Cong.NewRow();
                newRow_6_Cong["ID"] = txtTableId_6_Cong.Text;
                newRow_6_Cong["Tên Bàn"] = txtTableName_6_Cong.Text;
                newRow_6_Cong["Trạng Thái"] = cbTableStatus_6_Cong.SelectedItem.ToString();

                // Thêm hàng mới vào DataTable
                dt_6_Cong.Rows.Add(newRow_6_Cong);

                // Cập nhật DataGridView
                dtgvTable_6_Cong.DataSource = null;
                dtgvTable_6_Cong.DataSource = dt_6_Cong;

                // Ghi lại dữ liệu vào file
                List<string> newLines_6_Cong = new List<string>();
                newLines_6_Cong.Add(string.Join(",", dt_6_Cong.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                foreach (DataRow row_6_Cong in dt_6_Cong.Rows)
                {
                    newLines_6_Cong.Add(string.Join(",", row_6_Cong.ItemArray));
                }
                File.WriteAllLines(filePath_table_6_Cong, newLines_6_Cong, Encoding.UTF8);

                MessageBox.Show("Đã thêm dữ liệu thành công!");

                //tao file BillTable
                CreateTableFile_6_Cong(txtTableId_6_Cong.Text);
                // Reset các control
                txtTableId_6_Cong.Clear();
                txtTableName_6_Cong.Clear();
                cbTableStatus_6_Cong.SelectedItem = null;
                ftb_6_Cong.LoadTableData_6_Cong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Xử lý sự kiện khi nhấn nút xóa bàn
        private void btnDeleteTable_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath_table_6_Cong = @"C:\BaiTapLon_LTGT\Data\ban_an.txt";

                // Kiểm tra xem có hàng nào được chọn không
                if (dtgvTable_6_Cong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để xóa!", "Thông báo");
                    return;
                }
                // Lấy chỉ số hàng được chọn
                selectedRowIndex_6_Cong = dtgvTable_6_Cong.SelectedRows[0].Index;

                DataTable dt_6_Cong = (DataTable)dtgvTable_6_Cong.DataSource;
                // Lấy mã bàn từ hàng được chọn trước khi xóa
                string tableCode_6_Cong = dt_6_Cong.Rows[selectedRowIndex_6_Cong]["ID"].ToString();

                // Xóa hàng trong DataTable
                dt_6_Cong.Rows.RemoveAt(selectedRowIndex_6_Cong);

                // Cập nhật lại DataGridView
                dtgvTable_6_Cong.DataSource = null;
                dtgvTable_6_Cong.DataSource = dt_6_Cong;

                // Ghi lại dữ liệu vào file
                List<string> newLines_6_Cong = new List<string>();
                // Thêm header
                newLines_6_Cong.Add(string.Join(",", dt_6_Cong.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                // Thêm các dòng dữ liệu
                foreach (DataRow row_6_Cong in dt_6_Cong.Rows)
                {
                    newLines_6_Cong.Add(string.Join(",", row_6_Cong.ItemArray));
                }

                // Ghi lại vào file
                File.WriteAllLines(filePath_table_6_Cong, newLines_6_Cong, Encoding.UTF8);

                // Xóa file của bàn
                DeleteTableFile_6_Cong(tableCode_6_Cong);
                MessageBox.Show("Đã xóa dữ liệu thành công!");
                ftb_6_Cong.LoadTableData_6_Cong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Xử lý sự kiện khi nhấn nút sửa bàn
        private void btnEditTable_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath_table_6_Cong = @"C:\BaiTapLon_LTGT\Data\ban_an.txt";

                if (dtgvTable_6_Cong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để sửa!");
                    return;
                }

                selectedRowIndex_6_Cong = dtgvTable_6_Cong.SelectedRows[0].Index;
                DataTable dt_6_Cong = (DataTable)dtgvTable_6_Cong.DataSource;

                // Kiểm tra dữ liệu nhập vào từ các control
                if (string.IsNullOrEmpty(txtTableName_6_Cong.Text) || cbTableStatus_6_Cong.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên Bàn và Trạng Thái!");
                    return;
                }

                string lastTableCode_6_Cong = dt_6_Cong.Rows[selectedRowIndex_6_Cong]["ID"].ToString();

                // Cập nhật chỉ các cột "Tên Bàn", "Trạng Thái" từ các control
                dt_6_Cong.Rows[selectedRowIndex_6_Cong]["ID"] = txtTableId_6_Cong.Text;
                dt_6_Cong.Rows[selectedRowIndex_6_Cong]["Tên Bàn"] = txtTableName_6_Cong.Text;
                dt_6_Cong.Rows[selectedRowIndex_6_Cong]["Trạng Thái"] = cbTableStatus_6_Cong.SelectedItem.ToString();

                // Cập nhật DataGridView
                dtgvTable_6_Cong.DataSource = null;
                dtgvTable_6_Cong.DataSource = dt_6_Cong;

                string tableCode_6_Cong = dt_6_Cong.Rows[selectedRowIndex_6_Cong]["ID"].ToString();

                // Ghi lại dữ liệu vào file
                List<string> newLines_6_Cong = new List<string>();
                newLines_6_Cong.Add(string.Join(",", dt_6_Cong.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                foreach (DataRow row_6_Cong in dt_6_Cong.Rows)
                {
                  newLines_6_Cong.Add(string.Join(",", row_6_Cong.ItemArray));
                }
                File.WriteAllLines(filePath_table_6_Cong, newLines_6_Cong, Encoding.UTF8);

                MessageBox.Show("Đã cập nhật dữ liệu thành công!");
                DeleteTableFile_6_Cong(lastTableCode_6_Cong);
                CreateTableFile_6_Cong(tableCode_6_Cong);
                // Reset các control
                txtTableId_6_Cong.Clear();
                txtTableName_6_Cong.Clear();
                cbTableStatus_6_Cong.SelectedItem = null;
                ftb_6_Cong.LoadTableData_6_Cong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dtgvTable_6_Cong_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvTable_6_Cong.SelectedRows.Count > 0)
            {
                selectedRowIndex_6_Cong = dtgvTable_6_Cong.SelectedRows[0].Index;
                DataTable dt_6_Cong = (DataTable)dtgvTable_6_Cong.DataSource;

                if (dt_6_Cong != null && selectedRowIndex_6_Cong < dt_6_Cong.Rows.Count)
                {
                    // Hiển thị thông tin lên các control
                    txtTableId_6_Cong.Text = dt_6_Cong.Rows[selectedRowIndex_6_Cong]["ID"].ToString();
                    txtTableName_6_Cong.Text = dt_6_Cong.Rows[selectedRowIndex_6_Cong]["Tên Bàn"].ToString();
                    cbTableStatus_6_Cong.SelectedItem = dt_6_Cong.Rows[selectedRowIndex_6_Cong]["Trạng Thái"].ToString();
                }
            }
        }


        private void btnSearchFood_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText_6_Cong = txt_SearchFood_6_Cong.Text.Trim();
                if (string.IsNullOrEmpty(searchText_6_Cong))
                {
                    // Nếu TextBox rỗng, xóa các control và bỏ chọn trong DataGridView
                    txtFoodId_6_Cong.Text = "";
                    txtFoodName_6_Cong.Text = "";
                    nmrPrice_6_Cong.Value = 0;
                    cbFoodCategory_6_Cong.SelectedItem = null;
                    selectedRowIndex_6_Cong = -1;
                    dtgvFood_6_Cong.ClearSelection();
                    return;
                }

                DataTable dt_6_Cong = (DataTable)dtgvFood_6_Cong.DataSource;
                if (dt_6_Cong == null || dt_6_Cong.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong DataGridView!");
                    return;
                }

                bool found_6_Cong = false;

                // Tìm theo ID trước
                for (int i_6_Cong = 0; i_6_Cong < dt_6_Cong.Rows.Count; i_6_Cong++)
                {
                    if (dt_6_Cong.Rows[i_6_Cong]["ID"].ToString() == searchText_6_Cong)
                    {
                        selectedRowIndex_6_Cong = i_6_Cong;
                        found_6_Cong = true;
                        // Cập nhật các control từ hàng được tìm thấy
                        txtFoodId_6_Cong.Text = dt_6_Cong.Rows[i_6_Cong]["ID"].ToString();
                        txtFoodName_6_Cong.Text = dt_6_Cong.Rows[i_6_Cong]["Tên Món"].ToString();
                        nmrPrice_6_Cong.Value = decimal.Parse(dt_6_Cong.Rows[i_6_Cong]["Giá"].ToString());
                        string danhMuc = dt_6_Cong.Rows[i_6_Cong]["Danh Mục"].ToString();
                        cbFoodCategory_6_Cong.SelectedItem = danhMuc;
                        // Chọn hàng trong DataGridView
                        dtgvFood_6_Cong.ClearSelection();
                        dtgvFood_6_Cong.Rows[i_6_Cong].Selected = true;
                        dtgvFood_6_Cong.FirstDisplayedScrollingRowIndex = i_6_Cong;
                        break;
                    }
                }

                // Nếu không tìm thấy theo ID, tìm theo Tên Món
                if (!found_6_Cong)
                {
                    for (int i_6_Cong = 0; i_6_Cong < dt_6_Cong.Rows.Count; i_6_Cong++)
                    {
                        if (dt_6_Cong.Rows[i_6_Cong]["Tên Món"].ToString().IndexOf(searchText_6_Cong, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            selectedRowIndex_6_Cong = i_6_Cong;
                            found_6_Cong = true;
                            // Cập nhật các control từ hàng được tìm thấy
                            txtFoodId_6_Cong.Text = dt_6_Cong.Rows[i_6_Cong]["ID"].ToString();
                            txtFoodName_6_Cong.Text = dt_6_Cong.Rows[i_6_Cong]["Tên Món"].ToString();
                            nmrPrice_6_Cong.Value = decimal.Parse(dt_6_Cong.Rows[i_6_Cong]["Giá"].ToString());
                            string danhMuc = dt_6_Cong.Rows[i_6_Cong]["Danh Mục"].ToString();
                            cbFoodCategory_6_Cong.SelectedItem = danhMuc;
                            // Chọn hàng trong DataGridView
                            dtgvFood_6_Cong.ClearSelection();
                            dtgvFood_6_Cong.Rows[i_6_Cong].Selected = true;
                            dtgvFood_6_Cong.FirstDisplayedScrollingRowIndex = i_6_Cong;
                            break;
                        }
                    }
                }

                if (!found_6_Cong)
                {
                    // Nếu không tìm thấy, xóa các control và bỏ chọn
                    txtFoodId_6_Cong.Text = "";
                    txtFoodName_6_Cong.Text = "";
                    nmrPrice_6_Cong.Value = 0;
                    cbFoodCategory_6_Cong.SelectedItem = null;
                    selectedRowIndex_6_Cong = -1;
                    dtgvFood_6_Cong.ClearSelection();
                    MessageBox.Show("Không tìm thấy món ăn nào với ID hoặc Tên Món đã nhập!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnChoosseFile_6_Cong_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog_6_Cong = new OpenFileDialog())
            {
                openFileDialog_6_Cong.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog_6_Cong.ShowDialog() == DialogResult.OK)
                {
                    string filePath_6_Cong = openFileDialog_6_Cong.FileName;
                    LoadFileToDataGridView_6_Cong(filePath_6_Cong);
                }
            }
        }
        private void LoadFileToDataGridView_6_Cong(string filePath_6_Cong)
        {
            try
            {
                if (!File.Exists(filePath_6_Cong))
                {
                    MessageBox.Show("File không tồn tại: " + filePath_6_Cong);
                    return;
                }

                string[] lines_6_Cong = File.ReadAllLines(filePath_6_Cong, Encoding.UTF8);

                if (lines_6_Cong.Length == 0)
                {
                    MessageBox.Show("File rỗng!");
                    return;
                }

                List<string[]> dataList_6_Cong = new List<string[]>();
                string[] headers_6_Cong = { "Mã Bàn", "Tên Món", "Số Lượng", "Thành Tiền" };
                dataList_6_Cong.Add(headers_6_Cong);

                for (int i_6_Cong = 0; i_6_Cong < lines_6_Cong.Length; i_6_Cong++)
                {
                    string[] rowData_6_Cong = lines_6_Cong[i_6_Cong].Split(',');
                    if (rowData_6_Cong.Length != headers_6_Cong.Length)
                    {
                        MessageBox.Show($"Dòng {i_6_Cong + 1} có dữ liệu không khớp!");
                        return;
                    }
                    dataList_6_Cong.Add(rowData_6_Cong);
                }

                DataTable dt_6_Cong = new DataTable();
                foreach (string header_6_Cong in dataList_6_Cong[0])
                {
                    dt_6_Cong.Columns.Add(header_6_Cong);
                }

                for (int i_6_Cong = 1; i_6_Cong < dataList_6_Cong.Count; i_6_Cong++)
                {
                    dt_6_Cong.Rows.Add(dataList_6_Cong[i_6_Cong]);
                }

                dtgvBill_6_Cong.DataSource = dt_6_Cong;     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        //Xử lý nhấn nút thêm danh mục
        private void btnAddCategory_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn file txt
                string filePath_6_Cong = @"C:\BaiTapLon_LTGT\Data\danh_muc.txt";

                // Kiểm tra dữ liệu nhập vào từ các control
                if (string.IsNullOrEmpty(txtCategoryId_6_Cong.Text) || string.IsNullOrEmpty(txtCategoryName_6_Cong.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ID và Tên Danh Mục!");
                    return;
                }

                DataTable dt_6_Cong = (DataTable)dtgvCategory_6_Cong.DataSource;

                // Kiểm tra ID và Tên Danh Mục đã tồn tại hay chưa
                foreach (DataRow row_6_Cong in dt_6_Cong.Rows)
                {
                    if (row_6_Cong["ID"].ToString() == txtCategoryId_6_Cong.Text || row_6_Cong["Tên Danh Mục"].ToString() == txtCategoryName_6_Cong.Text)
                    {
                        MessageBox.Show("ID hoặc Tên Danh Mục đã tồn tại!");
                        return;
                    }
                }

                // Tạo một hàng mới
                DataRow newRow_6_Cong = dt_6_Cong.NewRow();
                newRow_6_Cong["ID"] = txtCategoryId_6_Cong.Text;
                newRow_6_Cong["Tên Danh Mục"] = txtCategoryName_6_Cong.Text;

                // Thêm hàng mới vào DataTable
                dt_6_Cong.Rows.Add(newRow_6_Cong);

                // Cập nhật DataGridView
                dtgvCategory_6_Cong.DataSource = null;
                dtgvCategory_6_Cong.DataSource = dt_6_Cong;

                // Ghi lại dữ liệu vào file
                List<string> newLines_6_Cong = new List<string>();
                newLines_6_Cong.Add(string.Join(",", dt_6_Cong.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                foreach (DataRow row_6_Cong in dt_6_Cong.Rows)
                {
                    newLines_6_Cong.Add(string.Join(",", row_6_Cong.ItemArray));
                }
                File.WriteAllLines(filePath_6_Cong, newLines_6_Cong, Encoding.UTF8);

                MessageBox.Show("Đã thêm dữ liệu thành công!");

                // Reset các control
                txtCategoryId_6_Cong.Clear();
                txtCategoryName_6_Cong.Clear();

                // Cập nhật lại ComboBox
                LoadCategories_6_Cong();
                ftb_6_Cong.LoadCategories_6_Cong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Xử lý nhấn nút xóa danh mục
        private void btnDeleteCategory_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath_6_Cong = @"C:\BaiTapLon_LTGT\Data\danh_muc.txt";

                // Kiểm tra xem có hàng nào được chọn không
                if (dtgvCategory_6_Cong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để xóa!", "Thông báo");
                    return;
                }

                // Lấy chỉ số hàng được chọn
                selectedRowIndex_6_Cong = dtgvCategory_6_Cong.SelectedRows[0].Index;

                // Lấy DataTable hiện tại từ DataGridView
                DataTable dt_6_Cong = (DataTable)dtgvCategory_6_Cong.DataSource;

                // Xóa hàng trong DataTable 
                dt_6_Cong.Rows.RemoveAt(selectedRowIndex_6_Cong);

                // Cập nhật lại DataGridView
                dtgvCategory_6_Cong.DataSource = null; 
                dtgvCategory_6_Cong.DataSource = dt_6_Cong;

                // Ghi lại dữ liệu vào file
                List<string> newLines_6_Cong = new List<string>();
                // Thêm header
                newLines_6_Cong.Add(string.Join(",", dt_6_Cong.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                // Thêm các dòng dữ liệu
                foreach (DataRow row_6_Cong in dt_6_Cong.Rows)
                {
                    newLines_6_Cong.Add(string.Join(",", row_6_Cong.ItemArray));
                }

                // Ghi lại vào file
                File.WriteAllLines(filePath_6_Cong, newLines_6_Cong, Encoding.UTF8);

                MessageBox.Show("Đã xóa dữ liệu thành công!");

                // Cập nhật lại ComboBox
                LoadCategories_6_Cong();
                ftb_6_Cong.LoadCategories_6_Cong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Xử lý sự kiện khi chọn hàng trong dtgvCategory_6_Cong
        private void dtgvCategory_6_Cong_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvCategory_6_Cong.SelectedRows.Count > 0)
            {
                selectedRowIndex_6_Cong = dtgvCategory_6_Cong.SelectedRows[0].Index;
                if (selectedRowIndex_6_Cong < dtgvCategory_6_Cong.RowCount && dtgvCategory_6_Cong.DataSource != null)
                {
                    txtCategoryId_6_Cong.Text = dtgvCategory_6_Cong.SelectedRows[0].Cells["ID"].Value.ToString();
                    txtCategoryName_6_Cong.Text = dtgvCategory_6_Cong.SelectedRows[0].Cells["Tên Danh Mục"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong danh mục!");
                    return;
                }
            }
        }

        // Xử lý nhấn nút sửa danh mục
        private void btnEditCategory_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath_6_Cong = @"C:\BaiTapLon_LTGT\Data\danh_muc.txt";

                if (selectedRowIndex_6_Cong == -1 || dtgvCategory_6_Cong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để sửa!");
                    return;
                }

                DataTable dt_6_Cong = (DataTable)dtgvCategory_6_Cong.DataSource;

                // Kiểm tra dữ liệu nhập vào từ các control
                if (string.IsNullOrEmpty(txtCategoryId_6_Cong.Text) || string.IsNullOrEmpty(txtCategoryName_6_Cong.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ ID và Tên Danh Mục!");
                    return;
                }

                // Cập nhật chỉ các cột "ID" và "Tên Danh Mục" từ các control
                dt_6_Cong.Rows[selectedRowIndex_6_Cong]["ID"] = txtCategoryId_6_Cong.Text;
                dt_6_Cong.Rows[selectedRowIndex_6_Cong]["Tên Danh Mục"] = txtCategoryName_6_Cong.Text;

                // Cập nhật DataGridView
                dtgvCategory_6_Cong.DataSource = null;
                dtgvCategory_6_Cong.DataSource = dt_6_Cong;

                // Ghi lại dữ liệu vào file
                List<string> newLines_6_Cong = new List<string>();
                newLines_6_Cong.Add(string.Join(",", dt_6_Cong.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
                foreach (DataRow row_6_Cong in dt_6_Cong.Rows)
                {
                    newLines_6_Cong.Add(string.Join(",", row_6_Cong.ItemArray));
                }
                File.WriteAllLines(filePath_6_Cong, newLines_6_Cong, Encoding.UTF8);

                MessageBox.Show("Đã cập nhật dữ liệu thành công!");

                // Reset các control
                txtCategoryId_6_Cong.Clear();
                txtCategoryName_6_Cong.Clear();

                // Cập nhật lại ComboBox
                LoadCategories_6_Cong();
                ftb_6_Cong.LoadCategories_6_Cong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Xử lý nhấn nút hiển thị danh mục
        private void btnShowCategory_6_Cong_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath_6_Cong = @"C:\BaiTapLon_LTGT\Data\danh_muc.txt";

                if (!File.Exists(filePath_6_Cong))
                {
                    MessageBox.Show("File không tồn tại: " + filePath_6_Cong);
                    return;
                }

                string[] lines_6_Cong = File.ReadAllLines(filePath_6_Cong, Encoding.UTF8);

                if (lines_6_Cong.Length == 0)
                {
                    MessageBox.Show("File rỗng!");
                    return;
                }

                List<string[]> dataList_6_Cong = new List<string[]>();
                string[] headers_6_Cong = lines_6_Cong[0].Split(',');
                dataList_6_Cong.Add(headers_6_Cong);
                for (int i_6_Cong = 1; i_6_Cong < lines_6_Cong.Length; i_6_Cong++)
                {
                    string[] rowData_6_Cong = lines_6_Cong[i_6_Cong].Split(',');
                    if (rowData_6_Cong.Length != headers_6_Cong.Length)
                    {
                        MessageBox.Show($"Dòng {i_6_Cong + 1} có dữ liệu không khớp!");
                        return;
                    }
                    dataList_6_Cong.Add(rowData_6_Cong);
                }

                DataTable dt_6_Cong = new DataTable();
                foreach (string header_6_Cong in dataList_6_Cong[0])
                {
                    dt_6_Cong.Columns.Add(header_6_Cong);
                }

                for (int i_6_Cong = 1; i_6_Cong < dataList_6_Cong.Count; i_6_Cong++)
                {
                    dt_6_Cong.Rows.Add(dataList_6_Cong[i_6_Cong]);
                }

                dtgvCategory_6_Cong.DataSource = dt_6_Cong;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txt_SearchFood_6_Cong_Click(object sender, EventArgs e)
        {
            txt_SearchFood_6_Cong.Clear();
        }
    }
}
