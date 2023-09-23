# DiskSpaceWatcher
- show drive information in nortification area, and notify when free space is few.
- ![ScreenShot](https://raw.githubusercontent.com/TakeAsh/DiskSpaceWatcher/master/images/ScreenShot.png)
- ![ToastNotifcation](https://raw.githubusercontent.com/TakeAsh/DiskSpaceWatcher/master/images/ToastNotifcation.png)

## How to install
1. place `DiskSpaceWatcher.exe` file and `Microsoft.Win32.Registry.dll` file into folder where you like.
1. run `DiskSpaceWatcher.exe` file.
1. right click icon in notification area.
1. select `Install > Install` in menu.<br>
![Menu](https://raw.githubusercontent.com/TakeAsh/DiskSpaceWatcher/master/images/Menu.png)

## How to uninstall
1. right click icon in notification area.
1. select `Install > Uninstall` in menu.<br>
![Menu](https://raw.githubusercontent.com/TakeAsh/DiskSpaceWatcher/master/images/Menu.png)
1. delete `DiskSpaceWatcher.exe` file and `Microsoft.Win32.Registry.dll` file.

## Setting
1. right click icon in notification area.
1. select `Setting` in menu.<br>
![Menu](https://raw.githubusercontent.com/TakeAsh/DiskSpaceWatcher/master/images/Menu.png)
1. `Setting` dialog appears.<br>
![SettingDialog](https://raw.githubusercontent.com/TakeAsh/DiskSpaceWatcher/master/images/SettingDialog.png)
1. check drives that you want to watch, and select `Warning` threshold and `Caution` threshold for each drives.
1. close dialog by clicking up-right close button.

## Appendix
- To show ToastNotification, this software needs registory settings `HKLM\SOFTWARE\Classes\AppUserModelId\TakeAsh.net.DiskSpaceWatcher` and folder `%LocalAppData%\TakeAsh.net`.
- Watch interval is 30 seconds.
