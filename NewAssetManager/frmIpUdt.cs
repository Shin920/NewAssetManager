using NewAssetManager.DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewAssetManager
{
    public partial class frmIpUdt : Form
    {
        public frmIpUdt(Address value)
        {
            InitializeComponent();

            txtAddress.Text = value.ip_address;
            txtPurpose.Text = value.ip_purpose;
            txtDept.Text = value.ip_dept;
            txtUsername.Text = value.ip_user;
            txtLocation.Text = value.ip_location;
            txtRemark.Text = value.ip_remark;
            if (!string.IsNullOrEmpty(value.ip_date))
            {
                dtpRegDate.Value = DateTime.Parse(value.ip_date);
            }
            txtExternal.Text = value.ip_external;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Address value = new Address();
            value.ip_address = txtAddress.Text.Trim();
            value.ip_purpose = txtPurpose.Text.Trim();
            value.ip_dept = txtDept.Text.Trim();
            value.ip_user = txtUsername.Text.Trim();
            value.ip_location = txtLocation.Text.Trim();
            value.ip_remark = txtRemark.Text.Trim();
            value.ip_date = dtpRegDate.Value.ToString("yyyy.MM.dd");
            value.ip_external = txtExternal.Text.Trim();


            DialogResult result = MessageBox.Show(value.ip_address + "\n의 정보를 업데이트합니까?", "수정확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {

                AddressDAC aDAC = new AddressDAC();
                int rowsAffected = aDAC.Update(value);
                aDAC.Dispose();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("수정 완료", "알림");
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("수정 실패.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
