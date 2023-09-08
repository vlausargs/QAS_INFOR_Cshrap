//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLVchItemAlls.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLVchItemAlls : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLVchItemAllsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}