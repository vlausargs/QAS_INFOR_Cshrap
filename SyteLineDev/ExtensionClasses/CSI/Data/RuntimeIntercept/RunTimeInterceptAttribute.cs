using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface ,AllowMultiple = false, Inherited = true)]
    public sealed class RuntimeInterceptAttribute : Attribute
    {
        public RuntimeInterceptAttribute(ERuntimeIntercept eRunTimeIntercept)
        {
            this.ERunTimeIntercept = eRunTimeIntercept;
        }

        public ERuntimeIntercept ERunTimeIntercept { get; private set; }
    }
}
