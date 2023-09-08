using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans.Labor
{
    public interface DispatcherService
    {
        bool ProcessLaborUpdate(InputDataSet.MasterLine masterData, bool postOffSets, bool StopPostJobs);
        bool ProcessQtyUpdate(InputDataSet.QtyLine qtyData);
    }
}
