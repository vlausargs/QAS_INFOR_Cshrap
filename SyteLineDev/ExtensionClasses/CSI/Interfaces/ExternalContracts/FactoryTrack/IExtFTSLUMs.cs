
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLUMs
    {

        int UMConvQtySp(string UM,
                string Item,
                [Optional] string VendNum,
                string Area,
                byte? ConvertToBase,
                decimal? QtyToBeConverted,
                ref decimal? OutQty,
                ref string Infobar); 

    }
}
    
