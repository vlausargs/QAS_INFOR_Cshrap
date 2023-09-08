//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLProjTrans.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLProjTrans : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLProjTransSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}