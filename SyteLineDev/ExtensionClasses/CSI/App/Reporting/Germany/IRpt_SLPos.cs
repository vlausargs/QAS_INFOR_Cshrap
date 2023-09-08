//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLPos.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLPos : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLPosSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}