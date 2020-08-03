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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLoading = new frmLoading();
            frmLoading.Show();
            frmLoading.Update();

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
                Application.Run(new frmMain());
            }
            catch
            {
                frmLoading.Close();
                Win32API.MessageBoxA(IntPtr.Zero, "重复打开程序", "程序打开失败！", 0x41030); //266288
            }
        }
        public static FileStream objFileStream;
        public static frmLoading frmLoading = null;
    }
    
}
