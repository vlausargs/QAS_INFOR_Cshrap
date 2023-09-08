
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTRS_QCTesths
    {

        int RSQC_CreateBatchTestsSp(int? i_rcvr,
                DateTime? i_trans_date,
                ref string o_message,
                ref string Infobar); 

        int RSQC_CreateEachTestsSp(int? i_rcvr,
                DateTime? i_trans_date,
                decimal? i_num_entries,
                ref string Infobar); 

        int RSQC_CreateTesthEsigSp(Guid? TesteRowpointer,
                string UserName,
                string ReasonCode,
                Guid? EsigRowpointer); 

        int RSQC_CreateUpdateTestSummarySp(int? i_rcvr,
                DateTime? i_trans_date,
                ref string Infobar); 

        int RSQC_GetTestDataSp(int? i_rcvr,
                DateTime? i_trans_date,
                ref string o_each,
                ref string o_batch,
                ref string o_summary,
                ref string o_fail,
                ref string Infobar); 

    }
}
    
