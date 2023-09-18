using System.ComponentModel;
using System.Drawing;

namespace DiskSpaceWatcher {
    public enum DiskStatus {
        [Description("－")]
        UNAVAILABLE,
        [Description("○")]
        OK,
        [Description("⚠")]
        CAUTION,
        [Description("❎")]
        WARNING,
    }

    public static class DiskStatusHelper {
        public static Icon ToIcon(this DiskStatus status) {
            return
                status == DiskStatus.UNAVAILABLE ? Properties.Resources.Unavailable :
                status == DiskStatus.OK ? Properties.Resources.OK :
                status == DiskStatus.CAUTION ? Properties.Resources.Caution :
                status == DiskStatus.WARNING ? Properties.Resources.Warning :
                null;
        }
    }
}
