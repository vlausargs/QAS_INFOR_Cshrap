//PROJECT NAME: ReportExt
//CLASS NAME: SLPostedPayrollTransactionsReport.cs

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
    [IDOExtensionClass("SLPostedPayrollTransactionsReport")]
    public class SLPostedPayrollTransactionsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PostedPayrollTransactionsSp([Optional] string ExOptdfEmplType,
		[Optional] string ExBegDepart,
		[Optional] string ExEndDepart,
		[Optional] DateTime? ExBegCheckDate,
		[Optional] DateTime? ExEndCheckDate,
		[Optional] int? DateStartingOffSET,
		[Optional] int? DateEndingOffSET,
		[Optional] string ExBegEmp,
		[Optional] string ExEndEmp,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional] int? DisplayHeader,
		[Optional] string PStartEmpCate,
		[Optional] string PEndEmpCate,
		[Optional] string pSite,
		[Optional] string BGUser,
		[Optional, DefaultParameterValue(0)] int? IsSubReport)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PostedPayrollTransactionsExt = new Rpt_PostedPayrollTransactionsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PostedPayrollTransactionsExt.Rpt_PostedPayrollTransactionsSp(ExOptdfEmplType,
				ExBegDepart,
				ExEndDepart,
				ExBegCheckDate,
				ExEndCheckDate,
				DateStartingOffSET,
				DateEndingOffSET,
				ExBegEmp,
				ExEndEmp,
				PrintCost,
				DisplayHeader,
				PStartEmpCate,
				PEndEmpCate,
				pSite,
				BGUser,
				IsSubReport);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
