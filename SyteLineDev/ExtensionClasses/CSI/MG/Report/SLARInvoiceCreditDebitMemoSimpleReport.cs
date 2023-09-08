//PROJECT NAME: ReportExt
//CLASS NAME: SLARInvoiceCreditDebitMemoSimpleReport.cs

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
    [IDOExtensionClass("SLARInvoiceCreditDebitMemoSimpleReport")]
    public class SLARInvoiceCreditDebitMemoSimpleReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ARInvoiceCreditDebitMemoSp([Optional] byte? PrePrint,
		                                                [Optional] string DocType,
		                                                [Optional] byte? PrintDocTxt,
		                                                [Optional] byte? PrintStdOrderTxt,
		                                                [Optional] byte? PrintCustMstrTxt,
		                                                [Optional] DateTime? DocDate,
		                                                [Optional] byte? TransDomCurr,
		                                                [Optional] byte? PrintEuroTotal,
		                                                [Optional] string StartCustomer,
		                                                [Optional] string EndCustomer,
		                                                [Optional] string StartInvoice,
		                                                [Optional] string EndInvoice,
		                                                [Optional] int? StartChkRef,
		                                                [Optional] int? EndChkRef,
		                                                [Optional] DateTime? StartInvDate,
		                                                [Optional] DateTime? EndInvDate,
		                                                [Optional] DateTime? StartIssueDate,
		                                                [Optional] DateTime? EndIssueDate,
		                                                [Optional] short? StartInvDateOffset,
		                                                [Optional] short? EndInvDateOffset,
		                                                [Optional] short? StartIssueDateOffset,
		                                                [Optional] short? EndIssueDateOffset,
		                                                [Optional] short? DocDateOffset,
		                                                [Optional] byte? ShowInternal,
		                                                [Optional] byte? ShowExternal,
		                                                [Optional] string BGSessionId,
		                                                [Optional, DefaultParameterValue((byte)0)] byte? PrintDiscountAmt,
		[Optional] string pVoidOrDraft,
		[Optional] byte? PrintHeaderOnAllPages,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ARInvoiceCreditDebitMemoExt = new Rpt_ARInvoiceCreditDebitMemoFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ARInvoiceCreditDebitMemoExt.Rpt_ARInvoiceCreditDebitMemoSp(PrePrint,
				                                                                             DocType,
				                                                                             PrintDocTxt,
				                                                                             PrintStdOrderTxt,
				                                                                             PrintCustMstrTxt,
				                                                                             DocDate,
				                                                                             TransDomCurr,
				                                                                             PrintEuroTotal,
				                                                                             StartCustomer,
				                                                                             EndCustomer,
				                                                                             StartInvoice,
				                                                                             EndInvoice,
				                                                                             StartChkRef,
				                                                                             EndChkRef,
				                                                                             StartInvDate,
				                                                                             EndInvDate,
				                                                                             StartIssueDate,
				                                                                             EndIssueDate,
				                                                                             StartInvDateOffset,
				                                                                             EndInvDateOffset,
				                                                                             StartIssueDateOffset,
				                                                                             EndIssueDateOffset,
				                                                                             DocDateOffset,
				                                                                             ShowInternal,
				                                                                             ShowExternal,
				                                                                             BGSessionId,
				                                                                             PrintDiscountAmt,
				                                                                             pVoidOrDraft,
				                                                                             PrintHeaderOnAllPages,
				                                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
