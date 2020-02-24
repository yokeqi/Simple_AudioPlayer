<h1 align="center">基于MCI的音频播放辅助类</h1>



## 介绍

一个简单易用的基于MCI的音频播放类，AudioPlayer.cs，只要一行代码即能实现音频播放，支持常见的mp3、wav格式等。



## 示例

* 直接用默认实例实现一行代码进行播放

  ```csharp
  AudioPlayer.Instance.Prepare(openFileDialog1.FileName);
  ```

* 多音频源同时播放

  ```csharp
  var player1 = new AudioPlayer("player1");
  player1.Prepare("music1.mp3");
  var player2 = new AudioPlayer("player2");
  player2.Prepare("music2.mp3");
  ```



## 属性

| 名称           | 说明                        |
| -------------- | --------------------------- |
| AliasName      | 设备别名，识别音频源        |
| AudioStatus    | 音频是否开启，false为静音   |
| Volume         | 音量                        |
| Position       | 当前播放位置                |
| PositionString | 当前位置文本，格式如 00：00 |
| LengthString   | 总时长，格式如 00：00       |

## 方法

| 名称    | 说明                       |
| ------- | -------------------------- |
| Prepare | 音频准备，默认完成自动播放 |
| Play    | 播放                       |
| Pause   | 暂停                       |
| Stop    | 停止/关闭                  |

## 事件

| 名称      | 说明                                             |
| --------- | ------------------------------------------------ |
| Progress  | 播放进度事件，间隔为1s，注意不要在这里做耗时动作 |
| Completed | 播放完成事件                                     |



## 开发环境

VS2017、.NET 4.5

