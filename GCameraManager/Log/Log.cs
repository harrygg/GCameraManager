using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCameraManager
{
  class Log
  {
    static string _log;
    public static string fileName = "GCameraManager.log";

    public static void Write(string logMessage)
    {
      _log = DateTime.Now + " | " + logMessage;
      LogMessageReceived(_log);
    }

    public static event EventHandler<LogEventArgs> OnLogMessageReceived;

    static void LogMessageReceived(string msg)
    {
      var handler = OnLogMessageReceived;
      if (handler != null)
        handler(null, new LogEventArgs(msg));
    }
  }
}
