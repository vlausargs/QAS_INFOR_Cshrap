//PROJECT NAME: ReportExt
//CLASS NAME: SLIncidentTimeAnalysisReport.cs

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
	[IDOExtensionClass("SLIncidentTimeAnalysisReport")]
	public class SLIncidentTimeAnalysisReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_IncTimeAnalysisSp(DateTime? StartingCloseDate,
		DateTime? EndingCloseDate,
		string StartingIncident,
		string EndingIncident,
		string StartingCustomer,
		string EndingCustomer,
		string StartingOwner,
		string EndingOwner,
		string StartingReasonCode1,
		string EndingReasonCode1,
		string StartingReasonCode2,
		string EndingReasonCode2,
		string StartingUnit,
		string EndingUnit,
		string StartingItem,
		string EndingItem,
		int? PrintIncident,
		int? PrintReasRes,
		int? PrintReason,
		int? PrintRes,
		int? PrintEvents,
		int? PrintInternal,
		int? PrintExternal,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_IncTimeAnalysisExt = new SSSFSRpt_IncTimeAnalysisFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_IncTimeAnalysisExt.SSSFSRpt_IncTimeAnalysisSp(StartingCloseDate,
				EndingCloseDate,
				StartingIncident,
				EndingIncident,
				StartingCustomer,
				EndingCustomer,
				StartingOwner,
				EndingOwner,
				StartingReasonCode1,
				EndingReasonCode1,
				StartingReasonCode2,
				EndingReasonCode2,
				StartingUnit,
				EndingUnit,
				StartingItem,
				EndingItem,
				PrintIncident,
				PrintReasRes,
				PrintReason,
				PrintRes,
				PrintEvents,
				PrintInternal,
				PrintExternal,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
