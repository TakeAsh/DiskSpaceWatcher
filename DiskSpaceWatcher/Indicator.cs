using System;
using System.Windows.Forms;

namespace DiskSpaceWatcher {
    public class Indicator : IDisposable {
        static Properties.Settings _settings = Properties.Settings.Default;
        private Target _target = null;
        private int _space = 0;
        private DiskStatus _status = DiskStatus.OK;

        public NotifyIcon Icon { get; private set; }

        public string Drive {
            get { return _target.Drive; }
            set { _target.Drive = value; }
        }

        public int Warning {
            get { return _target.Warning; }
            set { _target.Warning = value; }
        }

        public int Caution {
            get { return _target.Caution; }
            set { _target.Caution = value; }
        }

        public int Space {
            get { return _space; }
            set {
                _space = value;
                Status =
                    _space < 0 ? DiskStatus.UNAVAILABLE :
                    _space < Warning ? DiskStatus.WARNING :
                    _space < Caution ? DiskStatus.CAUTION :
                    DiskStatus.OK;
                Icon.Text = IconText;
            }
        }

        public DiskStatus Status {
            get { return _status; }
            private set {
                if (_status == value) { return; }
                _status = value;
                Icon.Icon = _status.ToIcon();
                Notifier.Show(StatusText);
            }
        }

        private string StatusText {
            get {
                var space = _space >= 0 ? _space.ToString() : "--";
                return $"[{_status.ToDescription()}] {Drive} {space} GB";
            }
        }

        private string IconText {
            get { return $"{Properties.Resources.Product}\n{StatusText}"; }
        }

        public Indicator(Target target, ContextMenuStrip menu = null) {
            _target = target;
            Icon = new NotifyIcon() {
                Text = IconText,
                Icon = Properties.Resources.OK,
                ContextMenuStrip = menu,
                Visible = true,
            };
            Icon.Click += OnClickIcon;
        }

        public void Dispose() {
            if (Icon != null) { Icon.Dispose(); }
        }

        private void OnClickIcon(object sender, EventArgs e) {
            var icon = sender as NotifyIcon;
            var args = e as MouseEventArgs;
            if (icon == null || args.Button != MouseButtons.Left) { return; }
            Notifier.Show(StatusText);
        }
    }
}
