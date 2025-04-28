
namespace NewAssetManager
{
    partial class frmIpReg
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dtpRegDate = new System.Windows.Forms.DateTimePicker();
            this.lblExternal = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtExternal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(143, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "신규 IP 등록";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(160, 187);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(185, 21);
            this.txtUsername.TabIndex = 3;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUsername.Location = new System.Drawing.Point(87, 190);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(57, 12);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "사용자명";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(160, 93);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(185, 21);
            this.txtAddress.TabIndex = 0;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAddress.Location = new System.Drawing.Point(100, 96);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(44, 12);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "IP주소";
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(160, 126);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(185, 21);
            this.txtPurpose.TabIndex = 1;
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPurpose.Location = new System.Drawing.Point(113, 129);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(31, 12);
            this.lblPurpose.TabIndex = 8;
            this.lblPurpose.Text = "용도";
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(160, 157);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(185, 21);
            this.txtDept.TabIndex = 2;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDept.Location = new System.Drawing.Point(113, 160);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(31, 12);
            this.lblDept.TabIndex = 10;
            this.lblDept.Text = "소속";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(160, 216);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(185, 21);
            this.txtLocation.TabIndex = 4;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocation.Location = new System.Drawing.Point(87, 219);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(57, 12);
            this.lblLocation.TabIndex = 12;
            this.lblLocation.Text = "설치위치";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(160, 243);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(185, 79);
            this.txtRemark.TabIndex = 5;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemark.Location = new System.Drawing.Point(113, 246);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(31, 12);
            this.lblRemark.TabIndex = 14;
            this.lblRemark.Text = "비고";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(87, 344);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(57, 12);
            this.lblDate.TabIndex = 16;
            this.lblDate.Text = "할당일자";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(454, 703);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // dtpRegDate
            // 
            this.dtpRegDate.Location = new System.Drawing.Point(160, 338);
            this.dtpRegDate.Name = "dtpRegDate";
            this.dtpRegDate.Size = new System.Drawing.Size(185, 21);
            this.dtpRegDate.TabIndex = 6;
            // 
            // lblExternal
            // 
            this.lblExternal.AutoSize = true;
            this.lblExternal.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblExternal.Location = new System.Drawing.Point(87, 381);
            this.lblExternal.Name = "lblExternal";
            this.lblExternal.Size = new System.Drawing.Size(57, 12);
            this.lblExternal.TabIndex = 20;
            this.lblExternal.Text = "외부사용";
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(102, 449);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(113, 41);
            this.btnReg.TabIndex = 22;
            this.btnReg.Text = "등록";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(257, 449);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 41);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtExternal
            // 
            this.txtExternal.Location = new System.Drawing.Point(160, 378);
            this.txtExternal.Name = "txtExternal";
            this.txtExternal.Size = new System.Drawing.Size(185, 21);
            this.txtExternal.TabIndex = 7;
            // 
            // frmIpReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 517);
            this.Controls.Add(this.txtExternal);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.lblExternal);
            this.Controls.Add(this.dtpRegDate);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.txtPurpose);
            this.Controls.Add(this.lblPurpose);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label1);
            this.Name = "frmIpReg";
            this.Text = "frmIpReg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.Label lblPurpose;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dtpRegDate;
        private System.Windows.Forms.Label lblExternal;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtExternal;
    }
}