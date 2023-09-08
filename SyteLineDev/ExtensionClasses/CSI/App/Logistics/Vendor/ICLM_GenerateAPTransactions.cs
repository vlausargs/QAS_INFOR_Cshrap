//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GenerateAPTransactions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
    public interface ICLM_GenerateAPTransactions
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_GenerateAPTransactionsSp(
            string PVendNum,
            string PGenerateVoucher = "V",
            int? PCanEdi = 1,
            int? PShowEdi = 0,
            string CurrCode = null,
            string FilterString = null);
    }
}

