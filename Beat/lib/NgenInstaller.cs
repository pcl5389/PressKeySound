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
           
            // 关闭Shell的使用
            ngenProcess.StartInfo.UseShellExecute = true;
            ngenProcess.StartInfo.Verb = "RunAs";
            /*
            
            ngenProcess.StartInfo.UseShellExecute = false;
            // 重定向标准输入
            ngenProcess.StartInfo.RedirectStandardInput = true;
            // 重定向标准输出
            ngenProcess.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            ngenProcess.StartInfo.RedirectStandardError = true;
            */
            // 设置不显示窗口
            ngenProcess.StartInfo.CreateNoWindow = true;

            ngenProcess.StartInfo.FileName = ngenPath;
            ngenProcess.StartInfo.Arguments = argument;
            ngenProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ngenProcess.Start();


            // 从输出流获取命令执行结果
            //string strRst = ngenProcess.StandardOutput.ReadToEnd();
            //File.WriteAllText(Application.StartupPath+"/log.txt", strRst);
            ngenProcess.WaitForExit();
        }
    }
}
