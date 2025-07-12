using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_6_Cong
{
    public partial class fAccountProfile_6_Cong: Form
    {
        private fLogin_6_Cong flg_6_Cong;
        public fAccountProfile_6_Cong(fLogin_6_Cong flg_6_Cong)
        {
            InitializeComponent();
            this.flg_6_Cong = flg_6_Cong;
        }

        private void btn_Update_6_Cong_Click(object sender, EventArgs e)
        {
            if (txtb_Password_6_Cong.Text != flg_6_Cong.get_Password_6_Cong)
            {
                MessageBox.Show("Mật khẩu không đúng!");
                return;
            }
            else if (txtb_NewPassword_6_Cong.Text != txtb_ReEnterPassword_6_Cong.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp!");
                return;
            }    
                MessageBox.Show("Cập nhật thành công!");
        }
        
        private void btn_Exit_6_Cong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void set_UserName_6_Cong(string userName_6_Cong)
        {
            txtb_UserName_6_Cong.Text = userName_6_Cong;
        }
    }
}
