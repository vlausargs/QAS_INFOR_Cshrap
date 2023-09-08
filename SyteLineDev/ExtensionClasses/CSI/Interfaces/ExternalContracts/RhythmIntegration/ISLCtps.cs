using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.RhythmIntegration
{
    public interface ISLCtps
    {
        int GetCTP(string sRequestXML, ref string sResponseXML, ref string Infobar); 
    }
}
