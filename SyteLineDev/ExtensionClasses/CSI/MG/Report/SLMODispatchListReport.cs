//PROJECT NAME: ReportExt
//CLASS NAME: SLMODispatchListReport.cs

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
	[IDOExtensionClass("SLMODispatchListReport")]
	public class SLMODispatchListReport : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable MO_Rpt_DispatchListSp([Optional] string MoldingReportType,
		                                       [Optional] string SecondaryResourceType,
		                                       [Optional] string ResourceStarting,
		                                       [Optional] string ResourceEnding,
		                                       [Optional] string ResourceGroupStarting,
		                                       [Optional] string ResourceGroupEnding,
		                                       [Optional] DateTime? ScheduleDateStarting,
		                                       [Optional] DateTime? ScheduleDateEnding,
		                                       [Optional] short? ScheduleDateStartingOffset,
		                                       [Optional] short? ScheduleDateEndingOffset,
		                                       [Optional, DefaultParameterValue((byte)1)] byte? ShowDateTime,
		[Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iMO_Rpt_DispatchListExt = new MO_Rpt_DispatchListFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iMO_Rpt_DispatchListExt.MO_Rpt_DispatchListSp(MoldingReportType,
				                                                           SecondaryResourceType,
				                                                           ResourceStarting,
				                                                           ResourceEnding,
				                                                           ResourceGroupStarting,
				                                                           ResourceGroupEnding,
				                                                           ScheduleDateStarting,
				                                                           ScheduleDateEnding,
				                                                           ScheduleDateStartingOffset,
				                                                           ScheduleDateEndingOffset,
				                                                           ShowDateTime,
				                                                           DisplayHeader,
				                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
