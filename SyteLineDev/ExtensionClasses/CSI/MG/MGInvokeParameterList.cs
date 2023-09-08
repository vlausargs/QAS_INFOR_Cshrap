using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGInvokeParameterList : IMGInvokeParameterList
    {
        public InvokeParameterList InvokeParameterList { get; private set; }

        public MGInvokeParameterList(InvokeParameterList InvokeParameterList)
        {
            this.InvokeParameterList = InvokeParameterList;
        }
        public IMGInvokeParameter this[int index]
        {
            get
            {
                return new MGInvokeParameter(InvokeParameterList[index]);
            }
            set
            {
                InvokeParameterList[index] = (value as MGInvokeParameter).InvokeParameter;
            }
        }
    }
}
