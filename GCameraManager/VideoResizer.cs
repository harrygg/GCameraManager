using Ozeki.Media;
using Ozeki.Media.MediaHandlers;
using Ozeki.Media.Video;

namespace GCameraManager
{
  class VideoResizer : VideoHandler
  {
    public void SetOptions(Resolution res, double frameRate, VideoType videoType = VideoType.Uncompressed)
    {
      SetSupportedFormats(new[] { new VideoFormat(videoType, frameRate, res) });
    }

    public override void OnDataReceived(object sender, VideoData data)
    {
      SendData(data);
    }
  }
}
