//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_JobMaterialVariance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_JobMaterialVariance
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Homepage_JobMaterialVarianceSp(DateTime? StartDate,
            DateTime? EndDate,
            string SiteGroup = null);
        }
}

