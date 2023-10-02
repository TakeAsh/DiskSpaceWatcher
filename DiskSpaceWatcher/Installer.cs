using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace DiskSpaceWatcher {
    public static class Installer {
        static string _pathLocal = null;
        static string _pathStartup = null;

        private static string PathLocal {
            get {
                return _pathLocal ??
                    (_pathLocal = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        Properties.Resources.Company,
                        Properties.Resources.Product
                    ));
            }
        }

        private static string PathStartup {
            get {
                return _pathStartup ??
                    (_pathStartup = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                        Properties.Resources.Product + ".lnk"
                    ));
            }
        }

        public static InstallerResult Install() {
            var isAdmin = IsAdministrator();
            Notifier.DebugShow($"isAdmin: {isAdmin}");
            if (!isAdmin) { return InstallerResult.RequireAdmin; }
            Directory.CreateDirectory(PathLocal);
            CreateShortCut(PathStartup, Application.ExecutablePath);
            return
                !Notifier.Install(PathLocal) ? InstallerResult.Failure :
                InstallerResult.Success;
        }

        public static InstallerResult Uninstall() {
            var isAdmin = IsAdministrator();
            Notifier.DebugShow($"isAdmin: {isAdmin}");
            if (!isAdmin) { return InstallerResult.RequireAdmin; }
            File.Delete(PathStartup);
            var result =
                !Notifier.Uninstall(PathLocal) ? InstallerResult.Failure :
                InstallerResult.Success;
            Directory.Delete(PathLocal, true);
            return result;
        }

        public static bool IsAdministrator() {
            using (var identity = WindowsIdentity.GetCurrent()) {
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public static void CreateShortCut(string path, string target, string arguments = "") {
            var shell = new IWshRuntimeLibrary.WshShell();
            var shortcut = shell.CreateShortcut(path) as IWshRuntimeLibrary.IWshShortcut;
            shortcut.TargetPath = target;
            shortcut.Arguments = arguments;
            shortcut.Save();
            Marshal.FinalReleaseComObject(shortcut);
            Marshal.FinalReleaseComObject(shell);
        }
    }

    public enum InstallerResult {
        [Description("Success")]
        Success = 0,
        [Description("Failure")]
        Failure,
        [Description("Unknown Command")]
        UnknownCommand,
        [Description("Require Admin")]
        RequireAdmin,
    }
}
