using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface IMGInvoker
    {
        IMGInvokeResponseData Invoke(IMGInvokeRequestData requestData);
        IMGInvokeResponseData Invoke(string idoName, string methodName, params object[] parameters);
        IMGLoadCollectionResponseData LoadCollection(string idoName, string methodName, params object[] parameters);        
        object MethodReturnValueOfInt(IMGInvokeResponseData response);
        object MethodReturnValueOfDataTable(IMGLoadCollectionResponseData response);
    }
}
