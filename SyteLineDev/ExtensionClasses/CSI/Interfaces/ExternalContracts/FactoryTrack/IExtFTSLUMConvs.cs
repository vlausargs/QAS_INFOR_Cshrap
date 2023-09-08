
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLUMConvs
    {

        int GetumcfSp(string OtherUM,
                string Item,
                string VendNum,
                string Area,
                ref decimal? ConvFactor,
                ref string Infobar,
                [Optional] string Site); 

    }
}
    
