using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Login_6_Cong
{
    public partial class fLogin_6_Cong: Form
    {
        private string password_6_Cong;
        private string userName_6_Cong;
        public fLogin_6_Cong()
        {
            userName_6_Cong = "nvcong";
            password_6_Cong = "6_cong";
            InitializeComponent();
        }

        //Xử lý sự kiện khi nhấn nút đăng nhập
        private void btn_Login_6_Cong_Click(object sender, EventArgs e)
        {
            String userName_6_Cong = txtb_UserName_6_Cong.Text.Trim();
            String passWord_6_Cong = txtb_Password_6_Cong.Text.Trim();

            if (string.IsNullOrEmpty(userName_6_Cong))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtb_UserName_6_Cong.Focus();
                return;
            }

            if (string.IsNullOrEmpty(passWord_6_Cong))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtb_Password_6_Cong.Focus();
                return;
            }

            if(userName_6_Cong == this.userName_6_Cong && passWord_6_Cong == this.password_6_Cong)
            {
                Form f_TableManagement_6_Cong = new fTableManager_6_Cong(this);
                this.Hide();
                f_TableManagement_6_Cong.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtb_Password_6_Cong.Clear();
                    txtb_Password_6_Cong.Focus();   
            }
            
        }

        //xử lý sự kiện khi nhấn nút thoát
        private void btn_exit_6_Cong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //xử lý đóng form
        private void Login_6_Cong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thực sự muốn thoát chương trình?","Thông báo",MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        //xử lý sự kiện nhấn là label link
        private void llbl_LinkSupport_6_Cong_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MAIL DEN EMAIL SUPPORT
            // Địa chỉ email cố định
            string emailSupport_6_Cong = lbl_LinkSupport_6_Cong.Text.Trim();

            // Tạo URL để mở Gmail với email cố định
            string gmailUrl_6_Cong = $"https://mail.google.com/mail/?view=cm&fs=1&to={emailSupport_6_Cong}";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = gmailUrl_6_Cong,
                    UseShellExecute = true//TRUE dung terminal de mo lien ket FALSE can chi dinh phan mem
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở Gmail: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public TextBox get_txtb_UserName_6_Cong
        {
            get { return txtb_UserName_6_Cong; }
        }

        public string get_UserName_6_Cong
        {
            get { return userName_6_Cong; }
        }
        public string get_Password_6_Cong
        {
            get { return password_6_Cong; }
        }

        public TextBox get_txtb_Password_6_Cong
        {
            get { return txtb_Password_6_Cong; }
        }

        //Xử lý placeholder cho textbox
        private void txtb_UserName_6_Cong_TextChanged(object sender, EventArgs e)
        {
            lblEnterusername_6_Cong.Visible = string.IsNullOrEmpty(txtb_UserName_6_Cong.Text);
        }

        private void txtb_Password_6_Cong_TextChanged(object sender, EventArgs e)
        {
            lblEnterpassword_6_Cong.Visible = string.IsNullOrEmpty(txtb_Password_6_Cong.Text);
        }
    }
}
