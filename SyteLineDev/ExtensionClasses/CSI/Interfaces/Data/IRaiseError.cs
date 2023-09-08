using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IRaiseError
    {
        int RaiseErrorSp(string Infobar,
                              int? Severity,
                              int State = 1,
                              params object[] optionalParams);
    }
}
