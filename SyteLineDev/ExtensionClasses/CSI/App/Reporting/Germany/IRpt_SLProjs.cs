//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLProjs.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLProjs : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLProjsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}