using System;
using System.IO;
using System.Windows.Forms;
using Beat.lib;

namespace Beat
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();

            string f_tmp = AppDomain.CurrentDomain.BaseDirectory + "~obj.tmp";
            if (!File.Exists(f_tmp))
            {
                FileStream fs = File.Create(f_tmp);
                fs.Close();
                fs.Dispose();
            }
            try
            {
                objFileStream = new FileStream(f_tmp, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            }
            catch
            {
                Win32API.MessageBoxA(IntPtr.Zero, "重复打开！只能同时运行一个程序。", "程序打开失败！", 0x41030);
                return;
            }
            Application.Run(new FrmMain());
        }
        public static FileStream objFileStream;
    }
    
}
