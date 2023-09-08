//PROJECT NAME: MG
//CLASS NAME: ESBShipUnitViews.cs

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
    [IDOExtensionClass("ESBShipUnitViews")]
    public class ESBShipUnitViews : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ESBShipUnit(int? ShipmentID,[Optional]string ShipmentStatus)
        {
            var iCLM_ESBShipUnitExt = this.GetService<ICLM_ESBShipUnit>();

            var result = iCLM_ESBShipUnitExt.CLM_ESBShipUnitSp(ShipmentID, ShipmentStatus);

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
