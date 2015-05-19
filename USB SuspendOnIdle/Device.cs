using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Management;
using Microsoft.Win32;

namespace UsbSuspendOnIdle
{
    /// <summary>
    /// USB Device
    /// </summary>
    public class Device : INotifyPropertyChanged
    {
        private string caption;
        private string serialNumber;
        private string vid;
        private string pid;
        private bool suspendOnIdle;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Device() { }

        private Device(ManagementObject usbDiskDrive, List<string> usbControllerDevices)
        {
            this.caption = usbDiskDrive["Caption"].ToString();
            this.serialNumber = usbDiskDrive["SerialNumber"].ToString();

            string temp = usbControllerDevices.Find((e) => { return e.Contains(this.serialNumber); });
            if (temp != null)
            {
                int i = temp.IndexOf("VID_", StringComparison.CurrentCulture);
                this.vid = temp.Substring(i + 4, 4).ToString();
                this.pid = temp.Substring(i + 13, 4).ToString();
            }
            this.suspendOnIdle = this.CheckSuspendOnIdle();
        }

        /// <summary>
        /// Device caption
        /// </summary>
        public string Caption
        {
            get { return this.caption; }
        }

        /// <summary>
        /// Servial number
        /// </summary>
        public string SerialNumber
        {
            get { return this.serialNumber; }
        }

        /// <summary>
        /// Suspend on idle
        /// </summary>
        public bool SuspendOnIdle
        {
            get { return this.suspendOnIdle; }
        }

        /// <summary>
        /// Vendor Id / Product Id 
        /// </summary>
        public string VidPidHwid
        {
            get { return ((string.IsNullOrEmpty(this.vid) && string.IsNullOrEmpty(this.pid)) ? "Couldn't find any id" : string.Format("USB\\VID_{0}&PID_{1}", this.vid, this.pid)); }
        }

        /// <summary>
        /// Toogle "DeviceHackFlags" for the device
        /// </summary>
        public void ToogleSuspendOnIdle()
        {
            if (this.CheckSuspendOnIdle())
            {
                // suspend on idle deactivate
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\usbstor\" + this.vid + this.pid, "DeviceHackFlags", 1024, RegistryValueKind.DWord);
            }
            else
            {
                // suspend on idle activate
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\usbstor\" + this.vid + this.pid, "DeviceHackFlags", 0, RegistryValueKind.DWord);

            }

            this.suspendOnIdle = this.CheckSuspendOnIdle();
            NotifyPropertyChanged("SuspendOnIdle");
        }

        /// <summary>
        /// Device string with caption, suspend on idle state and Vendor Id/Product Id 
        /// </summary>
        /// <returns>Device string</returns>
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", this.caption, this.suspendOnIdle, this.VidPidHwid);
        }

        /// <summary>
        /// Checks whether "suspend on idle" is enabled for the device
        /// </summary>
        /// <returns></returns>
        public bool CheckSuspendOnIdle()
        {
            object tmp = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\usbstor\" + this.vid + this.pid, "DeviceHackFlags", -1);
            return (tmp == null ? true : ((int)tmp == 1024 ? false : true));
        }

        /// <summary>
        /// Generates a list of devices
        /// </summary>
        /// <returns>List of devices</returns>
        public static BindingList<Device> GenerateList()
        {
            List<string> usbControllerDevices = new List<string>();
            BindingList<Device> devices = new BindingList<Device>();
            using(ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Dependent FROM Win32_USBControllerDevice"))
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    usbControllerDevices.Add(queryObj["Dependent"].ToString());
                }
            }

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Caption, SerialNumber FROM Win32_DiskDrive WHERE InterfaceType = 'USB'"))
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    devices.Add(new Device(queryObj, usbControllerDevices));
                }
            }

            return devices;
        }

        /// <summary>
        /// Generates a list of devices for demonstration
        /// </summary>
        /// <returns>List of devices for demonstration</returns>
        public static BindingList<Device> GenerateListOfDemoData()
        {
            BindingList<Device> devices = new BindingList<Device>();
            Random r = new Random();

            devices.Add(new Device() { caption = "BUFFALO HD-PNTU3 (1TB)", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "0930", pid = "0B1A" });
            devices.Add(new Device() { caption = "Buffalo DriveStation HD-LB2.0TU2-UK (2GB)", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "0411", pid = "01EA" });
            devices.Add(new Device() { caption = "Buffalo HD-LBV3.0TU3 (3GB)", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "0411", pid = "01E5" });
            devices.Add(new Device() { caption = "Buffalo External HDD 500GB", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "0411", pid = "0105" });
            devices.Add(new Device() { caption = "datAshur", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "2009", pid = "5004" });
            devices.Add(new Device() { caption = "Fantom Drive, USB 3.0, model: GF3BM1000U", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "174C", pid = "5106" });
            devices.Add(new Device() { caption = "Sabrent 2.5\" SATA Hard Drive To USB 3.0 Enclosure", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "174C", pid = "9106" });
            devices.Add(new Device() { caption = "StarTech SAT2510B12U3", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "174C", pid = "5136" });
            devices.Add(new Device() { caption = "Fantom Compact 4 TB USB Hard Drive, model: GF3B4000U", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "0BDA", pid = "0184" });
            devices.Add(new Device() { caption = "BUFFALO HD-PNTU3 (1TB)", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "0411", pid = "01E7" });
            devices.Add(new Device() { caption = "Buffalo DriveStation HD-LB2.0TU2-UK (2GB)", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "0411", pid = "01EA" });
            devices.Add(new Device() { caption = "Buffalo HD-LBV3.0TU3 (3GB)", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "0411", pid = "01E5" });
            devices.Add(new Device() { caption = "Buffalo External HDD 500GB", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "0411", pid = "0105" });
            devices.Add(new Device() { caption = "datAshur", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "2009", pid = "5004" });
            devices.Add(new Device() { caption = "Fantom Drive, USB 3.0, model: GF3BM1000U", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "174C", pid = "5106" });
            devices.Add(new Device() { caption = "Sabrent 2.5\" SATA Hard Drive To USB 3.0 Enclosure", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "174C", pid = "9106" });
            devices.Add(new Device() { caption = "StarTech SAT2510B12U3", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "174C", pid = "5136" });
            devices.Add(new Device() { caption = "Fantom Compact 4 TB USB Hard Drive, model: GF3B4000U", serialNumber = (Guid.NewGuid().ToString().Split('-')[0]), suspendOnIdle = ((r.Next(10) % 2 == 0) ? true : false), vid = "0BDA", pid = "0184" });

            return devices;
        }
    }
}
