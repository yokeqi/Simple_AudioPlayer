namespace Simple_MusicPlayer
{
    partial class Form1
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbrVolume = new System.Windows.Forms.TrackBar();
            this.chkAudioStatus = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbrProgress = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLen = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPos = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbrVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrProgress)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPlay.Location = new System.Drawing.Point(0, 0);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 36);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = ">|";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "音频文件|*.mp3;*.avi;*.wav;*.mpeg*.wma;";
            // 
            // tbrVolume
            // 
            this.tbrVolume.AutoSize = false;
            this.tbrVolume.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbrVolume.Location = new System.Drawing.Point(284, 0);
            this.tbrVolume.Maximum = 100;
            this.tbrVolume.Name = "tbrVolume";
            this.tbrVolume.Size = new System.Drawing.Size(100, 26);
            this.tbrVolume.TabIndex = 2;
            this.tbrVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbrVolume.Scroll += new System.EventHandler(this.tbrVolume_Scroll);
            // 
            // chkAudioStatus
            // 
            this.chkAudioStatus.AutoSize = true;
            this.chkAudioStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkAudioStatus.Location = new System.Drawing.Point(236, 0);
            this.chkAudioStatus.Name = "chkAudioStatus";
            this.chkAudioStatus.Size = new System.Drawing.Size(48, 26);
            this.chkAudioStatus.TabIndex = 3;
            this.chkAudioStatus.Text = "静音";
            this.chkAudioStatus.UseVisualStyleBackColor = true;
            this.chkAudioStatus.CheckedChanged += new System.EventHandler(this.chkAudioStatus_CheckedChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(123, 38);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 28);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "歌曲名";
            // 
            // tbrProgress
            // 
            this.tbrProgress.AutoSize = false;
            this.tbrProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbrProgress.Location = new System.Drawing.Point(0, 0);
            this.tbrProgress.Maximum = 0;
            this.tbrProgress.Name = "tbrProgress";
            this.tbrProgress.Size = new System.Drawing.Size(236, 26);
            this.tbrProgress.TabIndex = 5;
            this.tbrProgress.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbrProgress.Scroll += new System.EventHandler(this.tbrProgress_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPos);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblLen);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 125);
            this.panel1.TabIndex = 6;
            // 
            // lblLen
            // 
            this.lblLen.AutoSize = true;
            this.lblLen.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLen.Location = new System.Drawing.Point(39, 48);
            this.lblLen.Name = "lblLen";
            this.lblLen.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblLen.Size = new System.Drawing.Size(59, 29);
            this.lblLen.TabIndex = 6;
            this.lblLen.Text = "00:00";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOpenFile);
            this.panel2.Controls.Add(this.btnPause);
            this.panel2.Controls.Add(this.btnPlay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 36);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbrProgress);
            this.panel3.Controls.Add(this.chkAudioStatus);
            this.panel3.Controls.Add(this.tbrVolume);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(384, 26);
            this.panel3.TabIndex = 7;
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPos.Location = new System.Drawing.Point(24, 23);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(93, 29);
            this.lblPos.TabIndex = 8;
            this.lblPos.Text = "00:00";
            // 
            // btnPause
            // 
            this.btnPause.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPause.Location = new System.Drawing.Point(75, 0);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 36);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "||";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenFile.Location = new System.Drawing.Point(309, 0);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 36);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "选择文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放示例";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbrVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrProgress)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TrackBar tbrVolume;
        private System.Windows.Forms.CheckBox chkAudioStatus;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TrackBar tbrProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnOpenFile;
    }
}

