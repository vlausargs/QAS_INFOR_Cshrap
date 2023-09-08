//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectedItemCompletionsbyResourceMRPAPSReport.cs

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
	[IDOExtensionClass("SLProjectedItemCompletionsbyResourceMRPAPSReport")]
	public class SLProjectedItemCompletionsbyResourceMRPAPSReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectedItemCompletionsbyResourceMRPAPSSp([Optional] string ResourceStarting,
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
				
				var iRpt_ProjectedItemCompletionsbyResourceMRPAPSExt = new Rpt_ProjectedItemCompletionsbyResourceMRPAPSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectedItemCompletionsbyResourceMRPAPSExt.Rpt_ProjectedItemCompletionsbyResourceMRPAPSSp(ResourceStarting,
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
