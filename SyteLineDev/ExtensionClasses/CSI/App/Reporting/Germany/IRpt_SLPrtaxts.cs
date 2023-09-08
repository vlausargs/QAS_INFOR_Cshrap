//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLPrtaxts.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLPrtaxts : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLPrtaxtsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}