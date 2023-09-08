//PROJECT NAME: Logistics
//CLASS NAME: ICLM_DunningCustAgingBasis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface ICLM_DunningCustAgingBasis
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_DunningCustAgingBasisSp(
            string CustNum = null,
            string SiteRef = null);
    }
}

