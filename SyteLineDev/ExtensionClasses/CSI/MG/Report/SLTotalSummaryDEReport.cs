//PROJECT NAME: ReportExt
//CLASS NAME: SLTotalSummaryDEReport.cs

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
	[IDOExtensionClass("SLTotalSummaryDEReport")]
	public class SLTotalSummaryDEReport : CSIExtensionClassBase
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
		[Optional, DefaultParameterValue((byte)0)] byte? pPrintZeroChecks,
		[Optional, DefaultParameterValue((byte)0)] byte? pNewPrCheck,
		[Optional] string pEmpType,
		[Optional, DefaultParameterValue((byte)0)] byte? pPrintHeader,
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
		}
	}
}
