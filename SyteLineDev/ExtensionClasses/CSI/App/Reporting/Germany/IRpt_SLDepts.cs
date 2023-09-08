//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLDepts.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLDepts : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLDeptsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}