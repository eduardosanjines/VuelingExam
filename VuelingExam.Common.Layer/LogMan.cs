using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VuelingExam.Common.Layer.Properties;

namespace VuelingExam.Common.Layer
{
    public class LogMan
    {
        public static readonly ILog log =
      LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void logFatal(Exception ex)
        {
            var secs = 3;
            Console.WriteLine(ex);
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs
        }

        public void LogError(Exception ex)
        {
            var secs = 3;
            log.Error(ex);
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
        public void LogDebug(string s)
        {
            var secs = 3;
            log.Debug(s);
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs
        }

        public void checkHttpStatus() {
            var secs = 3;
            log.Error(RCommonLayer.OffLine);
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs
        }

    }
}
