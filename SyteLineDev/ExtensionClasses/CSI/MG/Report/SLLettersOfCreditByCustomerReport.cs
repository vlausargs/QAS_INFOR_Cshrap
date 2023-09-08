//PROJECT NAME: ReportExt
//CLASS NAME: SLLettersOfCreditByCustomerReport.cs

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
    [IDOExtensionClass("SLLettersOfCreditByCustomerReport")]
    public class SLLettersOfCreditByCustomerReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_LettersofCreditbyCustomerSp([Optional] string SCustNum,
		[Optional] string ECustNum,
		[Optional] string LcrStat,
		[Optional] string CurrCode,
		[Optional] int? ShowDetail,
		[Optional] string SLcrNum,
		[Optional] string ELcrNum,
		[Optional] DateTime? StIssueDate,
		[Optional] DateTime? EIssueDate,
		[Optional] DateTime? SCloseDate,
		[Optional] DateTime? ECloseDate,
		[Optional] int? SIssueDateOffSET,
		[Optional] int? EIssueDateOffSET,
		[Optional] int? SCloseDateOffSET,
		[Optional] int? ECloseDateOffSET,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_LettersofCreditbyCustomerExt = new Rpt_LettersofCreditbyCustomerFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_LettersofCreditbyCustomerExt.Rpt_LettersofCreditbyCustomerSp(SCustNum,
				ECustNum,
				LcrStat,
				CurrCode,
				ShowDetail,
				SLcrNum,
				ELcrNum,
				StIssueDate,
				EIssueDate,
				SCloseDate,
				ECloseDate,
				SIssueDateOffSET,
				EIssueDateOffSET,
				SCloseDateOffSET,
				ECloseDateOffSET,
				DisplayHeader,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
