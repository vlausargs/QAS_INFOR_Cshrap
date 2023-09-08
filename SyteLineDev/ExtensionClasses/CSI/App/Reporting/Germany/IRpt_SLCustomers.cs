//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLCustomers.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLCustomers : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLCustomersSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}