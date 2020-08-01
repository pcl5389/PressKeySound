using Beat.lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Beat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
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
            MessageBox.Show("热键已启用！");
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
            if (!string.IsNullOrEmpty(tbWavPath1.Text) && RegHotKey(0x80F1, tbHotKey1.Text))
            {
                HotKeyIds.Add(0x80F1);
            }
            if (!string.IsNullOrEmpty(tbWavPath2.Text) && RegHotKey(0x80F2, tbHotKey2.Text))
            {
                HotKeyIds.Add(0x80F2);
            }
            if (!string.IsNullOrEmpty(tbWavPath3.Text) && RegHotKey(0x80F3, tbHotKey3.Text))
            {
                HotKeyIds.Add(0x80F3);
            }
            if (!string.IsNullOrEmpty(tbWavPath4.Text) && RegHotKey(0x80F4, tbHotKey4.Text))
            {
                HotKeyIds.Add(0x80F4);
            }
            if (!string.IsNullOrEmpty(tbWavPath5.Text) && RegHotKey(0x80F5, tbHotKey5.Text))
            {
                HotKeyIds.Add(0x80F5);
            }
            if (!string.IsNullOrEmpty(tbWavPath6.Text) && RegHotKey(0x80F6, tbHotKey6.Text))
            {
                HotKeyIds.Add(0x80F6);
            }
        }

        public bool RegHotKey(int key_id = 0x80F0, string strHotKey = "Ctrl + F1")
        {
            //热键一
            if (Str2HotKey(strHotKey, out HotKeys.KeyModifiers hotKeyModify, out Keys hotKey))
            {
                return HotKeys.RegHotKey(Handle, key_id, hotKeyModify, hotKey);
            }
            else
            {
                MessageBox.Show(string.Format("无法识别的热键！<{0}>", strHotKey));
            }
            return false;
        }
        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg.Equals(WM_HOTKEY))
            {
                switch (msg.WParam.ToInt32())
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
                }
            }
            else
                base.WndProc(ref msg);
        }

        public bool Str2HotKey(string hotKey, out HotKeys.KeyModifiers hotKeyModify, out Keys HotKey)
        {
            hotKeyModify = HotKeys.KeyModifiers.None;
            HotKey = Keys.F4;

            if (hotKey != null)
            {
                if (hotKey.Contains("Ctrl"))
                    hotKeyModify = hotKeyModify | HotKeys.KeyModifiers.Ctrl;
                if (hotKey.Contains("Alt"))
                    hotKeyModify = hotKeyModify | HotKeys.KeyModifiers.Alt;
                if (hotKey.Contains("Shift"))
                    hotKeyModify = hotKeyModify | HotKeys.KeyModifiers.Shift;
                if (hotKey.Contains("Win"))
                    hotKeyModify = hotKeyModify | HotKeys.KeyModifiers.WindowsKey;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/config.ini"))
            {
                IniFile ini = new IniFile(Application.StartupPath + "/config.ini");
                tbHotKey1.Text = ini.IniReadValue("热键一", "HotKey1");
                tbWavPath1.Text = ini.IniReadValue("热键一", "WavPath1");

                tbHotKey2.Text = ini.IniReadValue("热键二", "HotKey2");
                tbWavPath2.Text = ini.IniReadValue("热键二", "WavPath2");

                tbHotKey3.Text = ini.IniReadValue("热键三", "HotKey3");
                tbWavPath3.Text = ini.IniReadValue("热键三", "WavPath3");

                tbHotKey4.Text = ini.IniReadValue("热键四", "HotKey4");
                tbWavPath4.Text = ini.IniReadValue("热键四", "WavPath4");

                tbHotKey5.Text = ini.IniReadValue("热键五", "HotKey5");
                tbWavPath5.Text = ini.IniReadValue("热键五", "WavPath5");

                tbHotKey6.Text = ini.IniReadValue("热键六", "HotKey6");
                tbWavPath6.Text = ini.IniReadValue("热键六", "WavPath6");
            }
            else
            {
                tbHotKey1.Text = "F9";
                tbWavPath1.Text = @"Sounds\成功.wav";

                tbHotKey2.Text = "F10";
                tbWavPath2.Text = @"Sounds\失败.wav";
            }
            AutoRegHotKey();
        }

        private void SaveConfig()
        {
            IniFile ini = new IniFile(Application.StartupPath + "/config.ini");
            ini.IniWriteValue("热键一", "HotKey1", tbHotKey1.Text);
            ini.IniWriteValue("热键一", "WavPath1", tbWavPath1.Text);

            ini.IniWriteValue("热键二", "HotKey2", tbHotKey2.Text);
            ini.IniWriteValue("热键二", "WavPath2", tbWavPath2.Text);

            ini.IniWriteValue("热键三", "HotKey3", tbHotKey3.Text);
            ini.IniWriteValue("热键三", "WavPath3", tbWavPath3.Text);

            ini.IniWriteValue("热键四", "HotKey4", tbHotKey4.Text);
            ini.IniWriteValue("热键四", "WavPath4", tbWavPath4.Text);

            ini.IniWriteValue("热键五", "HotKey5", tbHotKey5.Text);
            ini.IniWriteValue("热键五", "WavPath5", tbWavPath5.Text);

            ini.IniWriteValue("热键六", "HotKey6", tbHotKey6.Text);
            ini.IniWriteValue("热键六", "WavPath6", tbWavPath6.Text);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.ToString() == "UserClosing")
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
    }
}
