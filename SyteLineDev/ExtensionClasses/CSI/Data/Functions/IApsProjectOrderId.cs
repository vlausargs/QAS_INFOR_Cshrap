//PROJECT NAME: Data
//CLASS NAME: IApsProjectOrderId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IApsProjectOrderId
    {
        string ApsProjectOrderIdFn(
            string PProjNum,
            int? PTaskNum,
            int? PSeq);

        int? ApsProjectOrderIdSp();
    }
}

