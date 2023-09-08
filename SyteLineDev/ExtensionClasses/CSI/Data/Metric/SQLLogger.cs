using CSI.MG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.Metric
{
    public class SQLLogger : ILogger
    {
        public void Trace(string source, string message) { throw new NotImplementedException(); }
        public void Debug(string source, string message) { throw new NotImplementedException(); }
        public void Info(string source, string message) { throw new NotImplementedException(); }
        public void Warn(string source, string message) { throw new NotImplementedException(); }
        public void Error(string source, string message) { throw new NotImplementedException(); }
        public void Fatal(string source, string message) { throw new NotImplementedException(); }
        public void Performance(string source, string message) { throw new NotImplementedException(); }
        public void SQL(string source, string message) { throw new NotImplementedException(); }
    }
}
