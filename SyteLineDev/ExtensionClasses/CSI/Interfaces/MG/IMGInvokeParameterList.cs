using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface IMGInvokeParameterList
    {
        IMGInvokeParameter this[int index] { get; set; }
    }
}
