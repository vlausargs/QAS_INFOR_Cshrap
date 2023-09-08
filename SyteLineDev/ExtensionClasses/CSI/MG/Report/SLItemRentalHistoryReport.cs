//PROJECT NAME: ReportExt
//CLASS NAME: SLItemRentalHistoryReport.cs

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
    [IDOExtensionClass("SLItemRentalHistoryReport")]
    public class SLItemRentalHistoryReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable sssfsrpt_itemRentalHistorySp([Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string SerNumStarting,
		[Optional] string SerNumEnding,
		[Optional] string CustNumStarting,
		[Optional] string CustNumEnding,
		[Optional] string ContractStarting,
		[Optional] string ContractEnding,
		[Optional] DateTime? InvDateStarting,
		[Optional] DateTime? InvDateEnding,
		[Optional] DateTime? StartDateStarting,
		[Optional] DateTime? StartDateEnding,
		[Optional, DefaultParameterValue(1)] int? IncOpenContract,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var isssfsrpt_itemRentalHistoryExt = new sssfsrpt_itemRentalHistoryFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = isssfsrpt_itemRentalHistoryExt.sssfsrpt_itemRentalHistorySp(ItemStarting,
				ItemEnding,
				SerNumStarting,
				SerNumEnding,
				CustNumStarting,
				CustNumEnding,
				ContractStarting,
				ContractEnding,
				InvDateStarting,
				InvDateEnding,
				StartDateStarting,
				StartDateEnding,
				IncOpenContract,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
