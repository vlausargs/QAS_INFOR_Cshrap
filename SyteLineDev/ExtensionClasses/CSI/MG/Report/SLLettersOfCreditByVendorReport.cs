//PROJECT NAME: ReportExt
//CLASS NAME: SLLettersOfCreditByVendorReport.cs

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
    [IDOExtensionClass("SLLettersOfCreditByVendorReport")]
    public class SLLettersOfCreditByVendorReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_LettersOfCreditByVendorSp([Optional, DefaultParameterValue("POEC")] string pLcrStat,
		[Optional] string pCurrCode,
		[Optional, DefaultParameterValue(0)] int? pShowDetail,
		[Optional] string pStartVendor,
		[Optional] string pEndVendor,
		[Optional] string pStartVendLcrNum,
		[Optional] string pEndVendLcrNum,
		[Optional] DateTime? pStartIssueDate,
		[Optional] DateTime? pEndIssueDate,
		[Optional] DateTime? pStartEstCloseDate,
		[Optional] DateTime? pEndEstCloseDate,
		[Optional] int? pStartIssueDateOffset,
		[Optional] int? pEndIssueDateOffset,
		[Optional] int? pStartEstCloseDateOffset,
		[Optional] int? pEndEstCloseDateOffset,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_LettersOfCreditByVendorExt = new Rpt_LettersOfCreditByVendorFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_LettersOfCreditByVendorExt.Rpt_LettersOfCreditByVendorSp(pLcrStat,
				pCurrCode,
				pShowDetail,
				pStartVendor,
				pEndVendor,
				pStartVendLcrNum,
				pEndVendLcrNum,
				pStartIssueDate,
				pEndIssueDate,
				pStartEstCloseDate,
				pEndEstCloseDate,
				pStartIssueDateOffset,
				pEndIssueDateOffset,
				pStartEstCloseDateOffset,
				pEndEstCloseDateOffset,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
