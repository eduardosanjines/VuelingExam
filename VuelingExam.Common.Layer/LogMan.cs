using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VuelingExam.Common.Layer
{
    public class LogMan
    {
        public static readonly ILog Log =
      LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void logFatal(Exception ex)
        {
            var secs = 3;
            Console.WriteLine(ex);
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs
        }

        public void logError(Exception ex)
        {
            var secs = 3;
            Console.WriteLine(ex);
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs
        }
        public void LogWarn(Exception ex)
        {
            var secs = 3;
            Console.WriteLine(ex);
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs
        }
        public void LogInfo()
        {
            var secs = 3;
            Console.WriteLine("Info");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs
        }
        public void LogDebug(Exception ex)
        {
            var secs = 3;
            Console.WriteLine(ex);
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs
        }
    }
}
