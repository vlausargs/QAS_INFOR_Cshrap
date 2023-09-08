//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLPrdecds.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLPrdecds : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLPrdecdsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}