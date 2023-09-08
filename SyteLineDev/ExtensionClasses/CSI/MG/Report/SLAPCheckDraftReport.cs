//PROJECT NAME: ReportExt
//CLASS NAME: SLAPCheckDraftReport.cs

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
    [IDOExtensionClass("SLAPCheckDraftReport")]
    public class SLAPCheckDraftReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_Ap01FRISp([Optional] string PSessionIDChar,
		                               [Optional] string PPayType,
		                               [Optional] byte? PDistDetail,
		                               [Optional] DateTime? PPayDateStarting,
		                               [Optional] DateTime? PPayDateEnding,
		                               [Optional] int? TaskId,
		                               [Optional] byte? PrintAPCheckStubs,
		                               [Optional] string PFormType,
		                               [Optional] string pSite,
		                               [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_Ap01FRIExt = new Rpt_Ap01FRIFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_Ap01FRIExt.Rpt_Ap01FRISp(PSessionIDChar,
				                                           PPayType,
				                                           PDistDetail,
				                                           PPayDateStarting,
				                                           PPayDateEnding,
				                                           TaskId,
				                                           PrintAPCheckStubs,
				                                           PFormType,
				                                           pSite,
				                                           BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
