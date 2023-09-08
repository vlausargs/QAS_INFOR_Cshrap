//PROJECT NAME: ReportExt
//CLASS NAME: SLPastDueOrderLineItemsReport.cs

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
    [IDOExtensionClass("SLPastDueOrderLineItemsReport")]
    public class SLPastDueOrderLineItemsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PastDueOrderLineItemsSp([Optional] DateTime? pAsOfDate,
		[Optional] string pCoType,
		[Optional] string pCoStat,
		[Optional] string pCoitemStat,
		[Optional] string pcredit_hold,
		[Optional] string pBegItem,
		[Optional] string pEndItem,
		[Optional] string pBegCI,
		[Optional] string pEndCI,
		[Optional] DateTime? pBegDueDate,
		[Optional] DateTime? pEndDueDate,
		[Optional] DateTime? pBegLastShipDate,
		[Optional] DateTime? pEndLastShipDate,
		[Optional] string pBegOrder,
		[Optional] string pEndOrder,
		[Optional] string pBegCustomer,
		[Optional] string pEndCustomer,
		[Optional] DateTime? pBegOrderDate,
		[Optional] DateTime? pEndOrderDate,
		[Optional] int? StartDateOffset,
		[Optional] int? EndDateOffset,
		[Optional] int? StartDateDueDateOffset,
		[Optional] int? EndDateDueDateOffset,
		[Optional] int? StartDateShipDateOffset,
		[Optional] int? EndDateShipDateOffset,
		[Optional] int? DateOffset,
		[Optional] int? pDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PastDueOrderLineItemsExt = new Rpt_PastDueOrderLineItemsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PastDueOrderLineItemsExt.Rpt_PastDueOrderLineItemsSp(pAsOfDate,
				pCoType,
				pCoStat,
				pCoitemStat,
				pcredit_hold,
				pBegItem,
				pEndItem,
				pBegCI,
				pEndCI,
				pBegDueDate,
				pEndDueDate,
				pBegLastShipDate,
				pEndLastShipDate,
				pBegOrder,
				pEndOrder,
				pBegCustomer,
				pEndCustomer,
				pBegOrderDate,
				pEndOrderDate,
				StartDateOffset,
				EndDateOffset,
				StartDateDueDateOffset,
				EndDateDueDateOffset,
				StartDateShipDateOffset,
				EndDateShipDateOffset,
				DateOffset,
				pDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
