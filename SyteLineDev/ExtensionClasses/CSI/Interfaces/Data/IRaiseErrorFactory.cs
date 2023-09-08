using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public interface IRaiseErrorFactory
    {
        IRaiseError Create(IApplicationDB appDB);
    }
}
