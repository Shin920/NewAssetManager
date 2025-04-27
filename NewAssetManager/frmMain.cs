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

            dgvAddress.Font = new Font("맑은 고딕", 11);
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (AddressDAC cmp = new AddressDAC())
            {
                dgvAddress.DataSource = cmp.GetAddressInfo(txtUsername.Text.Trim(), txtAddress.Text.Trim());
            }
        }
    }
}
