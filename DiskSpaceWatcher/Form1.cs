using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace DiskSpaceWatcher {
    public partial class Form1 : Form {
        static Properties.Settings _settings = Properties.Settings.Default;
        private const long _gigaBytes = 1024 * 1024 * 1024;
        private const int _maxIcons = 8;
        private Targets _targets = null;
        private List<Indicator> _indicators = null;

        public Targets Targets {
            get { return _targets; }
            set {
                _targets = value;
                InitDialog();
                InitIndicators();
                var drives = String.Join(", ", _targets.Drives);
                Notifier.Show($"Watching: {drives}");
                CheckDisks();
            }
        }

        public Form1() {
            InitializeComponent();
            timerWatch.Interval = _settings.WatchInterval * 1000;
            timerWatch.Start();
        }

        public void InitDialog() {
            var drives = DriveInfo.GetDrives();
            var driveNames = drives.Select(info => info.Name.Substring(0, info.Name.Length - 1)).ToArray();
            listboxDrives.Items.AddRange(driveNames);
            if (_targets != null) {
                var targetDrives = _targets.Drives;
                for (var i = 0; i < listboxDrives.Items.Count; ++i) {
                    listboxDrives.SetItemChecked(i, targetDrives.Contains(driveNames[i]));
                }
            }
            var thresholds = _settings.Thresholds.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            comboBoxWarning.Items.AddRange(thresholds);
            comboBoxWarning.SelectedIndex = 0;
            comboBoxCaution.Items.AddRange(thresholds);
            comboBoxCaution.SelectedIndex = 0;
        }

        public void InitIndicators() {
            if (_targets == null) { return; }
            _indicators = _targets.ToList()
                .Select(target => new Indicator(target, contextMenu))
                .ToList();
        }

        private void CheckDisks() {
            if (_indicators == null) { return; }
            var drives = DriveInfo.GetDrives();
            _indicators.ForEach(indicator => {
                var drive = drives.FirstOrDefault(d => d.Name.StartsWith(indicator.Drive));
                if (drive == null) { return; }
                indicator.Space =
                    !drive.IsReady ? -1 :
                    (int)(drive.AvailableFreeSpace / _gigaBytes);
            });
        }

        private void OnUpdateSetting() {
            _settings.Targets = _targets.ToString();
            _settings.Save();
            CheckDisks();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            this.Hide();
            if (e.CloseReason == CloseReason.UserClosing) { e.Cancel = true; }
        }

        private void listboxDrives_SelectedIndexChanged(object sender, EventArgs e) {
            var listbox = sender as CheckedListBox;
            var drive = listboxDrives.SelectedItem as string;
            if (!_targets.ContainsKey(drive)) { return; }
            var target = _targets[drive];
            comboBoxWarning.SelectedItem = target.Warning.ToString();
            comboBoxCaution.SelectedItem = target.Caution.ToString();
        }

        private void listboxDrives_ItemCheck(object sender, ItemCheckEventArgs e) {
            var listbox = sender as CheckedListBox;
            var drive = listboxDrives.Items[e.Index] as string;
            if (e.NewValue == CheckState.Checked && !_targets.ContainsKey(drive)) {
                var warning = (comboBoxWarning.SelectedItem as string).TryParse<int>();
                var caution = (comboBoxCaution.SelectedItem as string).TryParse<int>();
                var target = new Target(drive, warning, caution);
                _targets[drive] = target;
                _indicators.Add(new Indicator(target, contextMenu));
                CheckDisks();
            } else if (e.NewValue == CheckState.Unchecked && _targets.ContainsKey(drive)) {
                if (listboxDrives.CheckedItems.Count > 1) {
                    var indicator = _indicators.Find(ind => ind.Drive == drive);
                    _indicators.Remove(indicator);
                    indicator.Dispose();
                    _targets.Remove(drive);
                } else {
                    e.NewValue = CheckState.Checked;
                    return;
                }
            } else {
                return;
            }
            OnUpdateSetting();
        }

        private void comboBoxWarning_SelectedIndexChanged(object sender, EventArgs e) {
            var combobox = sender as ComboBox;
            var drive = listboxDrives.SelectedItem as string;
            if (drive == null || !_targets.ContainsKey(drive)) { return; }
            var target = _targets[drive];
            target.Warning = (combobox.SelectedItem as string).TryParse<int>();
            OnUpdateSetting();
        }

        private void comboBoxCaution_SelectedIndexChanged(object sender, EventArgs e) {
            var combobox = sender as ComboBox;
            var drive = listboxDrives.SelectedItem as string;
            if (drive == null || !_targets.ContainsKey(drive)) { return; }
            var target = _targets[drive];
            target.Caution = (combobox.SelectedItem as string).TryParse<int>();
            OnUpdateSetting();
        }

        private void timerWatch_Tick(object sender, EventArgs e) {
            CheckDisks();
        }

        private void menuItemExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void menuItemSetting_Click(object sender, EventArgs e) {
            this.Show();
        }

        private void menuitemInstall_Click(object sender, EventArgs e) {
            try {
                var pathSelf = Assembly.GetExecutingAssembly().Location;
                var process = new Process() {
                    StartInfo = new ProcessStartInfo() {
                        FileName = pathSelf,
                        Arguments = Properties.Resources.CmdArg_Install,
                        Verb = "runas",
                    },
                };
                process.Start();
                process.WaitForExit();
                Notifier.DebugShow($"ExitCode: {process.ExitCode}");
                Application.Restart();
            } catch (Exception ex) {
                Notifier.Show("Install failed", ex.Message);
            }
        }

        private void menuitemUninstall_Click(object sender, EventArgs e) {
            try {
                var pathSelf = Assembly.GetExecutingAssembly().Location;
                var process = new Process() {
                    StartInfo = new ProcessStartInfo() {
                        FileName = pathSelf,
                        Arguments = Properties.Resources.CmdArg_Uninstall,
                        Verb = "runas",
                    },
                };
                process.Start();
                process.WaitForExit();
                Notifier.DebugShow($"ExitCode: {process.ExitCode}");
                Application.Restart();
            } catch (Exception ex) {
                Notifier.Show("Uninstall failed", ex.Message);
            }
        }
    }
}
