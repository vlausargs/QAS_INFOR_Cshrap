//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLItems.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLItems : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLItemsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}