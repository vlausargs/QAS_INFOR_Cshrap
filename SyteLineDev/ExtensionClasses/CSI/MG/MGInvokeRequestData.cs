using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGInvokeRequestData : IMGInvokeRequestData
    {
        public InvokeRequestData InvokeRequestData { get; private set; }

        public MGInvokeRequestData(InvokeRequestData invokeRequestData)
        {
            this.InvokeRequestData = invokeRequestData;
        }
    }
}
