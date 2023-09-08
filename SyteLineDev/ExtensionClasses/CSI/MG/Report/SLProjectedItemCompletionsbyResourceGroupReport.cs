//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectedItemCompletionsbyResourceGroupReport.cs

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
	[IDOExtensionClass("SLProjectedItemCompletionsbyResourceGroupReport")]
	public class SLProjectedItemCompletionsbyResourceGroupReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectedItemCompletionsbyResourceGroupSp([Optional] string ScheduleTypes,
		[Optional] string StartingResource,
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
				
				var iRpt_ProjectedItemCompletionsbyResourceGroupExt = new Rpt_ProjectedItemCompletionsbyResourceGroupFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectedItemCompletionsbyResourceGroupExt.Rpt_ProjectedItemCompletionsbyResourceGroupSp(ScheduleTypes,
				StartingResource,
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
