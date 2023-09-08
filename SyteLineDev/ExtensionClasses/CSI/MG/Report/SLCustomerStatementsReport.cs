//PROJECT NAME: ReportExt
//CLASS NAME: SLCustomerStatementsReport.cs

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
    [IDOExtensionClass("SLCustomerStatementsReport")]
    public class SLCustomerStatementsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CustomerStatementsSp([Optional] DateTime? StatementDate,
		[Optional] int? ShowActive,
		[Optional] string BeginCustNum,
		[Optional] string EndCustNum,
		[Optional] string SiteGroup,
		[Optional] string StateCycle,
		[Optional] int? PrZeroBal,
		[Optional] int? PrCreditBal,
		[Optional] int? PrAgedTot,
		[Optional] string PrOpenItem2,
		[Optional] string InvDue,
		[Optional] int? SortByInv,
		[Optional] int? HidePaid,
		[Optional] string StComm1,
		[Optional] string StComm2,
		[Optional] int? PrOpenPay,
		[Optional] int? AgeDays1,
		[Optional] int? AgeDays2,
		[Optional] int? AgeDays3,
		[Optional] int? AgeDays4,
		[Optional] int? AgeDays5,
		[Optional] string AgeDays1Desc,
		[Optional] string AgeDays2Desc,
		[Optional] string AgeDays3Desc,
		[Optional] string AgeDays4Desc,
		[Optional] string AgeDays5Desc,
		[Optional] int? PrintEuro,
		[Optional] int? StatementDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string LangCode,
		int? UseProfile,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_CustomerStatementsExt = new Rpt_CustomerStatementsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_CustomerStatementsExt.Rpt_CustomerStatementsSp(StatementDate,
				ShowActive,
				BeginCustNum,
				EndCustNum,
				SiteGroup,
				StateCycle,
				PrZeroBal,
				PrCreditBal,
				PrAgedTot,
				PrOpenItem2,
				InvDue,
				SortByInv,
				HidePaid,
				StComm1,
				StComm2,
				PrOpenPay,
				AgeDays1,
				AgeDays2,
				AgeDays3,
				AgeDays4,
				AgeDays5,
				AgeDays1Desc,
				AgeDays2Desc,
				AgeDays3Desc,
				AgeDays4Desc,
				AgeDays5Desc,
				PrintEuro,
				StatementDateOffset,
				DisplayHeader,
				LangCode,
				UseProfile,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
