
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLEsigTypes
    {

        int GetDataForEsigTypeSp(string EsigType,
                ref string Description,
                ref int? Enabled); 

    }
}
    
