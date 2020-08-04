using System.Text;

namespace Beat.lib
{
    class IniFile
    {
        //文件INI名称 
        string Path;
        //类的构造函数，传递INI文件名 
        public IniFile(string inipath)
        {
            Path = inipath;
        }

        //写INI文件 
        public void IniWriteValue(string Section, string Key, string Value)
        {
            Win32API.WritePrivateProfileString(Section, Key, Value, Path);
        }

        //读取INI文件指定 
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            Win32API.GetPrivateProfileString(Section, Key, "", temp, 255, Path);
            return temp.ToString();
        }
    }
}
