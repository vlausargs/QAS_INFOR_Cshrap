using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CRUD.Production.APS
{
    public interface ICLM_ApsGetSupplyUsageCRUD
    {
        (int? Severity, ICollectionLoadResponse Data) LoadTempSupplyUsage(string SupplyID, int? SupplyMatltag, Guid? SupplyRowPtr, string Item, DateTime? DueDate, string SQLStr);
        void CreateTempSupplyUsageTable();

    }
}
