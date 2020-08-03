using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Beat.lib
{
    [RunInstaller(true)]
    public partial class NgenInstaller// : System.Configuration.Install.Installer
    {
        public enum InstallTypes
        {
            Install,
            Uninstall
        }

        public void NgenFile(InstallTypes options)
        {
            string envDir = RuntimeEnvironment.GetRuntimeDirectory();
            string ngenPath = Path.Combine(envDir, "ngen.exe");
            string exePath = Application.ExecutablePath;
            string argument = (options == InstallTypes.Install ? "install" : "uninstall") + " \"" + exePath + "\"";

            Process ngenProcess = new Process();
            ngenProcess.StartInfo.FileName = ngenPath;
            ngenProcess.StartInfo.Arguments = argument;
            ngenProcess.StartInfo.CreateNoWindow = true;
            ngenProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ngenProcess.Start();

            ngenProcess.WaitForExit();
        }
    }
}
