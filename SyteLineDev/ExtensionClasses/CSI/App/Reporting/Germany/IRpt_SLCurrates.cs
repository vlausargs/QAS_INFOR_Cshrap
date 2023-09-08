//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLCurrates.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLCurrates : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLCurratesSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}