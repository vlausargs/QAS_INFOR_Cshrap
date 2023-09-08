//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceReasonResolutionSubReport.cs

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
	[IDOExtensionClass("SLServiceReasonResolutionSubReport")]
	public class SLServiceReasonResolutionSubReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_FSReasonResolutionSp(string Incident,
		string StartingReasonCode1,
		string EndingReasonCode1,
		string StartingReasonCode2,
		string EndingReasonCode2,
		int? PrintReason,
		int? PrintRes,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_FSReasonResolutionExt = new SSSFSRpt_FSReasonResolutionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_FSReasonResolutionExt.SSSFSRpt_FSReasonResolutionSp(Incident,
				StartingReasonCode1,
				EndingReasonCode1,
				StartingReasonCode2,
				EndingReasonCode2,
				PrintReason,
				PrintRes,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
