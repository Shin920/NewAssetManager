using NewAssetManager.DAC;
using Org.BouncyCastle.Crypto.Macs;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //폰트 수정 Test
            dgvAddress.Font = new Font("맑은 고딕", 11);
            
        }

        private void DataLoadAddress()
        {
            //초기화 필요            
            txtUsername.Text = string.Empty;
            txtAddress.Text = string.Empty;

            AddressDAC address = new AddressDAC();
            dgvAddress.DataSource = address.GetAll().DefaultView;
            address.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Address myValue = new Address();
            myValue.ip_user = txtUsername.Text;
            myValue.ip_address = txtAddress.Text;
            using (AddressDAC cmp = new AddressDAC())
            {
                dgvAddress.DataSource = cmp.GetAddressInfo(myValue);
            }
        }

        private void dgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //클릭한 열 채번
            int rldx = dgvAddress.CurrentRow.Index;

            //히든 라벨 제거
           
            txtUsername.Text = dgvAddress[3, rldx].Value.ToString();
            txtAddress.Text = dgvAddress[0, rldx].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("수정할 행을 선택해주세요");
            }
            else
            {
                Address myValue = new Address();
                myValue.ip_user = txtUsername.Text;
                myValue.ip_address = txtAddress.Text;
               

                DialogResult result = MessageBox.Show(myValue.ip_address + "\n의 정보를 수정합니까?", "수정확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    AddressDAC aDAC = new AddressDAC();
                    //Update 메서드의 리턴값 : int
                    int rowsAffected = aDAC.Update(myValue);
                    aDAC.Dispose();

                    //적용된 행이 존재한다 : 성공
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("수정 완료", "알림");
                        DataLoadAddress(); // 테이블 다시 불러오기
                    }
                    else
                    {
                        MessageBox.Show("수정 실패 - 데이터가 존재하지 않거나 변경사항이 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("삭제할 행을 선택해주세요");
            }
            else
            {
                Address myValue = new Address();                
                //myValue.ip_code = lblHidden.Text;

                //나머지 작업
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmIpReg frm = new frmIpReg();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("등록 완료.");
            }
        }
    }
}
