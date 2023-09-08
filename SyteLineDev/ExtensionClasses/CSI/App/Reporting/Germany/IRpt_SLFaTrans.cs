//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLFaTrans.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLFaTrans : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLFaTransSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}