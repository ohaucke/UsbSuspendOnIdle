# USB SuspendOnIdle
Simple *DeviceHackFlags* Workaround Tool for USB storage devices

![power.png](https://cloud.githubusercontent.com/assets/3750494/7703858/f9c50be8-fe3a-11e4-9eb5-fe5e2f38349d.png)

__Problems with Windows 8.1 and Windows Server 2012 R2’s power safe option__  
Some USB storage devices do not work correctly when using the power safe option. Devices that have not been used for a certain time suspend on idle. If you then try to access the files on the device, Windows Explorer becomes unresponsive for one to two minutes or the device does not restart properly and will be ejected and reinitialized. 

You can fix this by installing the latest firmware for your system or device, the [KB2911106](http://support.microsoft.com/kb/2914219/en-us) Hotfix (Download: [x86](http://www.microsoft.com/de-de/download/details.aspx?id=41569) / [x64](http://www.microsoft.com/de-de/download/details.aspx?id=41570)) _\*if your device is supported\*_, or by setting the _DeviceHackFlags_ for your device on the "Devices" tab. You just have to uncheck the box for your device in the "SOI" (SuspendOnIdle) column.

__For more informations:__  
* [USB storage device does not work correctly in Windows 8.1 and in Windows Server 2012 R2](http://support.microsoft.com/kb/2914219/en-us)
* [Help! After installing Windows 8.1, my USB drive disappears or file transfers stop unexpectedly…](http://blogs.msdn.com/b/usbcoreblog/archive/2013/11/01/help-after-installing-windows-8-1-my-usb-drive-disappears-or-file-transfers-stop-unexpectedly-r-a-post-title.aspx)

## Screens
![devices.png](https://cloud.githubusercontent.com/assets/3750494/7703856/f9a0b9b4-fe3a-11e4-95eb-8bbfa0470767.png)

![info.png](https://cloud.githubusercontent.com/assets/3750494/7703857/f9c2f060-fe3a-11e4-8cf5-4f35a7796d32.png)

## Requirements
* [.Net Framework 4.0](http://www.microsoft.com/de-de/download/details.aspx?id=17718)
* [HtmlRenderer](https://github.com/ArthurHub/HTML-Renderer)

## General
Name: USB SuspendOnIdle  
Description: Simple DeviceHackFlags Workaround Tool for USB storage devices  
Version: 1.0  
Author: Oliver Haucke  
Author URI: http://gadean.de/  
E-Mail: ohaucke@gadean.de  
License: BSD 2-Clause  
License URI: http://opensource.org/licenses/BSD-2-Clause
