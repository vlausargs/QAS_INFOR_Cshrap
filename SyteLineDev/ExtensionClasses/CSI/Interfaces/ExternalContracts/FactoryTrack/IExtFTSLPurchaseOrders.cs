
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLPurchaseOrders
    {

        int ExpandKyByTypeSp(string DataType,
                string Key,
                [Optional, DefaultParameterValue(null)] string Site,
                ref string Result); 

    }
}
    
