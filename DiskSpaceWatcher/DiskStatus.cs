using System.ComponentModel;
using System.Drawing;

namespace DiskSpaceWatcher {
    public enum DiskStatus {
        [Description("－")]
        UNAVAILABLE,
        [Description("\U0001F7E2")] // green circle
        OK,
        [Description("\U0001F7E8")] // yellow square, "warning"(U+26A0 U+FE0F) is displayed as text
        CAUTION,
        [Description("\U0001F7E5")] // red square
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
