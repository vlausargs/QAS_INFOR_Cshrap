using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
    public class DynamicMethodCallUtilFactory : IDynamicMethodCallUtilFactory
    {
        public IDynamicMethodCallUtil Create()
        {
             return new DynamicMethodCallUtil();
        }
    }
}
