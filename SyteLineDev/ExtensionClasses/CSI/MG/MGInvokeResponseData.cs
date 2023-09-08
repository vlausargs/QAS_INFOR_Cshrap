using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGInvokeResponseData : IMGInvokeResponseData
    {
        public InvokeResponseData InvokeResponseData { get; private set; }

        public MGInvokeResponseData(InvokeResponseData invokeResponseData)
        {
            this.InvokeResponseData = invokeResponseData;
        }

        public T GetReturnValue<T>() where T : struct
        {
            return InvokeResponseData.GetReturnValue<T>();
        }

        public IMGInvokeParameterList Parameters
        {
            get
            {
                return new MGInvokeParameterList(InvokeResponseData.Parameters);
            }
            set
            {
                InvokeResponseData.Parameters = (value as MGInvokeParameterList).InvokeParameterList;
            }
        }

        public bool IsReturnValueStdError()
        {
            return InvokeResponseData.IsReturnValueStdError();
        }
    }
}
