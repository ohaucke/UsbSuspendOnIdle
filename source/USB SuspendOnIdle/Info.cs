using System.ComponentModel;
using System.Drawing;
using System.Management;

namespace UsbSuspendOnIdle
{
    /// <summary>
    /// UI Stuff
    /// </summary>
    public class Info : INotifyPropertyChanged
    {
        private string hotFix;
        private string infoText;
        private Color hotFixColor;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// UI stuff constructor
        /// </summary>
        public Info()
        {
            this.hotFix = "HotFix KB2911106 is not installed.";
            this.hotFixColor = Color.Red;
            using(ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT HotFixID FROM Win32_QuickFixEngineering"))
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    if (item["HotFixID"].ToString() == "KB2911106")
                    {
                        this.hotFix = "HotFix KB2911106 is installed.";
                        this.hotFixColor = Color.Green;
                    }
                }
            }
            this.NotifyPropertyChanged("HotFix");

            this.infoText = Properties.Resources.info;
            this.NotifyPropertyChanged("InfoText");
        }

        /// <summary>
        /// HTML Text for Info tab
        /// </summary>
        public string InfoText
        {
            get { return this.infoText; }
        }

        /// <summary>
        /// Hotfix installed text
        /// </summary>
        public string HotFix
        {
            get { return this.hotFix; }
        }

        /// <summary>
        /// Color for the HotFix installed label
        /// </summary>
        public Color HotFixColor
        {
            get { return this.hotFixColor; }
        }
    }
}


