//PROJECT NAME: ReportExt
//CLASS NAME: SLARWirePostingReport.cs

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
    [IDOExtensionClass("SLARWirePostingReport")]
    public class SLARWirePostingReport : ExtensionClassBase
    {
      
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ARWirePostingSp([Optional] byte? PDisplayDetail,
		                                     [Optional] string PStartingCustomer,
		                                     [Optional] string PEndingCustomer,
		                                     [Optional] string pStartingBankCode,
		                                     [Optional] string pEndingBankCode,
		                                     [Optional] DateTime? pStartingReceiptDate,
		                                     [Optional] DateTime? pEndingReciptDate,
		                                     [Optional] int? pStartingWireNumber,
		                                     [Optional] int? pEndingWireNumber,
		                                     [Optional] string pStartCreditMemoNum,
		                                     [Optional] string pEndCreditMemoNum,
		                                     [Optional] byte? PDisplayHeader,
		                                     [Optional] string PSessionIDChar,
		                                     [Optional] int? TaskId,
		                                     [Optional] string pSite,
		                                     [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ARWirePostingExt = new Rpt_ARWirePostingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ARWirePostingExt.Rpt_ARWirePostingSp(PDisplayDetail,
				                                                       PStartingCustomer,
				                                                       PEndingCustomer,
				                                                       pStartingBankCode,
				                                                       pEndingBankCode,
				                                                       pStartingReceiptDate,
				                                                       pEndingReciptDate,
				                                                       pStartingWireNumber,
				                                                       pEndingWireNumber,
				                                                       pStartCreditMemoNum,
				                                                       pEndCreditMemoNum,
				                                                       PDisplayHeader,
				                                                       PSessionIDChar,
				                                                       TaskId,
				                                                       pSite,
				                                                       BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
