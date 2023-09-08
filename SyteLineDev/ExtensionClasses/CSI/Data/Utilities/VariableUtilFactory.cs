using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
    public class VariableUtilFactory : IVariableUtilFactory
    {
        public IVariableUtil Create()
        {
            var dataTypeUtil = new DataTypeUtil();
            return new VariableUtil(dataTypeUtil);
        }
    }
}
