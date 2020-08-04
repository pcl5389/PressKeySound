namespace Beat
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnApply = new System.Windows.Forms.Button();
            this.tbHotKey1 = new System.Windows.Forms.TextBox();
            this.tbWavPath1 = new System.Windows.Forms.TextBox();
            this.tbWavPath2 = new System.Windows.Forms.TextBox();
            this.tbHotKey2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbWavPath4 = new System.Windows.Forms.TextBox();
            this.tbHotKey4 = new System.Windows.Forms.TextBox();
            this.tbWavPath3 = new System.Windows.Forms.TextBox();
            this.tbHotKey3 = new System.Windows.Forms.TextBox();
            this.tbWavPath6 = new System.Windows.Forms.TextBox();
            this.tbHotKey6 = new System.Windows.Forms.TextBox();
            this.tbWavPath5 = new System.Windows.Forms.TextBox();
            this.tbHotKey5 = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.AutoSize = true;
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(400, 220);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 30);
            this.btnApply.TabIndex = 13;
            this.btnApply.Text = "确定";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbHotKey1
            // 
            this.tbHotKey1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbHotKey1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHotKey1.Location = new System.Drawing.Point(10, 38);
            this.tbHotKey1.Name = "tbHotKey1";
            this.tbHotKey1.Size = new System.Drawing.Size(130, 26);
            this.tbHotKey1.TabIndex = 1;
            this.tbHotKey1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHotKey1.WordWrap = false;
            this.tbHotKey1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.tbHotKey1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.tbHotKey1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            // 
            // tbWavPath1
            // 
            this.tbWavPath1.BackColor = System.Drawing.SystemColors.Info;
            this.tbWavPath1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWavPath1.Location = new System.Drawing.Point(146, 38);
            this.tbWavPath1.Name = "tbWavPath1";
            this.tbWavPath1.Size = new System.Drawing.Size(330, 26);
            this.tbWavPath1.TabIndex = 2;
            this.tbWavPath1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWavPath1_KeyDown);
            this.tbWavPath1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.tbWavPath1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbWavPath1_MouseDoubleClick);
            // 
            // tbWavPath2
            // 
            this.tbWavPath2.BackColor = System.Drawing.SystemColors.Info;
            this.tbWavPath2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWavPath2.Location = new System.Drawing.Point(146, 66);
            this.tbWavPath2.Name = "tbWavPath2";
            this.tbWavPath2.Size = new System.Drawing.Size(330, 26);
            this.tbWavPath2.TabIndex = 4;
            this.tbWavPath2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWavPath1_KeyDown);
            this.tbWavPath2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.tbWavPath2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbWavPath1_MouseDoubleClick);
            // 
            // tbHotKey2
            // 
            this.tbHotKey2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbHotKey2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHotKey2.Location = new System.Drawing.Point(10, 66);
            this.tbHotKey2.Name = "tbHotKey2";
            this.tbHotKey2.Size = new System.Drawing.Size(130, 26);
            this.tbHotKey2.TabIndex = 3;
            this.tbHotKey2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHotKey2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.tbHotKey2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.tbHotKey2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "热键（系统全局）";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(146, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "播放声音文件路径（如：Sounds\\bomb.wav）双击进行选取！";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbWavPath4
            // 
            this.tbWavPath4.BackColor = System.Drawing.SystemColors.Info;
            this.tbWavPath4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWavPath4.Location = new System.Drawing.Point(146, 126);
            this.tbWavPath4.Name = "tbWavPath4";
            this.tbWavPath4.Size = new System.Drawing.Size(330, 26);
            this.tbWavPath4.TabIndex = 8;
            this.tbWavPath4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWavPath1_KeyDown);
            this.tbWavPath4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.tbWavPath4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbWavPath1_MouseDoubleClick);
            // 
            // tbHotKey4
            // 
            this.tbHotKey4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbHotKey4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHotKey4.Location = new System.Drawing.Point(10, 126);
            this.tbHotKey4.Name = "tbHotKey4";
            this.tbHotKey4.Size = new System.Drawing.Size(130, 26);
            this.tbHotKey4.TabIndex = 7;
            this.tbHotKey4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHotKey4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            this.tbHotKey4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.tbHotKey4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tbWavPath3
            // 
            this.tbWavPath3.BackColor = System.Drawing.SystemColors.Info;
            this.tbWavPath3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWavPath3.Location = new System.Drawing.Point(146, 98);
            this.tbWavPath3.Name = "tbWavPath3";
            this.tbWavPath3.Size = new System.Drawing.Size(330, 26);
            this.tbWavPath3.TabIndex = 6;
            this.tbWavPath3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWavPath1_KeyDown);
            this.tbWavPath3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.tbWavPath3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbWavPath1_MouseDoubleClick);
            // 
            // tbHotKey3
            // 
            this.tbHotKey3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbHotKey3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHotKey3.Location = new System.Drawing.Point(10, 98);
            this.tbHotKey3.Name = "tbHotKey3";
            this.tbHotKey3.Size = new System.Drawing.Size(130, 26);
            this.tbHotKey3.TabIndex = 5;
            this.tbHotKey3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHotKey3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            this.tbHotKey3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.tbHotKey3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tbWavPath6
            // 
            this.tbWavPath6.BackColor = System.Drawing.SystemColors.Info;
            this.tbWavPath6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWavPath6.Location = new System.Drawing.Point(146, 186);
            this.tbWavPath6.Name = "tbWavPath6";
            this.tbWavPath6.Size = new System.Drawing.Size(330, 26);
            this.tbWavPath6.TabIndex = 12;
            this.tbWavPath6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWavPath1_KeyDown);
            this.tbWavPath6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.tbWavPath6.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbWavPath1_MouseDoubleClick);
            // 
            // tbHotKey6
            // 
            this.tbHotKey6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbHotKey6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHotKey6.Location = new System.Drawing.Point(10, 186);
            this.tbHotKey6.Name = "tbHotKey6";
            this.tbHotKey6.Size = new System.Drawing.Size(130, 26);
            this.tbHotKey6.TabIndex = 11;
            this.tbHotKey6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHotKey6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            this.tbHotKey6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.tbHotKey6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tbWavPath5
            // 
            this.tbWavPath5.BackColor = System.Drawing.SystemColors.Info;
            this.tbWavPath5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbWavPath5.Location = new System.Drawing.Point(146, 158);
            this.tbWavPath5.Name = "tbWavPath5";
            this.tbWavPath5.Size = new System.Drawing.Size(330, 26);
            this.tbWavPath5.TabIndex = 10;
            this.tbWavPath5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWavPath1_KeyDown);
            this.tbWavPath5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.tbWavPath5.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbWavPath1_MouseDoubleClick);
            // 
            // tbHotKey5
            // 
            this.tbHotKey5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbHotKey5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHotKey5.Location = new System.Drawing.Point(10, 158);
            this.tbHotKey5.Name = "tbHotKey5";
            this.tbHotKey5.Size = new System.Drawing.Size(130, 26);
            this.tbHotKey5.TabIndex = 9;
            this.tbHotKey5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHotKey5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            this.tbHotKey5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.tbHotKey5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.Location = new System.Drawing.Point(10, 225);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 25);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = true;
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(80, 225);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(60, 25);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(334, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 25);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "撤销";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 257);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tbWavPath6);
            this.Controls.Add(this.tbHotKey6);
            this.Controls.Add(this.tbWavPath5);
            this.Controls.Add(this.tbHotKey5);
            this.Controls.Add(this.tbWavPath4);
            this.Controls.Add(this.tbHotKey4);
            this.Controls.Add(this.tbWavPath3);
            this.Controls.Add(this.tbHotKey3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbWavPath2);
            this.Controls.Add(this.tbHotKey2);
            this.Controls.Add(this.tbWavPath1);
            this.Controls.Add(this.tbHotKey1);
            this.Controls.Add(this.btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "按键发声";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox tbHotKey1;
        private System.Windows.Forms.TextBox tbWavPath1;
        private System.Windows.Forms.TextBox tbWavPath2;
        private System.Windows.Forms.TextBox tbHotKey2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbWavPath4;
        private System.Windows.Forms.TextBox tbHotKey4;
        private System.Windows.Forms.TextBox tbWavPath3;
        private System.Windows.Forms.TextBox tbHotKey3;
        private System.Windows.Forms.TextBox tbWavPath6;
        private System.Windows.Forms.TextBox tbHotKey6;
        private System.Windows.Forms.TextBox tbWavPath5;
        private System.Windows.Forms.TextBox tbHotKey5;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
    }
}

