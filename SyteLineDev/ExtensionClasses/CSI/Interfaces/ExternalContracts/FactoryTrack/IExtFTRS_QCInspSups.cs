
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTRS_QCInspSups
    {

        int RSQC_CheckforTestPlanSp(int? i_rcvr,
                ref string o_output,
                ref string Infobar); 

        int RSQC_QCCheckSp(string i_PoNum,
                short? i_PoLine,
                string i_PoRelease,
                decimal? i_Qty,
                string i_Loc,
                string i_Lot,
                int? i_Seq,
                string i_Whse,
                DateTime? i_transdate,
                ref string o_Loc,
                ref int? o_IsQC,
                ref int? o_IsCertified,
                ref string Infobar); 

    }
}
    
