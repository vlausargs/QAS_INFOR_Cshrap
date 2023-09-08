
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTRS_QCQuickMrrs
    {

        int RSQC_AutoCreateQCItem2Sp(string i_po,
                short? i_line,
                ref string o_messages,
                ref string Infobar); 

    }
}
    
