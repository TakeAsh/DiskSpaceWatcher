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
    }
}
