
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLStockActItems
    {

        int ItemMiscReceiptSetVarsSp(string SET,
                string P_Item,
                string P_Whse,
                decimal? P_Qty,
                string P_UM,
                decimal? P_MatlCost,
                decimal? P_LbrCost,
                decimal? P_FovhdCost,
                decimal? P_VovhdCost,
                decimal? P_OutCost,
                decimal? P_UnitCost,
                string P_Loc,
                string P_Lot,
                string P_Reason,
                string P_Acct,
                string P_AcctUnit1,
                string P_AcctUnit2,
                string P_AcctUnit3,
                string P_AcctUnit4,
                DateTime? P_TransDate,
                ref string Infobar,
                [Optional] string DocumentNum,
                string P_ImportDocId,
                [Optional] string ContainerNum,
                [Optional] string UMVendNum,
                [Optional] string UMArea); 

    }
}
    
