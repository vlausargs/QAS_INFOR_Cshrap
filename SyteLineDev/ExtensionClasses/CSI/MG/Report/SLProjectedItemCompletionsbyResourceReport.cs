//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectedItemCompletionsbyResourceReport.cs

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
	[IDOExtensionClass("SLProjectedItemCompletionsbyResourceReport")]
	public class SLProjectedItemCompletionsbyResourceReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectedItemCompletionsbyResourceSp([Optional] string ScheduleTypes,
		[Optional] string ResourceStarting,
		[Optional] string ResourceEnding,
		[Optional] string ResourceGroupStarting,
		[Optional] string ResourceGroupEnding,
		[Optional] DateTime? DateStarting,
		[Optional] DateTime? DateEnding,
		[Optional] int? DateStartingOffset,
		[Optional] int? DateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjectedItemCompletionsbyResourceExt = new Rpt_ProjectedItemCompletionsbyResourceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectedItemCompletionsbyResourceExt.Rpt_ProjectedItemCompletionsbyResourceSp(ScheduleTypes,
				ResourceStarting,
				ResourceEnding,
				ResourceGroupStarting,
				ResourceGroupEnding,
				DateStarting,
				DateEnding,
				DateStartingOffset,
				DateEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
