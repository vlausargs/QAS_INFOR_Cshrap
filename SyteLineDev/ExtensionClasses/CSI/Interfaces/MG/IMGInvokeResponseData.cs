using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface IMGInvokeResponseData
    {
        T GetReturnValue<T>() where T : struct;
        IMGInvokeParameterList Parameters { get; set; }
        bool IsReturnValueStdError();
    }
}
