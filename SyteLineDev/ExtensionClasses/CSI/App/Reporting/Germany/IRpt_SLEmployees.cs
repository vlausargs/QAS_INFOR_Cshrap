//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLEmployees.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLEmployees : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLEmployeesSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}