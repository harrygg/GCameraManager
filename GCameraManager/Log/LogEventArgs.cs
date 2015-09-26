using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCameraManager
{
  class LogEventArgs : EventArgs
  {
    public string LogMessage;

    public LogEventArgs(string log)
    {
      LogMessage = log;
    }
  }
}
