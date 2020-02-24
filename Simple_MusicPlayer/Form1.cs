using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_MusicPlayer
{
    public partial class Form1 : Form
    {
        AudioPlayer player = AudioPlayer.Instance;
        public Form1()
        {
            InitializeComponent();
            player.Progress += Player_Progress;
            player.Completed += Player_Completed;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                player.Prepare(openFileDialog1.FileName);
                tbrProgress.Maximum = player.Length;
                lblName.Text = Path.GetFileName(openFileDialog1.FileName);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbrVolume.Value = player.Volume / 10;
        }

        private void chkAudioStatus_CheckedChanged(object sender, EventArgs e)
        {
            player.AudioStatus = !chkAudioStatus.Checked;
        }

        private void tbrProgress_Scroll(object sender, EventArgs e)
        {
            player.Position = tbrProgress.Value;
        }

        private void tbrVolume_Scroll(object sender, EventArgs e)
        {
            player.Volume = tbrVolume.Value * 10;
        }

        private void Player_Completed()
        {
            lblName.Text = "暂无曲目";
        }

        private void Player_Progress()
        {
            lblPos.Text = player.PositionString;
            lblLen.Text = player.LengthString;
            tbrProgress.Value = player.Position;
        }
    }
}
