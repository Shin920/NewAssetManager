using NewAssetManager.DAC;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;

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

        #region IP관리Tab화면
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
            using (AddressDAC aDAC = new AddressDAC())
            {
                dgvAddress.DataSource = aDAC.GetAddressInfo(myValue);
            }
        }

        private void dgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //클릭한 열 채번
            int rldx = dgvAddress.CurrentRow.Index;

            //히든 라벨 제거
            //txtAddress.Enabled = false;

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
                int rldx = dgvAddress.CurrentRow.Index;

                Address myValue = new Address();
                myValue.ip_address = txtAddress.Text.Trim();    //그냥 선택값으로
                myValue.ip_purpose = dgvAddress[1, rldx].Value.ToString();
                myValue.ip_dept = dgvAddress[2, rldx].Value.ToString();
                myValue.ip_user = dgvAddress[3, rldx].Value.ToString();
                myValue.ip_location = dgvAddress[4, rldx].Value.ToString();
                myValue.ip_remark = dgvAddress[5, rldx].Value.ToString();
                myValue.ip_date = dgvAddress[6, rldx].Value.ToString();
                myValue.ip_external = dgvAddress[7, rldx].Value.ToString();

                // 정보만 담고, 신규 폼 열어서 진행

                frmIpUdt frm = new frmIpUdt(myValue);

                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    //MessageBox.Show("등록 완료.");
                    DataLoadAddress();
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
                myValue.ip_address = txtAddress.Text.Trim();

                DialogResult result = MessageBox.Show(myValue.ip_address + "\n의 정보를 삭제합니까?", "삭제확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                if (result == DialogResult.Yes)
                {
                    AddressDAC aDAC = new AddressDAC();
                    int rowsAffected = aDAC.Delete(myValue);
                    aDAC.Dispose();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("삭제 완료", "알림");
                        DataLoadAddress(); // 테이블 다시 불러오기
                    }
                    else
                    {
                        MessageBox.Show("삭제 실패.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmIpReg frm = new frmIpReg();

            if (frm.ShowDialog() == DialogResult.Cancel)
            {
                //MessageBox.Show("등록 완료.");
                DataLoadAddress();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelWithEPPlus();
        }
        #endregion
        private void ExportToExcelWithEPPlus()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel Files (*.xlsx)|*.xlsx";
            dlg.Title = "엑셀 파일로 내보내기";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // DataGridView를 DataTable로 변환
                DataTable dt = GetDataGridViewAsDataTable(dgvAddress);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("내보낼 데이터가 없습니다.");
                    return;
                }

                // EPPlus 사용                
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    // 컬럼명 추가
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        worksheet.Cells[1, c + 1].Value = dt.Columns[c].ColumnName;
                    }

                    // 데이터 추가
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        for (int c = 0; c < dt.Columns.Count; c++)
                        {
                            worksheet.Cells[r + 2, c + 1].Value = dt.Rows[r][c]?.ToString();
                        }
                    }

                    // 저장
                    var fileInfo = new FileInfo(dlg.FileName);
                    package.SaveAs(fileInfo);
                }

                MessageBox.Show("엑셀 다운로드 완료");
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public static DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView) //그리드뷰 소스를 DataTable로
        {
            try
            {
                if (_DataGridView.ColumnCount == 0)
                    return null;
                DataTable dtSource = new DataTable();
                // 컬럼 만듦
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.ValueType == null)
                        dtSource.Columns.Add(col.Name, typeof(string));
                    else
                        dtSource.Columns.Add(col.Name, col.ValueType);
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                }
                // 열 데이터 삽입
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                return dtSource;
            }
            catch
            {
                return null;
            }
        }
    }
}
