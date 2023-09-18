using System;
using System.ComponentModel;
using System.IO;
using System.Security.Principal;

namespace DiskSpaceWatcher {
    public static class Installer {
        static string _pathLocal = null;

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

        public static InstallerResult Install() {
            var isAdmin = IsAdministrator();
            Notifier.DebugShow($"isAdmin: {isAdmin}");
            if (!isAdmin) { return InstallerResult.RequireAdmin; }
            Directory.CreateDirectory(PathLocal);
            return !Notifier.Install(PathLocal)
                ? InstallerResult.Failure
                : InstallerResult.Success;
        }

        public static InstallerResult Uninstall() {
            var isAdmin = IsAdministrator();
            Notifier.DebugShow($"isAdmin: {isAdmin}");
            if (!isAdmin) { return InstallerResult.RequireAdmin; }
            var result = !Notifier.Uninstall(PathLocal)
                ? InstallerResult.Failure
                : InstallerResult.Success;
            Directory.Delete(PathLocal, true);
            return result;
        }

        public static bool IsAdministrator() {
            using (var identity = WindowsIdentity.GetCurrent()) {
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
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
