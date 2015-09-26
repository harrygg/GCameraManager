using Ozeki.Media;
using Ozeki.Media.MediaHandlers;
using Ozeki.Media.Video;

namespace GCameraManager
{
  class VideoResizer : VideoHandler
  {
    public void SetOptions(int width, int height, double frameRate, VideoType videoType = VideoType.Uncompressed)
    {
      SetSupportedFormats(new[] { new VideoFormat(VideoType.Uncompressed, frameRate, new Resolution(width, height)) });
    }

    public override void OnDataReceived(object sender, VideoData data)
    {
      SendData(data);
    }
  }
}
