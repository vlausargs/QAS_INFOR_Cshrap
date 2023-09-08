//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLUnitcd3s.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLUnitcd3s : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLUnitcd3sSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}