//PROJECT NAME: ReportExt
//CLASS NAME: SLInventoryConsignedfromVendorUsageReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLInventoryConsignedfromVendorUsageReport")]
    public class SLInventoryConsignedfromVendorUsageReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InventoryConsignedFromVendorUsageSp([Optional] string PStartWarehouse,
		                                                         [Optional] string PEndWarehouse,
		                                                         [Optional] string PStartVendorNum,
		                                                         [Optional] string PEndVendorNum,
		                                                         [Optional] string PStartItem,
		                                                         [Optional] string PEndItem,
		                                                         [Optional] DateTime? PStartTranDate,
		                                                         [Optional] DateTime? PEndTranDate,
		                                                         [Optional] short? PStartTranDateOffset,
		                                                         [Optional] short? PEndTranDateOffset,
		                                                         [Optional] byte? PDisplayHeader,
		                                                         [Optional] string pSite,
		                                                         [Optional] byte? PrintItemOverview,
		                                                         [Optional] string DocumentNumStarting,
		                                                         [Optional] string DocumentNumEnding)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InventoryConsignedFromVendorUsageExt = new Rpt_InventoryConsignedFromVendorUsageFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InventoryConsignedFromVendorUsageExt.Rpt_InventoryConsignedFromVendorUsageSp(PStartWarehouse,
				                                                                                               PEndWarehouse,
				                                                                                               PStartVendorNum,
				                                                                                               PEndVendorNum,
				                                                                                               PStartItem,
				                                                                                               PEndItem,
				                                                                                               PStartTranDate,
				                                                                                               PEndTranDate,
				                                                                                               PStartTranDateOffset,
				                                                                                               PEndTranDateOffset,
				                                                                                               PDisplayHeader,
				                                                                                               pSite,
				                                                                                               PrintItemOverview,
				                                                                                               DocumentNumStarting,
				                                                                                               DocumentNumEnding);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
