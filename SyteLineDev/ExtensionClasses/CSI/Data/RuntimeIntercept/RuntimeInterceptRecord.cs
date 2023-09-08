using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public class RuntimeInterceptRecord : IRuntimeInterceptRecord
    {
        public RuntimeInterceptRecord(bool Activated, string Assembly, string AssemblyFullName, ERuntimeIntercept eRunTimeIntercept, IDictionary<string, string> customImplementedTypes)
        {
            this.Activated = Activated;
            this.Assembly = Assembly;
            this.AssemblyFullName = AssemblyFullName;
            this.ERunTimeIntercept = eRunTimeIntercept;
            this.CustomImplementedTypes = customImplementedTypes;
        }

        public bool Activated { get; }

        public string Assembly { get; }

        public string AssemblyFullName { get; }

        public ERuntimeIntercept ERunTimeIntercept { get; }

        public IDictionary<string, string> CustomImplementedTypes { get; }
    }
}
