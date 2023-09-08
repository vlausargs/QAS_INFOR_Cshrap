//PROJECT NAME: ReportExt
//CLASS NAME: SLOrderEntryExceptionReport.cs

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
    [IDOExtensionClass("SLOrderEntryExceptionReport")]
    public class SLOrderEntryExceptionReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_OrderEntryExceptionSp([Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] DateTime? OrderDateStarting,
		[Optional] DateTime? OrderDateEnding,
		[Optional] string OrderStarting,
		[Optional] string OrderEnding,
		[Optional] int? OrderLineStarting,
		[Optional] int? OrderLineEnding,
		[Optional] int? OrderReleaseStarting,
		[Optional] int? OrderReleaseEnding,
		[Optional] DateTime? ShipDateStarting,
		[Optional] DateTime? ShipDateEnding,
		[Optional] DateTime? DueDateStarting,
		[Optional] DateTime? DueDateEnding,
		[Optional] string OrderType,
		[Optional] string COStatus,
		[Optional] string COItemStatus,
		[Optional] string ExceptionType,
		[Optional] int? OrderDateStartingOffset,
		[Optional] int? OrderDateEndingOffset,
		[Optional] int? ShipDateStartingOffset,
		[Optional] int? ShipDateEndingOffset,
		[Optional] int? DueDateStartingOffset,
		[Optional] int? DueDateEndingOffset,
		[Optional] int? ShowPrice,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_OrderEntryExceptionExt = new Rpt_OrderEntryExceptionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_OrderEntryExceptionExt.Rpt_OrderEntryExceptionSp(CustomerStarting,
				CustomerEnding,
				OrderDateStarting,
				OrderDateEnding,
				OrderStarting,
				OrderEnding,
				OrderLineStarting,
				OrderLineEnding,
				OrderReleaseStarting,
				OrderReleaseEnding,
				ShipDateStarting,
				ShipDateEnding,
				DueDateStarting,
				DueDateEnding,
				OrderType,
				COStatus,
				COItemStatus,
				ExceptionType,
				OrderDateStartingOffset,
				OrderDateEndingOffset,
				ShipDateStartingOffset,
				ShipDateEndingOffset,
				DueDateStartingOffset,
				DueDateEndingOffset,
				ShowPrice,
				DisplayHeader,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
