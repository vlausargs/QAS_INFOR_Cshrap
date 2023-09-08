//PROJECT NAME: ReportExt
//CLASS NAME: SLPayrollCheckRegisterPostingReport.cs

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
	[IDOExtensionClass("SLPayrollCheckRegisterPostingReport")]
	public class SLPayrollCheckRegisterPostingReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PRtrxpPostChecksSp([Optional] string pSessionIDChar,
		[Optional] string pStartDept,
		[Optional] string pEndDept,
		[Optional] string pStartEmpNum,
		[Optional] string pEndEmpNum,
		[Optional] string pBankCode,
		[Optional] string pEmpType,
		[Optional] int? pPrintHeader,
		[Optional] string BGSessionId,
		[Optional] DateTime? pCheckDate,
		[Optional] int? pCheckNum,
		[Optional, DefaultParameterValue(0)] int? pPrintZeroChecks,
		[Optional] string PStartEmpCate,
		[Optional] string PEndEmpCate,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PRtrxpPostChecksExt = new Rpt_PRtrxpPostChecksFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PRtrxpPostChecksExt.Rpt_PRtrxpPostChecksSp(pSessionIDChar,
				pStartDept,
				pEndDept,
				pStartEmpNum,
				pEndEmpNum,
				pBankCode,
				pEmpType,
				pPrintHeader,
				BGSessionId,
				pCheckDate,
				pCheckNum,
				pPrintZeroChecks,
				PStartEmpCate,
				PEndEmpCate,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
