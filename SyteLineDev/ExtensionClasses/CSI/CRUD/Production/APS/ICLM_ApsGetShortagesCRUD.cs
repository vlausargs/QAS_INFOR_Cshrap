using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CRUD.Production.APS
{
    public interface ICLM_ApsGetShortagesCRUD
    {
        (int? Severity, ICollectionLoadResponse Data) LoadShortageExtraData(string DemandType, string DemandRef, string Item, string PlannerCode, DateTime? StartDate, DateTime? DueDate, string ProductCode, string ORDER, string MATLPLAN, string MATL, string ORDPLAN, int? DemandRefNumber);


    }
}
