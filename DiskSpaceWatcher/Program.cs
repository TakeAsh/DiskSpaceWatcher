using System;
using System.Linq;
using System.Windows.Forms;

// [Win向け通知アプリにトーストを使う - Qiita](https://qiita.com/120byte/items/5f3993350478a395779e)
// [C#のタスクトレイ常駐アプリの作り方のご紹介！ | .NETコラム](https://www.fenet.jp/dotnet/column/environment/4527/)

namespace DiskSpaceWatcher {
    internal static class Program {
        static Properties.Settings _settings = Properties.Settings.Default;
        static Form1 _form1;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var args = Environment.GetCommandLineArgs();
            var index = 0;
            Notifier.DebugShow(
                $"CommandLineArgs: {args.Length}",
                String.Join("\n", args.Select(arg => $"{index++}:\t{arg}"))
            );
            if (args.Length > 1) {
                var command = args[1];
                var result =
                    command == Properties.Resources.CmdArg_Install ? Installer.Install() :
                    command == Properties.Resources.CmdArg_Uninstall ? Installer.Uninstall() :
                    InstallerResult.UnknownCommand;
                if (result != InstallerResult.Success) {
                    MessageBox.Show(result.ToDescription(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                _form1 = new Form1() {
                    Targets = _settings.Targets.ToTargets(),
                };
                Application.Run();
            }
        }

        /// <summary>
        /// Get a human-readable space size in bytes abbreviation.
        /// </summary>
        /// <param name="byteCount">Space size</param>
        /// <param name="digits">The number of fractional digits</param>
        /// <returns>a human-readable space size</returns>
        /// <remarks>[c# - How do I get a human-readable file size in bytes abbreviation using .NET? - Stack Overflow](https://stackoverflow.com/questions/281640/)</remarks>
        public static String BytesToString(long byteCount, int digits = 0) {
            var suf = new[] { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0) { return $"0 {suf[0]}"; }
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), digits);
            return $"{Math.Sign(byteCount) * num} {suf[place]}";
        }
    }
}
