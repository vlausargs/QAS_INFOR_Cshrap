using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface ILogger
    {
        void Trace(string source, string message);
        void Debug(string source, string message);
        void Info(string source, string message);
        void Warn(string source, string message);
        void Error(string source, string message);
        void Fatal(string source, string message);
        void Performance(string source, string message);
        void SQL(string source, string message);
    }
}
