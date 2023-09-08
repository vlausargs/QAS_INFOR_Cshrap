//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLProjMatls.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLProjMatls : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLProjMatlsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}