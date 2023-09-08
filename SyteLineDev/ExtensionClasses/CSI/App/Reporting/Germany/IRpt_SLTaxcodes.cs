//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLTaxcodes.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLTaxcodes : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLTaxcodesSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}