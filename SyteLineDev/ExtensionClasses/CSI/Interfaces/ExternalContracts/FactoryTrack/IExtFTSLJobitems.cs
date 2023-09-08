
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLJobitems
    {

        int GetJobDetailSp(string InJob,
                short? InSuffix,
                ref byte? JobCoProdMix,
                ref string JobFormattedJob,
                ref string JobItem,
                ref string JobItemDesc,
                ref string JobWhse,
                ref byte? JobPreassignLots,
                ref byte? JobPreassignSerials,
                ref string Infobar); 

    }
}
    
