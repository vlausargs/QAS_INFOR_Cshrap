
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLJobRoutes
    {

        int ValidateJobSuffixSp(string Job,
                int? Suffix,
                ref string JobSuffix,
                ref string JobStat,
                ref decimal? QtyReleasesd,
                ref string JobItem,
                ref int? CoProductMix,
                ref string ItmDescription,
                ref string Infobar); 

    }
}
    
