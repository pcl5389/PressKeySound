namespace Beat.lib
{
    class IniFile
    {
        string Path;
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
            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
            Win32API.GetPrivateProfileString(Section, Key, "", temp, 255, Path);
            return temp.ToString();
        }
    }
}
