//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLEmpPrBanks.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLEmpPrBanks : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLEmpPrBanksSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}