using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCameraManager
{
	class CmdArguments
	{
		static string[] args = Environment.GetCommandLineArgs();
		static bool connect = false;
		static bool connectAllCameras = false;
		static string[] connectCameraIds;

		static CmdArguments()
		{
			if (args.Length > 0)
			{
				for (int i = 0; i < args.Length; i++)
				{
					// Convert all arguments to lower case
					var Arg = args[i].ToLower();
					var NextArg = i < args.Length - 1 ? args[i + 1].ToLower() : "";

					switch (Arg)
					{
						case "-connect":
							connect = true;
							if (NextArg.Equals("all"))
								connectAllCameras = true;
							else
								connectCameraIds = NextArg.Split(',');
							break;
					}
				}
			}
		}

		public static bool IsAutoConnect(CameraConfigurationItem ci1)
		{
			var res = false;
			if (connect)
			{
				if (connectAllCameras || (System.Array.IndexOf(connectCameraIds, ci1.id) > -1))
					res = true;
			}
			return res;
		}
	}
}
