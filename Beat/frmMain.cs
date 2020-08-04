//#define LOGS
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Beat.lib;

namespace Beat
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲

            InitializeComponent();
        }

        private string CheckKey(params  string[] args)
        {
            ArrayList ar = new ArrayList();
            foreach (string arg in args)
            {
                if (!string.IsNullOrEmpty(arg))
                {
                    if (ar.Contains(arg))
                        return string.Format("热键<{0}>重复！", arg);
                    else
                        ar.Add(arg);
                }
            }
            return string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //检查是否有重复键
            if (CheckKey(tbHotKey1.Text, tbHotKey2.Text, tbHotKey3.Text, tbHotKey4.Text, tbHotKey5.Text, tbHotKey6.Text) is string err && !string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err);
                return;
            }
            SaveConfig();
            AutoRegHotKey();
            btnCancel.Enabled = btnApply.Enabled = false;
            btnReset.Enabled = true;
            HotKeyGetFocus();
        }

        public void play_sound(string wav_path)
        {
            if (File.Exists(wav_path))
            {
                System.Media.SoundPlayer sndPlayer = new System.Media.SoundPlayer(wav_path);
                sndPlayer.Play();
            }
            else
            {
                MessageBox.Show("声音文件不存在！" + wav_path);
            }
        }

        List<int> HotKeyIds = new List<int>();
        public void AutoRegHotKey()
        {
            foreach (var id in HotKeyIds)
            {
                HotKeys.UnRegHotKey(Handle, id);
            }
            if (!string.IsNullOrEmpty(tbHotKey1.Text) && !string.IsNullOrEmpty(tbWavPath1.Text) && RegHotKey(0x80F1, tbHotKey1.Text))
            {
                HotKeyIds.Add(0x80F1);
            }
            if (!string.IsNullOrEmpty(tbHotKey2.Text) && !string.IsNullOrEmpty(tbWavPath2.Text) && RegHotKey(0x80F2, tbHotKey2.Text))
            {
                HotKeyIds.Add(0x80F2);
            }
            if (!string.IsNullOrEmpty(tbHotKey3.Text) && !string.IsNullOrEmpty(tbWavPath3.Text) && RegHotKey(0x80F3, tbHotKey3.Text))
            {
                HotKeyIds.Add(0x80F3);
            }
            if (!string.IsNullOrEmpty(tbHotKey4.Text) && !string.IsNullOrEmpty(tbWavPath4.Text) && RegHotKey(0x80F4, tbHotKey4.Text))
            {
                HotKeyIds.Add(0x80F4);
            }
            if (!string.IsNullOrEmpty(tbHotKey5.Text) && !string.IsNullOrEmpty(tbWavPath5.Text) && RegHotKey(0x80F5, tbHotKey5.Text))
            {
                HotKeyIds.Add(0x80F5);
            }
            if (!string.IsNullOrEmpty(tbHotKey6.Text) && !string.IsNullOrEmpty(tbWavPath6.Text) && RegHotKey(0x80F6, tbHotKey6.Text))
            {
                HotKeyIds.Add(0x80F6);
            }
        }

        public bool RegHotKey(int key_id = 0x80F0, string strHotKey = "Ctrl + F1")
        {
            //热键一
            if (Str2HotKey(strHotKey, out Win32API.KeyModifiers hotKeyModify, out Keys hotKey))
            {
                return HotKeys.RegHotKey(Handle, key_id, hotKeyModify, hotKey, strHotKey);
            }
            else
            {
                MessageBox.Show(string.Format("无法识别的热键！<{0}>", strHotKey));
            }
            return false;
        }
        bool bActived = true;
        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg.Equals(WM_HOTKEY))
            {
                int iEventID = msg.WParam.ToInt32();
                switch (iEventID)
                {
                    case 0x80F1:
                        play_sound(Path.Combine(Application.StartupPath, tbWavPath1.Text));
                        break;
                    case 0x80F2:
                        play_sound(Path.Combine(Application.StartupPath, tbWavPath2.Text));
                        break;
                    case 0x80F3:
                        play_sound(Path.Combine(Application.StartupPath, tbWavPath3.Text));
                        break;
                    case 0x80F4:
                        play_sound(Path.Combine(Application.StartupPath, tbWavPath4.Text));
                        break;
                    case 0x80F5:
                        play_sound(Path.Combine(Application.StartupPath, tbWavPath5.Text));
                        break;
                    case 0x80F6:
                        play_sound(Path.Combine(Application.StartupPath, tbWavPath6.Text));
                        break;
                    default:
                        return;
                }
                if (bActived)
                {
                    SetHotKey(iEventID);
                }
            }
            else
                base.WndProc(ref msg);
        }

        private void SetHotKey(int EventID)
        {
            if (ActiveControl is TextBox tb && GetHotKey(EventID) is string KeyText && !string.IsNullOrEmpty(KeyText))
            {
                switch (tb.Name)
                {
                    case "tbHotKey1":
                        tbHotKey1.Text = KeyText; return;
                    case "tbHotKey2":
                        tbHotKey2.Text = KeyText; return;
                    case "tbHotKey3":
                        tbHotKey3.Text = KeyText; return;
                    case "tbHotKey4":
                        tbHotKey4.Text = KeyText; return;
                    case "tbHotKey5":
                        tbHotKey5.Text = KeyText; return;
                    case "tbHotKey6":
                        tbHotKey6.Text = KeyText; return;
                }
            }
        }

        private string GetHotKey(int EventID)
        {
            switch (EventID)
            {
                case 0x80F1:
                    return tbHotKey1.Tag.ToString();
                case 0x80F2:
                    return tbHotKey2.Tag.ToString();
                case 0x80F3:
                    return tbHotKey3.Tag.ToString();
                case 0x80F4:
                    return tbHotKey4.Tag.ToString();
                case 0x80F5:
                    return tbHotKey5.Tag.ToString();
                case 0x80F6:
                    return tbHotKey6.Tag.ToString();
            }
            return string.Empty;
        }

        bool Str2HotKey(string hotKey, out Win32API.KeyModifiers hotKeyModify, out Keys HotKey)
        {
            hotKeyModify = Win32API.KeyModifiers.None;
            HotKey = Keys.F4;

            if (hotKey != null)
            {
                if (hotKey.Contains("Ctrl"))
                    hotKeyModify = hotKeyModify | Win32API.KeyModifiers.Ctrl;
                if (hotKey.Contains("Alt"))
                    hotKeyModify = hotKeyModify | Win32API.KeyModifiers.Alt;
                if (hotKey.Contains("Shift"))
                    hotKeyModify = hotKeyModify | Win32API.KeyModifiers.Shift;
                if (hotKey.Contains("Win"))
                    hotKeyModify = hotKeyModify | Win32API.KeyModifiers.WindowsKey;

                try
                {
                    HotKey = (Keys) Enum.Parse(typeof(Keys), hotKey.Replace("Ctrl + ", "").Replace("Alt + ", "").Replace("Shift + ", "").Replace("Win + ", "").Trim());
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Win32API.HideCaret((sender as Control).Handle);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys k = e.KeyData;
            if (k == Keys.Back || k == Keys.Delete)
            {
                (sender as TextBox).Text = "";
                return;
            }
            string key = string.Empty;
            
            if (e.Control)
            {
                key = key + "Ctrl + ";
                k = k & ~Keys.Control;
            }
            if (e.Alt)
            {
                key = key + "Alt + ";
                k = k & ~Keys.Alt;
            }
            if (e.Shift)
            {
                key = key + "Shift + ";
                k = k & ~Keys.Shift;
            }

            if (k != Keys.None && k != Keys.ControlKey && k != Keys.ShiftKey)
                key = key + k.ToString();
            e.Handled = true;

            (sender as TextBox).Text = key;
        }
        private void tbWavPath1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete || e.KeyData == Keys.Back)
            {
                (sender as TextBox).Text = "";
            }
            e.Handled = true;
        }
        private bool InitConfig()
        {
            if (File.Exists(Application.StartupPath + "/config.ini"))
            {
                IniFile ini = new IniFile(Application.StartupPath + "/config.ini");
                tbHotKey1.Tag = tbHotKey1.Text = ini.IniReadValue("热键一", "HotKey1");
                tbWavPath1.Tag = tbWavPath1.Text = ini.IniReadValue("热键一", "WavPath1");

                tbHotKey2.Tag = tbHotKey2.Text = ini.IniReadValue("热键二", "HotKey2");
                tbWavPath2.Tag = tbWavPath2.Text = ini.IniReadValue("热键二", "WavPath2");

                tbHotKey3.Tag = tbHotKey3.Text = ini.IniReadValue("热键三", "HotKey3");
                tbWavPath3.Tag = tbWavPath3.Text = ini.IniReadValue("热键三", "WavPath3");

                tbHotKey4.Tag = tbHotKey4.Text = ini.IniReadValue("热键四", "HotKey4");
                tbWavPath4.Tag = tbWavPath4.Text = ini.IniReadValue("热键四", "WavPath4");

                tbHotKey5.Tag = tbHotKey5.Text = ini.IniReadValue("热键五", "HotKey5");
                tbWavPath5.Tag = tbWavPath5.Text = ini.IniReadValue("热键五", "WavPath5");

                tbHotKey6.Tag = tbHotKey6.Text = ini.IniReadValue("热键六", "HotKey6");
                tbWavPath6.Tag = tbWavPath6.Text = ini.IniReadValue("热键六", "WavPath6");

                return btnReset.Enabled = true;
            }
            else
            {
                tbHotKey1.Tag= tbHotKey1.Text = "F9";
                tbWavPath1.Tag=tbWavPath1.Text = @"Sounds\成功.wav";

                tbHotKey2.Tag=tbHotKey2.Text = "F10";
                tbWavPath2.Tag=tbWavPath2.Text = @"Sounds\失败.wav";

                tbHotKey3.Tag = tbHotKey3.Text = "";
                tbWavPath3.Tag = tbWavPath3.Text = "";

                tbHotKey4.Tag = tbHotKey4.Text = "";
                tbWavPath4.Tag = tbWavPath4.Text = "";

                tbHotKey5.Tag = tbHotKey5.Text = "";
                tbWavPath5.Tag = tbWavPath5.Text = "";

                tbHotKey6.Tag = tbHotKey6.Text = "";
                tbWavPath6.Tag = tbWavPath6.Text = "";

                return btnReset.Enabled = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!InitConfig())
            {
                SaveConfig();
                background_compile();
            }
            AutoRegHotKey();
            //关联事件
            tbHotKey1.TextChanged += new EventHandler(tbConfig_TextChanged);
            tbWavPath1.TextChanged += new EventHandler(tbConfig_TextChanged);
            
            tbHotKey2.TextChanged += new EventHandler(tbConfig_TextChanged);
            tbWavPath2.TextChanged += new EventHandler(tbConfig_TextChanged);

            tbHotKey3.TextChanged += new EventHandler(tbConfig_TextChanged);
            tbWavPath3.TextChanged += new EventHandler(tbConfig_TextChanged);

            tbWavPath4.TextChanged += new EventHandler(tbConfig_TextChanged);
            tbHotKey4.TextChanged += new EventHandler(tbConfig_TextChanged);
            
            tbWavPath5.TextChanged += new EventHandler(tbConfig_TextChanged);
            tbHotKey5.TextChanged += new EventHandler(tbConfig_TextChanged);

            tbWavPath6.TextChanged += new EventHandler(tbConfig_TextChanged);
            tbHotKey6.TextChanged += new EventHandler(tbConfig_TextChanged);
        }

        private void SaveConfig()
        {
            IniFile ini = new IniFile(Application.StartupPath + "/config.ini");
            ini.IniWriteValue("热键一", "HotKey1", (tbHotKey1.Tag = tbHotKey1.Text).ToString());
            ini.IniWriteValue("热键一", "WavPath1", (tbWavPath1.Tag=tbWavPath1.Text).ToString());

            ini.IniWriteValue("热键二", "HotKey2", (tbHotKey2.Tag = tbHotKey2.Text).ToString());
            ini.IniWriteValue("热键二", "WavPath2", (tbWavPath2.Tag = tbWavPath2.Text).ToString());

            ini.IniWriteValue("热键三", "HotKey3", (tbHotKey3.Tag = tbHotKey3.Text).ToString());
            ini.IniWriteValue("热键三", "WavPath3", (tbWavPath3.Tag = tbWavPath3.Text).ToString());

            ini.IniWriteValue("热键四", "HotKey4", (tbHotKey4.Tag = tbHotKey4.Text).ToString());
            ini.IniWriteValue("热键四", "WavPath4", (tbWavPath4.Tag = tbWavPath4.Text).ToString());

            ini.IniWriteValue("热键五", "HotKey5", (tbHotKey5.Tag = tbHotKey5.Text).ToString());
            ini.IniWriteValue("热键五", "WavPath5", (tbWavPath5.Tag = tbWavPath5.Text).ToString());

            ini.IniWriteValue("热键六", "HotKey6", (tbHotKey6.Tag = tbHotKey6.Text).ToString());
            ini.IniWriteValue("热键六", "WavPath6", (tbWavPath6.Tag = tbWavPath6.Text).ToString());
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.ToString() == "UserClosing" && WindowState != FormWindowState.Minimized)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                foreach (var id in HotKeyIds)
                {
                    HotKeys.UnRegHotKey(Handle, id);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormClosing -= new FormClosingEventHandler(Form1_FormClosing);
            Program.objFileStream.Close();
            Application.Exit();
        }
        private void tbWavPath1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox tbPath = sender as TextBox;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "声音文件|*.wav";
            openFileDialog.InitialDirectory = Application.StartupPath + "\\Sounds";
            openFileDialog.RestoreDirectory = false;

            openFileDialog.FileName = File.Exists(tbPath.Text) ? (new FileInfo(tbPath.Text)).Name : "";
            openFileDialog.CheckFileExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                if (!path.StartsWith(Application.StartupPath))
                {
                    MessageBox.Show("仅限当前目录！");
                }
                else
                {
                    tbPath.Text = openFileDialog.FileName.Substring(Application.StartupPath.Length + 1);
                }
            }
        }
        private void tbConfig_TextChanged(object sender, EventArgs e)
        {
            if (!btnApply.Enabled)
            {
                btnCancel.Enabled = btnApply.Enabled = true;
            }
            else
            {
                btnCancel.Enabled = btnApply.Enabled = !((tbHotKey1.Tag == null ? string.IsNullOrEmpty(tbHotKey1.Text) : tbHotKey1.Tag.Equals(tbHotKey1.Text))
                    && (tbWavPath1.Tag == null ? string.IsNullOrEmpty(tbWavPath1.Text) : tbWavPath1.Tag.Equals(tbWavPath1.Text))
                    && (tbHotKey2.Tag == null ? string.IsNullOrEmpty(tbHotKey2.Text) : tbHotKey2.Tag.Equals(tbHotKey2.Text))
                    && (tbWavPath2.Tag == null ? string.IsNullOrEmpty(tbWavPath2.Text) : tbWavPath2.Tag.Equals(tbWavPath2.Text))
                    && (tbHotKey3.Tag == null ? string.IsNullOrEmpty(tbHotKey3.Text) : tbHotKey3.Tag.Equals(tbHotKey3.Text))
                    && (tbWavPath3.Tag == null ? string.IsNullOrEmpty(tbWavPath3.Text) : tbWavPath3.Tag.Equals(tbWavPath3.Text))
                    && (tbHotKey4.Tag == null ? string.IsNullOrEmpty(tbHotKey4.Text) : tbHotKey4.Tag.Equals(tbHotKey4.Text))
                    && (tbWavPath4.Tag == null ? string.IsNullOrEmpty(tbWavPath4.Text) : tbWavPath4.Tag.Equals(tbWavPath4.Text))
                    && (tbHotKey5.Tag == null ? string.IsNullOrEmpty(tbHotKey5.Text) : tbHotKey5.Tag.Equals(tbHotKey5.Text))
                    && (tbWavPath5.Tag == null ? string.IsNullOrEmpty(tbWavPath5.Text) : tbWavPath5.Tag.Equals(tbWavPath5.Text))
                    && (tbHotKey6.Tag == null ? string.IsNullOrEmpty(tbHotKey6.Text) : tbHotKey6.Tag.Equals(tbHotKey6.Text))
                    && (tbWavPath6.Tag == null ? string.IsNullOrEmpty(tbWavPath6.Text) : tbWavPath6.Tag.Equals(tbWavPath6.Text)));
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/config.ini"))
            {
                if (MessageBox.Show("将删除您全部的按键发声设置！", " 重置警告!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    File.Delete(Application.StartupPath + "/config.ini");
                    InitConfig();
                    SaveConfig();
                    AutoRegHotKey();
                    btnReset.Enabled = btnCancel.Enabled = btnApply.Enabled = false;
                    HotKeyGetFocus();
                }
            }
            else
            {
                btnReset.Enabled = false;
                HotKeyGetFocus();
            }
            
        }
        private void frmMain_Shown(object sender, EventArgs e)
        {
            Program.frmLoading.Close();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle|0x02000000;
                return cp;
            }
        }
        private void background_compile()
        {
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(() =>
            {
                //下载程序数据
                NgenInstaller installer = new NgenInstaller();
                installer.NgenFile(NgenInstaller.InstallTypes.Install);
            });
            t.Start();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
#if LOGS
            logs("<<Active");
#endif
            bActived = true;
        }

#if LOGS
        private void logs(object obj)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "/log.txt", true);
            sw.WriteLine(obj.ToString());
            sw.Close();
        }
