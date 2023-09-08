
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLTmpVoucherBuilders
    {

        int VoucherBuilderDeleteSp(Guid? ProcessID,
                [Optional] string Vend_Num); 

        int VoucherBuilderProcessSp(Guid? PProcessID,
                string PVendNum,
                int? PAutoVoucher,
                [Optional, DefaultParameterValue("PurchaseOrderReceiving")] string CalledFrom,
                [Optional, DefaultParameterValue(0)] ref int? PoVoucher,
                ref string PBuilderVoucherNum,
                ref string Infobar); 

    }
}
    
