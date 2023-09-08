//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLCharts.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLCharts : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLChartsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}