//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLFaDisps.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLFaDisps : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLFaDispsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}