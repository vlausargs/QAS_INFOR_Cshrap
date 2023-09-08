using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IRuntimeInterceptRecord
    {
        bool Activated { get; }
        string Assembly { get; }
        string AssemblyFullName { get; }
        ERuntimeIntercept ERunTimeIntercept { get; }
        IDictionary<string, string> CustomImplementedTypes { get; }
    }
}
