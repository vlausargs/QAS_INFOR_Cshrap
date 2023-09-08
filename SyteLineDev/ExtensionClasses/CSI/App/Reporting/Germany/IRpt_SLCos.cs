//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLCos.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLCos : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLCosSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}