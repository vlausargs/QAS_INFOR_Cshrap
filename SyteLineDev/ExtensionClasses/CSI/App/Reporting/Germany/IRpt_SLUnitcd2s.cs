//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLUnitcd2s.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLUnitcd2s : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLUnitcd2sSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}