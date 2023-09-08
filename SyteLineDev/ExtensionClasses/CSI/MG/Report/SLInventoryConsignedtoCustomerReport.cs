//PROJECT NAME: ReportExt
//CLASS NAME: SLInventoryConsignedtoCustomerReport.cs

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
	[IDOExtensionClass("SLInventoryConsignedtoCustomerReport")]
	public class SLInventoryConsignedtoCustomerReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InventoryConsignedtoCustomerSp([Optional] string WhseStaring,
		[Optional] string WhseEnding,
		[Optional] string CustStarting,
		[Optional] string CustEnding,
		[Optional] int? CustSeqStarting,
		[Optional] int? CustSeqEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional, DefaultParameterValue("C")] string SortBy,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_InventoryConsignedtoCustomerExt = new Rpt_InventoryConsignedtoCustomerFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_InventoryConsignedtoCustomerExt.Rpt_InventoryConsignedtoCustomerSp(WhseStaring,
				WhseEnding,
				CustStarting,
				CustEnding,
				CustSeqStarting,
				CustSeqEnding,
				ItemStarting,
				ItemEnding,
				SortBy,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
