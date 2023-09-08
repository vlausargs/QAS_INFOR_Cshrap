//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLUnitcd4s.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLUnitcd4s : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLUnitcd4sSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}