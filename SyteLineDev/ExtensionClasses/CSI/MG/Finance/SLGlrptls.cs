//PROJECT NAME: FinanceExt
//CLASS NAME: SLGlrptls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
	[IDOExtensionClass("SLGlrptls")]
	public class SLGlrptls : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FinRptAcctCheckSp(string ReportId,
		int? StartSeq,
		int? EndSeq,
		string StartAcct,
		string EndAcct,
		string AccountTypes,
		[Optional] string FilterString)
		{
			var iFinRptAcctCheckExt = new FinRptAcctCheckFactory().Create(this, true);
			
			var result = iFinRptAcctCheckExt.FinRptAcctCheckSp(ReportId,
			StartSeq,
			EndSeq,
			StartAcct,
			EndAcct,
			AccountTypes,
			FilterString);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FinRptLineCopyUpdateSp(string Operation,
		                                        string FromReportId,
		                                        int? StartSeq,
		                                        int? EndSeq,
		                                        string ToSite,
		                                        string ToReportId,
		                                        int? AfterLine,
		                                        byte? AddToRatio,
		                                        byte? CompToRatio,
		                                        string PrintLine,
		                                        byte? PrintDollar,
		                                        byte? RunMode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iFinRptLineCopyUpdateExt = new FinRptLineCopyUpdateFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iFinRptLineCopyUpdateExt.FinRptLineCopyUpdateSp(Operation,
				                                                               FromReportId,
				                                                               StartSeq,
				                                                               EndSeq,
				                                                               ToSite,
				                                                               ToReportId,
				                                                               AfterLine,
				                                                               AddToRatio,
				                                                               CompToRatio,
				                                                               PrintLine,
				                                                               PrintDollar,
				                                                               RunMode);
				
				return dt;
			}
		}




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_FinStmtPreviewSp(string pSource1,
		string pRange1,
		short? pFiscalYear1,
		byte? pCurPeriod1,
		string pSource2,
		string pRange2,
		short? pFiscalYear2,
		byte? pCurPeriod2,
		DateTime? pCurPerStart1,
		DateTime? pCurPerEnd1,
		DateTime? pCurPerStart2,
		DateTime? pCurPerEnd2,
		string pReportID,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_FinStmtPreviewExt = new CLM_FinStmtPreviewFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_FinStmtPreviewExt.CLM_FinStmtPreviewSp(pSource1,
				pRange1,
				pFiscalYear1,
				pCurPeriod1,
				pSource2,
				pRange2,
				pFiscalYear2,
				pCurPeriod2,
				pCurPerStart1,
				pCurPerEnd1,
				pCurPerStart2,
				pCurPerEnd2,
				pReportID,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FinRptLineCheckSeqSp(string RptId,
		int? Seq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFinRptLineCheckSeqExt = new FinRptLineCheckSeqFactory().Create(appDb);
				
				var result = iFinRptLineCheckSeqExt.FinRptLineCheckSeqSp(RptId,
				Seq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FinRptLineDefaultSeqSp(string RptId,
		ref int? FirstSeq,
		ref int? LastSeq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFinRptLineDefaultSeqExt = new FinRptLineDefaultSeqFactory().Create(appDb);
				
				var result = iFinRptLineDefaultSeqExt.FinRptLineDefaultSeqSp(RptId,
				FirstSeq,
				LastSeq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				FirstSeq = result.FirstSeq;
				LastSeq = result.LastSeq;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FinRptLineGenSp(string ReportId,
		string CopyType,
		string StartingAcct,
		string EndingAcct,
		string AccountTypes,
		int? DelExisting,
		int? InsertAfterLine,
		ref int? EndSeq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFinRptLineGenExt = new FinRptLineGenFactory().Create(appDb);
				
				var result = iFinRptLineGenExt.FinRptLineGenSp(ReportId,
				CopyType,
				StartingAcct,
				EndingAcct,
				AccountTypes,
				DelExisting,
				InsertAfterLine,
				EndSeq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				EndSeq = result.EndSeq;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FinRptLineReSeqSp(string PRptId,
		int? PFromSeq,
		int? PToSeq,
		int? PStartSeq,
		int? PStepSize,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iFinRptLineReSeqExt = new FinRptLineReSeqFactory().Create(appDb);
				
				var result = iFinRptLineReSeqExt.FinRptLineReSeqSp(PRptId,
				PFromSeq,
				PToSeq,
				PStartSeq,
				PStepSize,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GlrptlNextSeqSp(string RptId,
		int? CurSeq,
		ref int? NextSeq,
		ref string PromptMsg,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGlrptlNextSeqExt = new GlrptlNextSeqFactory().Create(appDb);
				
				var result = iGlrptlNextSeqExt.GlrptlNextSeqSp(RptId,
				CurSeq,
				NextSeq,
				PromptMsg,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				NextSeq = result.NextSeq;
				PromptMsg = result.PromptMsg;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