#endif
        private void frmMain_Deactivate(object sender, EventArgs e)
        {
#if LOGS
            logs(">>Deactivate");
#endif
            bActived = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbHotKey1.Text = tbHotKey1.Tag.ToString();
            tbWavPath1.Text = tbWavPath1.Tag.ToString();

            tbHotKey2.Text = tbHotKey2.Tag.ToString();
            tbWavPath2.Text = tbWavPath2.Tag.ToString();

            tbHotKey3.Text = tbHotKey3.Tag.ToString();
            tbWavPath3.Text = tbWavPath3.Tag.ToString();

            tbHotKey4.Text = tbHotKey4.Tag.ToString();
            tbWavPath4.Text = tbWavPath4.Tag.ToString();

            tbHotKey5.Text = tbHotKey5.Tag.ToString();
            tbWavPath5.Text = tbWavPath5.Tag.ToString();

            tbHotKey6.Text = tbHotKey6.Tag.ToString();
            tbWavPath6.Text = tbWavPath6.Tag.ToString();

            HotKeyGetFocus();
        }
        public void HotKeyGetFocus()
        {
            if (string.IsNullOrEmpty(tbHotKey1.Text))
                tbHotKey1.Focus();
            else if (string.IsNullOrEmpty(tbHotKey2.Text))
                tbHotKey2.Focus();
            else if (string.IsNullOrEmpty(tbHotKey3.Text))
                tbHotKey3.Focus();
            else if (string.IsNullOrEmpty(tbHotKey4.Text))
                tbHotKey4.Focus();
            else if (string.IsNullOrEmpty(tbHotKey5.Text))
                tbHotKey5.Focus();
            else
                tbHotKey6.Focus();
        }


    }
}
