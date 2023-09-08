//PROJECT NAME: ReportExt
//CLASS NAME: SLARPaymentPostingReport.cs

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
    [IDOExtensionClass("SLARPaymentPostingReport")]
    public class SLARPaymentPostingReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ARPaymentPostingSp([Optional, DefaultParameterValue((byte)1)] byte? PDisplayDetail,
		[Optional] string PStartingCustomer,
		[Optional] string PEndingCustomer,
		string pStartingBankCode,
		string pEndingBankCode,
		DateTime? pStartingReceiptDate,
		DateTime? pEndingReceiptDate,
		int? pStartingCheckNumber,
		int? pEndingCheckNumber,
		[Optional, DefaultParameterValue((byte)1)] byte? PDisplayHeader,
		[Optional] string PSessionIDChar,
		[Optional] string PStartCreditMemo,
		[Optional] string PEndCreditMemo,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ARPaymentPostingExt = new Rpt_ARPaymentPostingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ARPaymentPostingExt.Rpt_ARPaymentPostingSp(PDisplayDetail,
				                                                             PStartingCustomer,
				                                                             PEndingCustomer,
				                                                             pStartingBankCode,
				                                                             pEndingBankCode,
				                                                             pStartingReceiptDate,
				                                                             pEndingReceiptDate,
				                                                             pStartingCheckNumber,
				                                                             pEndingCheckNumber,
				                                                             PDisplayHeader,
				                                                             PSessionIDChar,
				                                                             PStartCreditMemo,
				                                                             PEndCreditMemo,
				                                                             pSite,
				                                                             BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
