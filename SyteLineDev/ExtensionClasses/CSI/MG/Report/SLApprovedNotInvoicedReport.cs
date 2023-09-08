//PROJECT NAME: ReportExt
//CLASS NAME: SLApprovedNotInvoicedReport.cs

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
	[IDOExtensionClass("SLApprovedNotInvoicedReport")]
	public class SLApprovedNotInvoicedReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ApprovedNotInvoicedSp([Optional] string OrderStarting,
		[Optional] string OrderEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] DateTime? DateApprovedStarting,
		[Optional] DateTime? DateApprovedEnding,
		[Optional] int? DateApprovedStartingOffset,
		[Optional] int? DateApprovedEndingOffset,
		[Optional, DefaultParameterValue(1)] int? DisplayReportHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ApprovedNotInvoicedExt = new Rpt_ApprovedNotInvoicedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ApprovedNotInvoicedExt.Rpt_ApprovedNotInvoicedSp(OrderStarting,
				OrderEnding,
				CustomerStarting,
				CustomerEnding,
				ItemStarting,
				ItemEnding,
				DateApprovedStarting,
				DateApprovedEnding,
				DateApprovedStartingOffset,
				DateApprovedEndingOffset,
				DisplayReportHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
