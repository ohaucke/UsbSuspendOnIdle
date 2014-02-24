using System.Windows.Forms;
namespace UsbSuspendOnIdle
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpDevices = new System.Windows.Forms.TabPage();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.cCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSuspendOnIdle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cVIdPId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpInfo = new System.Windows.Forms.TabPage();
            this.lblHotFix = new System.Windows.Forms.Label();
            this.tcMain.SuspendLayout();
            this.tpDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.tpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpDevices);
            this.tcMain.Controls.Add(this.tpInfo);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Margin = new System.Windows.Forms.Padding(10);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(734, 408);
            this.tcMain.TabIndex = 0;
            // 
            // tpDevices
            // 
            this.tpDevices.Controls.Add(this.dgvDevices);
            this.tpDevices.Location = new System.Drawing.Point(4, 22);
            this.tpDevices.Name = "tpDevices";
            this.tpDevices.Padding = new System.Windows.Forms.Padding(3);
            this.tpDevices.Size = new System.Drawing.Size(726, 382);
            this.tpDevices.TabIndex = 0;
            this.tpDevices.Text = "Devices";
            this.tpDevices.UseVisualStyleBackColor = true;
            // 
            // dgvDevices
            // 
            this.dgvDevices.AllowUserToAddRows = false;
            this.dgvDevices.AllowUserToDeleteRows = false;
            this.dgvDevices.AllowUserToResizeRows = false;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCaption,
            this.cSerialNumber,
            this.cSuspendOnIdle,
            this.cVIdPId});
            this.dgvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevices.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDevices.Location = new System.Drawing.Point(3, 3);
            this.dgvDevices.MultiSelect = false;
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.RowHeadersVisible = false;
            this.dgvDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevices.Size = new System.Drawing.Size(720, 376);
            this.dgvDevices.TabIndex = 0;
            this.dgvDevices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevices_CellClick);
            // 
            // cCaption
            // 
            this.cCaption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cCaption.DataPropertyName = "Caption";
            this.cCaption.HeaderText = "Caption";
            this.cCaption.Name = "cCaption";
            this.cCaption.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cSerialNumber
            // 
            this.cSerialNumber.DataPropertyName = "SerialNumber";
            this.cSerialNumber.HeaderText = "Serial Number";
            this.cSerialNumber.Name = "cSerialNumber";
            this.cSerialNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cSerialNumber.ToolTipText = "Serial number";
            this.cSerialNumber.Width = 121;
            // 
            // cSuspendOnIdle
            // 
            this.cSuspendOnIdle.DataPropertyName = "SuspendOnIdle";
            this.cSuspendOnIdle.HeaderText = "SOI";
            this.cSuspendOnIdle.Name = "cSuspendOnIdle";
            this.cSuspendOnIdle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cSuspendOnIdle.ToolTipText = "Suspend on idle";
            this.cSuspendOnIdle.Width = 35;
            // 
            // cVIdPId
            // 
            this.cVIdPId.DataPropertyName = "VidPidHwid";
            this.cVIdPId.HeaderText = "VID / PID";
            this.cVIdPId.Name = "cVIdPId";
            this.cVIdPId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cVIdPId.ToolTipText = "Vendor ID / Product ID";
            this.cVIdPId.Width = 160;
            // 
            // tpInfo
            // 
            this.tpInfo.Controls.Add(this.lblHotFix);
            this.tpInfo.Location = new System.Drawing.Point(4, 22);
            this.tpInfo.Name = "tpInfo";
            this.tpInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpInfo.Size = new System.Drawing.Size(726, 382);
            this.tpInfo.TabIndex = 1;
            this.tpInfo.Text = "Info";
            this.tpInfo.UseVisualStyleBackColor = true;
            // 
            // lblHotFix
            // 
            this.lblHotFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHotFix.AutoSize = true;
            this.lblHotFix.Location = new System.Drawing.Point(8, 364);
            this.lblHotFix.Name = "lblHotFix";
            this.lblHotFix.Size = new System.Drawing.Size(0, 13);
            this.lblHotFix.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 408);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB SuspendOnIdle";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tcMain.ResumeLayout(false);
            this.tpDevices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.tpInfo.ResumeLayout(false);
            this.tpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpDevices;
        private System.Windows.Forms.TabPage tpInfo;
        private System.Windows.Forms.DataGridView dgvDevices;
        private DataGridViewTextBoxColumn cCaption;
        private DataGridViewTextBoxColumn cSerialNumber;
        private DataGridViewCheckBoxColumn cSuspendOnIdle;
        private DataGridViewTextBoxColumn cVIdPId;
        private Label lblHotFix;
    }
}

