//PROJECT NAME: ReportExt
//CLASS NAME: SLExceptionsReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLExceptionsReport")]
    public class SLExceptionsReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ExceptionsSp([Optional] string StartPlannerCode,
		                                  [Optional] string EndPlannerCode,
		                                  [Optional] string StartItem,
		                                  [Optional] string EndItem,
		                                  [Optional] byte? ExceptionOnly,
		                                  [Optional] string DetailOrSummary,
		                                  [Optional] byte? PriorityLevel,
		                                  [Optional] byte? ShowZeroOS,
		                                  [Optional] byte? DisplayHeader,
		                                  [Optional] string PMessageLanguage,
		                                  [Optional] string BGSessionId,
		                                  [Optional] string pSite,
		                                  [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ExceptionsExt = new Rpt_ExceptionsFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ExceptionsExt.Rpt_ExceptionsSp(StartPlannerCode,
				                                                 EndPlannerCode,
				                                                 StartItem,
				                                                 EndItem,
				                                                 ExceptionOnly,
				                                                 DetailOrSummary,
				                                                 PriorityLevel,
				                                                 ShowZeroOS,
				                                                 DisplayHeader,
				                                                 PMessageLanguage,
				                                                 BGSessionId,
				                                                 pSite,
				                                                 BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
