//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLFaclasses.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLFaclasses : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLFaclassesSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}