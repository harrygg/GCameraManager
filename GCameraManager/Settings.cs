using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCameraManager
{
  class Settings
  {
    static string saveToDirectory = "C:\\";
    public static string SaveToDirectory { get { return saveToDirectory; } set { saveToDirectory = value; } }

    static bool recordOnMotion = false;
    public static bool RecordOnMotion { get { return recordOnMotion; } set { recordOnMotion = value; } }

    static int minVideoLength = 15;
    public static int MinVideoLength { get { return minVideoLength; } set { minVideoLength = value; } }

    static int maxVideoLength = 15;
    public static int MaxVideoLength { get { return maxVideoLength; } set { maxVideoLength = value; } }

		static bool videoViewer1Visible = false;
		public static bool VideoViewer1Visible { get { return videoViewer1Visible; } set { videoViewer1Visible = value; } }

	}
}
