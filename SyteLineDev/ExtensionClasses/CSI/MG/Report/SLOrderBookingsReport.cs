//PROJECT NAME: ReportExt
//CLASS NAME: SLOrderBookingsReport.cs

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
    [IDOExtensionClass("SLOrderBookingsReport")]
    public class SLOrderBookingsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_OrderBookingsSp([Optional] string Sortby,
		[Optional] DateTime? ActivityDateStarting,
		[Optional] DateTime? ActivityDateEnding,
		[Optional] string ProductCodeStarting,
		[Optional] string ProductCodeEnding,
		[Optional] string SlsmanStarting,
		[Optional] string SlsmanEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string OrdernumStarting,
		[Optional] string OrdernumEnding,
		[Optional] string RmaNumStarting,
		[Optional] string RmaNumEnding,
		[Optional] int? IncludeRma,
		[Optional] int? SummaryorDetail,
		[Optional] int? ActivityDateStartingOffset,
		[Optional] int? ActivityDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_OrderBookingsExt = new Rpt_OrderBookingsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_OrderBookingsExt.Rpt_OrderBookingsSp(Sortby,
				ActivityDateStarting,
				ActivityDateEnding,
				ProductCodeStarting,
				ProductCodeEnding,
				SlsmanStarting,
				SlsmanEnding,
				ItemStarting,
				ItemEnding,
				OrdernumStarting,
				OrdernumEnding,
				RmaNumStarting,
				RmaNumEnding,
				IncludeRma,
				SummaryorDetail,
				ActivityDateStartingOffset,
				ActivityDateEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
