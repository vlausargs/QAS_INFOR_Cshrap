//PROJECT NAME: ReportExt
//CLASS NAME: SLInvoiceTransactionReport.cs

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
    [IDOExtensionClass("SLInvoiceTransactionReport")]
    public class SLInvoiceTransactionReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InvoiceTransactionSp([Optional] string pSessionIDChar,
		                                          [Optional] byte? pCallingProgram,
		                                          [Optional] string pStartingCustNum,
		                                          [Optional] string pEndingCustNum,
		                                          [Optional] string pStartingInvNumber,
		                                          [Optional] string pEndingInvNumber,
		                                          [Optional] DateTime? pStartingInvDate,
		                                          [Optional] DateTime? pEndingInvDate,
		                                          [Optional] DateTime? pStartingDueDate,
		                                          [Optional] DateTime? pEndingDueDate,
		                                          [Optional] string pInvoice,
		                                          [Optional] string pDebitMemo,
		                                          [Optional] string pCreditMemo,
		                                          [Optional] byte? pDisplayTotals,
		                                          [Optional] byte? pSortByInvoice,
		                                          [Optional] byte? pDisplayHeader,
		                                          [Optional] string pStartBuilderInvNum,
		                                          [Optional] string pEndBuilderInvNum,
		                                          [Optional] string pToSite,
		                                          [Optional] string pSite,
		                                          [Optional] byte? pSeperateDRandCRtot)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InvoiceTransactionExt = new Rpt_InvoiceTransactionFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InvoiceTransactionExt.Rpt_InvoiceTransactionSp(pSessionIDChar,
				                                                                 pCallingProgram,
				                                                                 pStartingCustNum,
				                                                                 pEndingCustNum,
				                                                                 pStartingInvNumber,
				                                                                 pEndingInvNumber,
				                                                                 pStartingInvDate,
				                                                                 pEndingInvDate,
				                                                                 pStartingDueDate,
				                                                                 pEndingDueDate,
				                                                                 pInvoice,
				                                                                 pDebitMemo,
				                                                                 pCreditMemo,
				                                                                 pDisplayTotals,
				                                                                 pSortByInvoice,
				                                                                 pDisplayHeader,
				                                                                 pStartBuilderInvNum,
				                                                                 pEndBuilderInvNum,
				                                                                 pToSite,
				                                                                 pSite,
				                                                                 pSeperateDRandCRtot);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
