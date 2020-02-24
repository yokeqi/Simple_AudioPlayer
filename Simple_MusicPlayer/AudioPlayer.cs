using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.Media
{
    /// <summary>
    /// 音频播放器（基于MCI-API接口）
    /// 作者：未闻
    /// 时间：2020.02.13
    /// 
    /// 详细的指令介绍
    /// https://blog.csdn.net/psongchao/article/details/1487788
    /// </summary>
    public class AudioPlayer
    {
        #region API定义
        [DllImport("winmm.dll")]
        static extern int mciSendString(string m_strCmd, StringBuilder m_strReceive, int m_v1, int m_v2);

        [DllImport("Kernel32", CharSet = CharSet.Auto)]
        static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);

        private void SendCommand(string cmd)
        {
            mciSendString(cmd, null, 0, 0);
        }
        private string SendCommandForResult(string cmd)
        {
            mciSendString(cmd, _temp, _temp.Capacity, 0);
            return _temp.ToString();
        }
        #endregion

        public AudioPlayer(string alias)
        {
            AliasName = alias;
            //// 获取声道
            //var ret = SendCommandForResult($"status {AliasName} source");
            //if (!string.IsNullOrWhiteSpace(ret))
            //    _source = _sourceMap.FirstOrDefault(pair => pair.Value.Equals(ret)).Key;

            //// 音频状态，是否静音
            //ret = SendCommandForResult($"status {AliasName} audio");
            //if (!string.IsNullOrWhiteSpace(ret))
            //    _audioStatus = _audioStatusMap.FirstOrDefault(pair => pair.Value.Equals(ret)).Key;

            timer.Tick += Timer_Tick;
        }

        #region 单例
        class Nested { public static AudioPlayer Instance = new AudioPlayer("AUDIO_PLAYER_SINGLETON"); }
        public static AudioPlayer Instance => Nested.Instance;
        #endregion

        // 播放别名，每个播放源（声音）采用一个别名来识别，可以支持同时播放多个声音
        public string AliasName { get; private set; }

        private StringBuilder _temp = new StringBuilder(260);
        private Dictionary<AudioSource, string> _sourceMap = new Dictionary<AudioSource, string>
        {
            {AudioSource.H, "stereo"},
            {AudioSource.A, "average"},
            {AudioSource.L, "left"},
            {AudioSource.R, "right"}
        };
        private Dictionary<bool, string> _audioStatusMap = new Dictionary<bool, string> {
            {true, "on"},
            {false, "off"}
        };
        private Timer timer = new Timer
        {
            Interval = 1000
        };

        public event Action Progress;
        public event Action Completed;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!IsCompleted)
            {
                Progress?.Invoke();
                return;
            }

            Status = PlayerStatus.Stop;
            timer.Stop();
            Completed?.Invoke();
        }

        /// <summary>
        /// 准备
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="autoPlay">是否自动播放，默认true</param>
        public void Prepare(string fileName, bool autoPlay = true)
        {
            if (Status == PlayerStatus.Playing)
                Stop();

            if (string.IsNullOrWhiteSpace(fileName))
                return;

            GetShortPathName(fileName, _temp, _temp.Capacity);
            var mp3Path = _temp.ToString();
            SendCommand($"open \"{mp3Path}\" alias {AliasName}"); //打开
            if (autoPlay)
                Play();

            // 因为设置静音后一播放，会变成有声音，所以这里要设置一下
            AudioStatus = _audioStatus;
            Source = _source;
            Volume = _vol;
        }

        /// <summary>
        /// 播放
        /// </summary>
        public void Play()
        {
            SendCommand($"play {AliasName}");
            Status = PlayerStatus.Playing;
            timer.Start();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            SendCommand($"close {AliasName}");
            Status = PlayerStatus.Stop;
            timer.Stop();
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            SendCommand($"pause {AliasName}");
            Status = PlayerStatus.Pause;
            timer.Stop();
        }

        /// <summary>
        /// 播放状态
        /// </summary>
        public PlayerStatus Status { get; private set; } = PlayerStatus.Stop;

        private bool _audioStatus = true;
        /// <summary>
        /// 音频状态(true 开启,false 静音)
        /// </summary>
        public bool AudioStatus
        {
            get => _audioStatus;
            set
            {
                _audioStatus = value;
                SendCommand($"setaudio {AliasName} {_audioStatusMap[value]}");
            }
        }

        private AudioSource _source = AudioSource.H;
        /// <summary>
        /// 播放声道
        /// </summary>
        public AudioSource Source
        {
            get => _source;
            set
            {
                _source = value;
                SendCommand($"setaudio {AliasName} source to {_sourceMap[value]}");
            }
        }

        private int _vol = 500;
        /// <summary>
        /// 音量
        /// </summary>
        public int Volume
        {
            get => _vol;
            //{
            //    var ret = SendCommandForResult($"status {AliasName} volume");
            //    if (string.IsNullOrWhiteSpace(ret))
            //        return 500;
            //    return Convert.ToInt32(ret);
            //}
            set
            {
                if (value < 0 || value > 1000)
                    return;

                _vol = value;
                SendCommand($"setaudio {AliasName} volume to {value}");
            }
        }

        /// <summary>
        /// 获取是否正在播放
        /// </summary>
        public bool IsPlaying => Status == PlayerStatus.Playing;
        /// <summary>
        /// 获取是否已播放结束
        /// </summary>
        public bool IsCompleted => Position >= Length;

        /// <summary>
        /// 获取播放总时长
        /// </summary>
        public int Length
        {
            get
            {
                var ret = SendCommandForResult($"status {AliasName} length");
                if (string.IsNullOrWhiteSpace(ret))
                    return 0;

                return Convert.ToInt32(ret);
            }
        }
        /// <summary>
        /// 获取播放总时长（格式：00:00）
        /// </summary>
        public string LengthString
        {
            get
            {
                return Len2Time(Length);
            }
        }

        /// <summary>
        /// 获取播放进度
        /// </summary>
        public int Position
        {
            get
            {
                var ret = SendCommandForResult($"status {AliasName} position");
                if (string.IsNullOrWhiteSpace(ret))
                    return 0;

                return Convert.ToInt32(_temp.ToString());
            }
            set
            {
                if (value < 0 || value > Length)
                    return;

                SendCommand($"seek {AliasName} to {value}");
                Play();
            }
        }
        /// <summary>
        /// 获取播放进度(格式：00:00)
        /// </summary>
        public string PositionString
        {
            get
            {
                return Len2Time(Position);
            }
        }

        /// <summary>
        /// 把时长从int类型转换成格式为00:00的字符串
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        private string Len2Time(int len)
        {
            int sec = len / 1000 % 60;
            int min = len / 60000 % 60;
            return string.Format("{0:D2}:{1:D2}", min, sec);
        }
    }

    public enum PlayerStatus
    {
        /// <summary>
        /// 停止
        /// </summary>
        Stop = 0,
        /// <summary>
        /// 播放中
        /// </summary>
        Playing = 1,
        /// <summary>
        /// 暂停
        /// </summary>
        Pause = 2
    }
    public enum AudioSource
    {
        /// <summary>
        /// 立体声
        /// </summary>
        H = 0,
        /// <summary>
        /// 平均声道
        /// </summary>
        A = 1,
        /// <summary>
        /// 左声道
        /// </summary>
        L = 2,
        /// <summary>
        /// 右声道
        /// </summary>
        R = 3
    }
}
