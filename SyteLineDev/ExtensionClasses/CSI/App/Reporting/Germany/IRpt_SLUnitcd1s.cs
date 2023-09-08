//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLUnitcd1s.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLUnitcd1s : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLUnitcd1sSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}