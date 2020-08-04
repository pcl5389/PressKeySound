using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Beat.lib
{
    class HotKeys
    {
        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="hotKey_id">热键ID</param>
        /// <param name="keyModifiers">组合键</param>
        /// <param name="key">热键</param>
        public static bool RegHotKey(IntPtr hwnd, int hotKeyId, Win32API.KeyModifiers keyModifiers, Keys key, string strHotKeys="")
        {
            if (!Win32API.RegisterHotKey(hwnd, hotKeyId, keyModifiers, key))
            {
                int errorCode = Marshal.GetLastWin32Error();
                if (errorCode == 1409)
                {
                    MessageBox.Show(string.Format("热键{0}已被占用，请更换 ！", string.IsNullOrEmpty(strHotKeys) ? "" : ("<" + strHotKeys + ">")));
                }
                else
                {
                    MessageBox.Show(string.Format("注册热键{0}失败！错误代码：{1}", string.IsNullOrEmpty(strHotKeys) ? "" : ("<" + strHotKeys + ">"), errorCode));
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// 注销热键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="hotKey_id">热键ID</param>
        public static void UnRegHotKey(IntPtr hwnd, int hotKeyId)
        {
            //注销指定的热键
            Win32API.UnregisterHotKey(hwnd, hotKeyId);
        }
    }
}
