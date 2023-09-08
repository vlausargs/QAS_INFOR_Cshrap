//PROJECT NAME: ReportExt
//CLASS NAME: SLApplicantSourceAnalysisReport.cs

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
	[IDOExtensionClass("SLApplicantSourceAnalysisReport")]
	public class SLApplicantSourceAnalysisReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ApplicantSourceAnalysisSp([Optional] string PStartingApplicant,
		[Optional] string PEndingApplicant,
		[Optional] DateTime? PStartingReceivedDate,
		[Optional] DateTime? PEndingReceivedDate,
		[Optional] string PStartingPosition,
		[Optional] string PEndingPosition,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ApplicantSourceAnalysisExt = new Rpt_ApplicantSourceAnalysisFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ApplicantSourceAnalysisExt.Rpt_ApplicantSourceAnalysisSp(PStartingApplicant,
				PEndingApplicant,
				PStartingReceivedDate,
				PEndingReceivedDate,
				PStartingPosition,
				PEndingPosition,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
