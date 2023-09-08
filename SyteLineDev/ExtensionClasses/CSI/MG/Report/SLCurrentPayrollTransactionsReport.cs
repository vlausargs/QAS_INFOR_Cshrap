//PROJECT NAME: ReportExt
//CLASS NAME: SLCurrentPayrollTransactionsReport.cs

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
	[IDOExtensionClass("SLCurrentPayrollTransactionsReport")]
	public class SLCurrentPayrollTransactionsReport : CSIExtensionClassBase
	{





		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PR02riCurPayrollTxsSp([Optional] string pSessionIDChar,
		[Optional] string pStartDept,
		[Optional] string pEndDept,
		[Optional] string pStartEmpNum,
		[Optional] string pEndEmpNum,
		[Optional] DateTime? pCheckDate,
		[Optional] string pBankCode,
		[Optional] int? pCheckNum,
		[Optional, DefaultParameterValue(0)] int? pPrintZeroChecks,
		[Optional, DefaultParameterValue(0)] int? pNewPrCheck,
		[Optional] string pEmpType,
		[Optional, DefaultParameterValue(0)] int? pPrintHeader,
		[Optional] string PStartEmpCate,
		[Optional] string PEndEmpCate,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			var iRpt_PR02riCurPayrollTxsExt = new Rpt_PR02riCurPayrollTxsFactory().Create(this, true);
			
			var result = iRpt_PR02riCurPayrollTxsExt.Rpt_PR02riCurPayrollTxsSp(pSessionIDChar,
			pStartDept,
			pEndDept,
			pStartEmpNum,
			pEndEmpNum,
			pCheckDate,
			pBankCode,
			pCheckNum,
			pPrintZeroChecks,
			pNewPrCheck,
			pEmpType,
			pPrintHeader,
			PStartEmpCate,
			PEndEmpCate,
			pSite,
			BGUser);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PR02RICurPayrollTxsSummarySp([Optional] string pSessionIDChar,
		[Optional] string pStartDept,
		[Optional] string pEndDept,
		[Optional] string pStartEmpNum,
		[Optional] string pEndEmpNum,
		[Optional] DateTime? pCheckDate,
		[Optional] string pBankCode,
		[Optional] int? pCheckNum,
		[Optional, DefaultParameterValue(0)] int? pPrintZeroChecks,
		[Optional, DefaultParameterValue(0)] int? pNewPrCheck,
		[Optional] string pEmpType,
		[Optional, DefaultParameterValue(0)] int? pPrintHeader,
		[Optional] string PStartEmpCate,
		[Optional] string PEndEmpCate,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PR02RICurPayrollTxsSummaryExt = new Rpt_PR02RICurPayrollTxsSummaryFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PR02RICurPayrollTxsSummaryExt.Rpt_PR02RICurPayrollTxsSummarySp(pSessionIDChar,
				pStartDept,
				pEndDept,
				pStartEmpNum,
				pEndEmpNum,
				pCheckDate,
				pBankCode,
				pCheckNum,
				pPrintZeroChecks,
				pNewPrCheck,
				pEmpType,
				pPrintHeader,
				PStartEmpCate,
				PEndEmpCate,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
