//PROJECT NAME: ReportExt
//CLASS NAME: SLShippedNotApprovedReport.cs

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
	[IDOExtensionClass("SLShippedNotApprovedReport")]
	public class SLShippedNotApprovedReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ShippedNotApprovedSp([Optional] string OrderStarting,
		[Optional] string OrderEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] DateTime? DateShippedStarting,
		[Optional] DateTime? DateShippedEnding,
		[Optional] int? DateShippedStartingOffset,
		[Optional] int? DateShippedEndingOffset,
		[Optional, DefaultParameterValue(1)] int? DisplayReportHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ShippedNotApprovedExt = new Rpt_ShippedNotApprovedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ShippedNotApprovedExt.Rpt_ShippedNotApprovedSp(OrderStarting,
				OrderEnding,
				CustomerStarting,
				CustomerEnding,
				ItemStarting,
				ItemEnding,
				DateShippedStarting,
				DateShippedEnding,
				DateShippedStartingOffset,
				DateShippedEndingOffset,
				DisplayReportHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
