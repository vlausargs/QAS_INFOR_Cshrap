//PROJECT NAME: ReportExt
//CLASS NAME: SLPayrollDistributionLogReport.cs

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
    [IDOExtensionClass("SLPayrollDistributionLogReport")]
    public class SLPayrollDistributionLogReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PayrollDistributionLogSp([Optional] string EmployeeStarting,
		[Optional] string EmployeeEnding,
		[Optional] int? TransactionStatus,
		[Optional] string EmployeeType,
		[Optional] int? DisplayHeader,
		[Optional] string PStartEmpCate,
		[Optional] string PEndEmpCate,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PayrollDistributionLogExt = new Rpt_PayrollDistributionLogFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PayrollDistributionLogExt.Rpt_PayrollDistributionLogSp(EmployeeStarting,
				EmployeeEnding,
				TransactionStatus,
				EmployeeType,
				DisplayHeader,
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
