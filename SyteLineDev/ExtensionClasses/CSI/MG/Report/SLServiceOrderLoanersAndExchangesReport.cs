//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderLoanersAndExchangesReport.cs

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
	[IDOExtensionClass("SLServiceOrderLoanersAndExchangesReport")]
	public class SLServiceOrderLoanersAndExchangesReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROLoanersAndExchangesSp([Optional, DefaultParameterValue("LS")] string Mode,
		[Optional] string BegSroNum,
		[Optional] string EndSroNum,
		[Optional] string BegCustNum,
		[Optional] string EndCustNum,
		[Optional] int? BegSroLine,
		[Optional] int? EndSroLine,
		[Optional] int? BegSroOper,
		[Optional] int? EndSroOper,
		[Optional] string BegItem,
		[Optional] string EndItem,
		[Optional] string BegUnit,
		[Optional] string EndUnit,
		[Optional] string BegBillMgr,
		[Optional] string EndBillMgr,
		[Optional] DateTime? BegStartDate,
		[Optional] DateTime? EndStartDate,
		[Optional] DateTime? BegEndDate,
		[Optional] DateTime? EndEndDate,
		[Optional] DateTime? BegOpenDate,
		[Optional] DateTime? EndOpenDate,
		[Optional] DateTime? BegDueDate,
		[Optional] DateTime? EndDueDate,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROLoanersAndExchangesExt = new SSSFSRpt_SROLoanersAndExchangesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROLoanersAndExchangesExt.SSSFSRpt_SROLoanersAndExchangesSp(Mode,
				BegSroNum,
				EndSroNum,
				BegCustNum,
				EndCustNum,
				BegSroLine,
				EndSroLine,
				BegSroOper,
				EndSroOper,
				BegItem,
				EndItem,
				BegUnit,
				EndUnit,
				BegBillMgr,
				EndBillMgr,
				BegStartDate,
				EndStartDate,
				BegEndDate,
				EndEndDate,
				BegOpenDate,
				EndOpenDate,
				BegDueDate,
				EndDueDate,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
