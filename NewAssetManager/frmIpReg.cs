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
    public partial class frmIpReg : Form
    {
        public frmIpReg()
        {
            InitializeComponent();

            //cmbExternal.a -> 속성으로 추가
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("IP는 필수 입력입니다.");
            }
            else
            {
                Address myValue = new Address();

                myValue.ip_address = txtAddress.Text.Trim();
                myValue.ip_purpose = txtPurpose.Text.Trim();
                myValue.ip_dept = txtDept.Text.Trim();
                myValue.ip_user = txtUsername.Text.Trim();
                myValue.ip_location = txtLocation.Text.Trim();
                myValue.ip_remark = txtRemark.Text.Trim();

                //할당일자 Null값 추가
                myValue.ip_date = chkNull.Checked ? string.Empty : dtpRegDate.Value.ToString("yyyy.MM.dd");

                myValue.ip_external = txtExternal.Text.Trim();

                AddressDAC aDAC = new AddressDAC();
                //Update 메서드의 리턴값 : int
                int rowsAffected = aDAC.Insert(myValue);
                aDAC.Dispose();

                //적용된 행이 존재한다 : 성공
                if (rowsAffected > 0)
                {
                    MessageBox.Show("등록 완료", "알림");


                    //입력값 초기화
                    txtAddress.Text = string.Empty;
                    txtPurpose.Text = string.Empty;
                    txtDept.Text = string.Empty;
                    txtUsername.Text = string.Empty;
                    txtLocation.Text = string.Empty;
                    txtRemark.Text = string.Empty;
                    dtpRegDate.Value = DateTime.Now;
                    txtExternal.Text = string.Empty;



                }
                else
                {
                    MessageBox.Show("등록 실패 - 신규 데이터 등록에 실패하였습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
