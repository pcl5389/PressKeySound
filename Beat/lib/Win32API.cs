using System;
using System.Runtime.InteropServices;

namespace Beat.lib
{
    class Win32API
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        public static extern bool HideCaret(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern long MessageBoxA(IntPtr hWnd, string msg, string title, int typ);
    }
}
