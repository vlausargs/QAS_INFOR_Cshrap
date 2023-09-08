//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLTaxJurs.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLTaxJurs : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLTaxJursSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}