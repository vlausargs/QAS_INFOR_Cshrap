
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTRS_QCCOCSelects
    {

        int RSQC_CheckCOCSp(string CoNum,
                int? CoLine,
                int? CoRelease,
                string Item,
                ref int? QCItem,
                ref int? COCItem,
                ref decimal? QtyCOC,
                ref decimal? QtyCOCPrinted,
                ref Guid? SessionID,
                ref string Infobar); 

    }
}
    
