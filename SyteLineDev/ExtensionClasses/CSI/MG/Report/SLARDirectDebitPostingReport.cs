//PROJECT NAME: ReportExt
//CLASS NAME: SLARDirectDebitPostingReport.cs

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
    [IDOExtensionClass("SLARDirectDebitPostingReport")]
    public class SLARDirectDebitPostingReport : ExtensionClassBase
    {
        
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ARDirectDebitPostingSp([Optional] byte? PDisplayDetail,
		                                            [Optional] string PStartingCustomer,
		                                            [Optional] string PEndingCustomer,
		                                            [Optional] string pStartingBankCode,
		                                            [Optional] string pEndingBankCode,
		                                            [Optional] DateTime? pStartingDueDate,
		                                            [Optional] DateTime? pEndingDueDate,
		                                            [Optional] int? pStartingDirectDebitNumber,
		                                            [Optional] int? pEndingDirectDebitNumber,
		                                            [Optional] byte? PDisplayHeader,
		                                            [Optional] string PSessionIDChar,
		                                            [Optional] string pSite,
		                                            [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ARDirectDebitPostingExt = new Rpt_ARDirectDebitPostingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ARDirectDebitPostingExt.Rpt_ARDirectDebitPostingSp(PDisplayDetail,
				                                                                     PStartingCustomer,
				                                                                     PEndingCustomer,
				                                                                     pStartingBankCode,
				                                                                     pEndingBankCode,
				                                                                     pStartingDueDate,
				                                                                     pEndingDueDate,
				                                                                     pStartingDirectDebitNumber,
				                                                                     pEndingDirectDebitNumber,
				                                                                     PDisplayHeader,
				                                                                     PSessionIDChar,
				                                                                     pSite,
				                                                                     BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
