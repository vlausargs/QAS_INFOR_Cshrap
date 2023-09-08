//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLProjTasks.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLProjTasks : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLProjTasksSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}