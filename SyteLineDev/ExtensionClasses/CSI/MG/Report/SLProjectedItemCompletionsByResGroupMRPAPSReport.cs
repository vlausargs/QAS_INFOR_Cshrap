//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectedItemCompletionsByResGroupMRPAPSReport.cs

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
	[IDOExtensionClass("SLProjectedItemCompletionsByResGroupMRPAPSReport")]
	public class SLProjectedItemCompletionsByResGroupMRPAPSReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectedItemCompletionsbyResGroupMRPAPSSp([Optional] string StartingResource,
		[Optional] string EndingResource,
		[Optional] string StartingResourceGroup,
		[Optional] string EndingResourceGroup,
		[Optional] DateTime? StartingDate,
		[Optional] DateTime? EndingDate,
		[Optional] int? StartingDateOffset,
		[Optional] int? EndingDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjectedItemCompletionsbyResGroupMRPAPSExt = new Rpt_ProjectedItemCompletionsbyResGroupMRPAPSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectedItemCompletionsbyResGroupMRPAPSExt.Rpt_ProjectedItemCompletionsbyResGroupMRPAPSSp(StartingResource,
				EndingResource,
				StartingResourceGroup,
				EndingResourceGroup,
				StartingDate,
				EndingDate,
				StartingDateOffset,
				EndingDateOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
