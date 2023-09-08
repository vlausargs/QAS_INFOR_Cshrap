//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLPoItems.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLPoItems : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLPoItemsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}