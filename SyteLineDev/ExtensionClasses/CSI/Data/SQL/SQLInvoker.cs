using CSI.MG;
using System;

namespace CSI.Data.SQL
{
    public class SQLInvoker : IMGInvoker
    {
        public IMGInvokeResponseData Invoke(IMGInvokeRequestData requestData)
        {
            throw new NotImplementedException();
        }

        public IMGInvokeResponseData Invoke(string idoName, string methodName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IMGLoadCollectionResponseData LoadCollection(string idoName, string methodName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public object MethodReturnValueOfDataTable(IMGLoadCollectionResponseData response)
        {
            throw new NotImplementedException();
        }

        public object MethodReturnValueOfInt(IMGInvokeResponseData response)
        {
            throw new NotImplementedException();
        }
    }
}