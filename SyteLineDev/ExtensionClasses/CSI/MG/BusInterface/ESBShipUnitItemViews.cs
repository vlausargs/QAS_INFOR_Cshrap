//PROJECT NAME: MG
//CLASS NAME: ESBShipUnitItemViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.BusInterface
{
    [IDOExtensionClass("ESBShipUnitItemViews")]
    public class ESBShipUnitItemViews : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ESBShipUnitItem(int? ShipmentID, int? PackageID)
        {
            var iCLM_ESBShipUnitItemExt = this.GetService<ICLM_ESBShipUnitItem>();

            var result = iCLM_ESBShipUnitItemExt.CLM_ESBShipUnitItemSp(ShipmentID, PackageID);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }
    }
}
