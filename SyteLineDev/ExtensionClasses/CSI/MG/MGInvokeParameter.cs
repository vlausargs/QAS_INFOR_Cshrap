using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGInvokeParameter: IMGInvokeParameter
    {
        public InvokeParameter InvokeParameter { get; private set; }

        public MGInvokeParameter(InvokeParameter InvokeParameter)
        {
            this.InvokeParameter = InvokeParameter;
        }

        public string Value
        {
            get
            {
                return this.InvokeParameter.Value;
            }
            set
            {
                this.InvokeParameter.Value = value;
            }
        }

        public T GetValue<T>()
        {
            return this.InvokeParameter.GetValue<T>();
        }

        public T? GetNullableValue<T>() where T : struct
        {
            return this.InvokeParameter.GetNullableValue<T>();
        }
    }
}
