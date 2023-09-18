using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

// [Send a local toast notification from other types of unpackaged apps - Windows apps | Microsoft Learn](https://learn.microsoft.com/en-us/windows/apps/design/shell/tiles-and-notifications/send-local-toast-other-apps)
// [ToastNotificationManager Class (Windows.UI.Notifications) - Windows UWP applications | Microsoft Learn](https://learn.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastnotificationmanager?view=winrt-22621)
// [audio - Windows UWP applications | Microsoft Learn](https://learn.microsoft.com/en-us/uwp/schemas/tiles/toastschema/element-audio#attributes)
// [Windows 10 のアクションセンターにC#で通知を表示してみた – 日曜研究室](https://peta.okechan.net/blog/archives/4045)
// [【PowerShell】デスクトップ通知のスニペット【トースト通知】 - Qiita](https://qiita.com/relu/items/b7121487a1d5756dfcf9#references)

namespace DiskSpaceWatcher {
    public static class Notifier {
        private static string _appId;
        private static string _pathReg;
        private static ToastNotifier _notifier;

        public static string AppId {
            get {
                return _appId ??
                    (_appId = String.Join(".", Properties.Resources.Company, Properties.Resources.Product));
            }
        }

        public static string PathReg {
            get {
                return _pathReg ??
                    (_pathReg = Path.Combine(Properties.Resources.Reg_AUMID, AppId));
            }
        }

        public static bool IsRegistered { get; private set; }

        static Notifier() {
            using (var regAUMId = Registry.LocalMachine.OpenSubKey(Properties.Resources.Reg_AUMID, false)) {
                IsRegistered = regAUMId.GetSubKeyNames().Contains(AppId);
            }
            var appId = IsRegistered
                ? AppId
                : Properties.Resources.Product;
            _notifier = ToastNotificationManager.CreateToastNotifier(appId);
        }

        public static bool Install(string pathLocal) {
            var pathIcon = Path.Combine(pathLocal, "App.ico");
            Notifier.DebugShow($"pathIcon: {pathIcon}");
            using (var fs = new FileStream(pathIcon, FileMode.Create)) {
                Properties.Resources.DiskSpaceWatcher.Save(fs);
            }
            using (var regAUMId = Registry.LocalMachine.CreateSubKey(PathReg)) {
                regAUMId.SetValue("DisplayName", Properties.Resources.Product);
                regAUMId.SetValue("IconUri", pathIcon);
                regAUMId.SetValue("CustomActivator", $"{{{Properties.Resources.GUID}}}");
            }
            return true;
        }

        public static bool Uninstall(string pathLocal) {
            Registry.LocalMachine.DeleteSubKeyTree(PathReg);
            return true;
        }

        public static void Show(string title, string message = "") {
            //var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText03);
            var template = new XmlDocument();
            template.LoadXml(Properties.Resources.ToastTemplate);
            template.SelectSingleNode("//text[@id='1']").InnerText = title;
            template.SelectSingleNode("//text[@id='2']").InnerText = message;
            var notification = new ToastNotification(template);
            Debug.Write($"{notification.Content.GetXml()}\n");
            _notifier.Show(notification);
        }

        [Conditional("DEBUG")]
        public static void DebugShow(string title, string message = "") {
            Show(title, message);
        }
    }
}
