using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace UsbSuspendOnIdle
{
    public partial class frmMain : Form
    {
        private BindingList<Device> devices;
        private Info info;
        private HtmlRenderer.HtmlPanel hpInfo;

        public frmMain()
        {
            InitializeComponent();
            this.hpInfo = new HtmlRenderer.HtmlPanel();
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            if (!Environment.OSVersion.VersionString.Contains("Microsoft Windows NT 6.3"))
            {
                MessageBox.Show("This application runs only under Windows 8.1 or Windows Server 2012 R2.");
                Application.Exit();
            }
            FirstRunHandler();

            this.devices = Device.GenerateList();
            this.info = new Info();

            this.dgvDevices.DataSource = devices;
            this.lblHotFix.DataBindings.Add(new Binding("Text", this.info, "HotFix"));
            this.lblHotFix.DataBindings.Add(new Binding("ForeColor", this.info, "HotFixColor"));
            this.hpInfo.Dock = DockStyle.Fill;
            this.hpInfo.DataBindings.Add(new Binding("Text", this.info, "InfoText"));
            this.tpInfo.Controls.Add(hpInfo);
        }

        private void FirstRunHandler()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Assembly.GetExecutingAssembly().GetName().Name);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                tcMain.SelectedIndex = 1;
                MessageBox.Show("Please read the following informations and be careful!", "USB SuspendOnIdle");
            }
        }

        private void dgvDevices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) this.devices[e.RowIndex].ToogleSuspendOnIdle();
            System.Diagnostics.Debug.WriteLine(this.devices[e.RowIndex].ToString());
        }
    }
}
