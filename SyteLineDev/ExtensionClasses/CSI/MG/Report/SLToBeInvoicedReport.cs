//PROJECT NAME: ReportExt
//CLASS NAME: SLToBeInvoicedReport.cs

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
    [IDOExtensionClass("SLToBeInvoicedReport")]
    public class SLToBeInvoicedReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ToBeInvoicedSp([Optional] string OrderStarting,
		[Optional] string OrderEnding,
		[Optional] DateTime? OrderDateStarting,
		[Optional] DateTime? OrderDateEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] string SlsmanStarting,
		[Optional] string SlsmanEnding,
		[Optional] string CustPOStarting,
		[Optional] string CustPOEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string CustItemStarting,
		[Optional] string CustItemEnding,
		[Optional] DateTime? ShipDateStarting,
		[Optional] DateTime? ShipDateEnding,
		[Optional] DateTime? DueDateStarting,
		[Optional] DateTime? DueDateEnding,
		[Optional] string InvoiceType,
		[Optional] string COStatus,
		[Optional] string COItemStatus,
		[Optional] string SortBy,
		[Optional] int? ShowDetail,
		[Optional] int? OrderDateStartingOffSET,
		[Optional] int? OrderDateEndingOffSET,
		[Optional] int? ShipDateStartingOffSET,
		[Optional] int? ShipDateEndingOffSET,
		[Optional] int? DueDateStartingOffSET,
		[Optional] int? DueDateEndingOffSET,
		[Optional] int? ShowPrice,
		[Optional] int? DisplayHeader,
		[Optional] int? IncludeInvoiceHold,
		[Optional] string pSite,
        [Optional] DateTime? InvDate,
        [Optional] Guid? ProcessId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ToBeInvoicedExt = new Rpt_ToBeInvoicedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ToBeInvoicedExt.Rpt_ToBeInvoicedSp(OrderStarting,
				OrderEnding,
				OrderDateStarting,
				OrderDateEnding,
				CustomerStarting,
				CustomerEnding,
				SlsmanStarting,
				SlsmanEnding,
				CustPOStarting,
				CustPOEnding,
				ItemStarting,
				ItemEnding,
				CustItemStarting,
				CustItemEnding,
				ShipDateStarting,
				ShipDateEnding,
				DueDateStarting,
				DueDateEnding,
				InvoiceType,
				COStatus,
				COItemStatus,
				SortBy,
				ShowDetail,
				OrderDateStartingOffSET,
				OrderDateEndingOffSET,
				ShipDateStartingOffSET,
				ShipDateEndingOffSET,
				DueDateStartingOffSET,
				DueDateEndingOffSET,
				ShowPrice,
				DisplayHeader,
				IncludeInvoiceHold,
				pSite,
                InvDate,
                ProcessId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
