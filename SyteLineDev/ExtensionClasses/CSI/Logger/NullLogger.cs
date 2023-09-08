using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Logger
{
    class NullLogger : CSI.MG.ILogger
    {
        public void Debug(string source, string message)
        {

        }

        public void Error(string source, string message)
        {

        }

        public void Fatal(string source, string message)
        {

        }

        public void Info(string source, string message)
        {

        }

        public void Performance(string source, string message)
        {

        }

        public void Trace(string source, string message)
        {

        }

        public void Warn(string source, string message)
        {

        }
        public void SQL(string source, string message)
        {

        }
    }
}
