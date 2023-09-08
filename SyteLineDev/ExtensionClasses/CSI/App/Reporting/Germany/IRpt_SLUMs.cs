//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLUMs.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLUMs : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLUMsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}