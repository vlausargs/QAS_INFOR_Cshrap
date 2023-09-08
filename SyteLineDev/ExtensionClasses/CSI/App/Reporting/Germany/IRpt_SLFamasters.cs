//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLFamasters.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLFamasters : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLFamastersSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}