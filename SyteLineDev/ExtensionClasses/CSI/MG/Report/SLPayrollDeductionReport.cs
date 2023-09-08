//PROJECT NAME: ReportExt
//CLASS NAME: SLPayrollDeductionReport.cs

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
	[IDOExtensionClass("SLPayrollDeductionReport")]
	public class SLPayrollDeductionReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PayrollDeductionSp([Optional] DateTime? CheckDate,
		[Optional] string EmpStarting,
		[Optional] string EmpEnding,
		[Optional] int? PrintAllTrx,
		[Optional] string EmpType,
		[Optional] int? CheckDateOffset,
		[Optional] int? DisplayHeader,
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
				
				var iRpt_PayrollDeductionExt = new Rpt_PayrollDeductionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PayrollDeductionExt.Rpt_PayrollDeductionSp(CheckDate,
				EmpStarting,
				EmpEnding,
				PrintAllTrx,
				EmpType,
				CheckDateOffset,
				DisplayHeader,
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
