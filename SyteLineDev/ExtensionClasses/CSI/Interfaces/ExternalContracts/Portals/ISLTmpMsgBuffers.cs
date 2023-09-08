using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLTmpMsgBuffers
    {
        int DeleteTmpMsgBufferSp(Guid? PSessionID);
    }
}
