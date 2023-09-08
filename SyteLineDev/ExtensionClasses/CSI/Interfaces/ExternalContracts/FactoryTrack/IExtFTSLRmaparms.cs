
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLRmaparms
    {

        int SSSRMXRMAReturnPopAddSpSp(string RmaNum,
                short? RmaLine,
                string Item,
                string CoNum,
                short? CoLine,
                short? CoRelease,
                ref decimal? MatlCost,
                ref decimal? LbrCost,
                ref decimal? FovCost,
                ref decimal? VovCost,
                ref decimal? OutCost,
                ref string Infobar); 

    }
}
    
