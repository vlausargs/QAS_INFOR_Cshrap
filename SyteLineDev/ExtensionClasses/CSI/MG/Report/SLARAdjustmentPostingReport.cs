//PROJECT NAME: ReportExt
//CLASS NAME: SLARAdjustmentPostingReport.cs

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
    [IDOExtensionClass("SLARAdjustmentPostingReport")]
    public class SLARAdjustmentPostingReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ARAdjustmentPostingSp([Optional] byte? PDisplayDetail,
		                                           [Optional] string PStartingCustomer,
		                                           [Optional] string PEndingCustomer,
		                                           [Optional] string PStartingBankCode,
		                                           [Optional] string PEndingBankCode,
		                                           [Optional] DateTime? PStartingReceiptDate,
		                                           [Optional] DateTime? PEndingReceiptDate,
		                                           [Optional] int? PStartingChkNumber,
		                                           [Optional] int? PEndingChkNumber,
		                                           [Optional] byte? PDisplayHeader,
		                                           [Optional] string PSessionIDChar,
		                                           [Optional] string pSite,
		                                           [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ARAdjustmentPostingExt = new Rpt_ARAdjustmentPostingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ARAdjustmentPostingExt.Rpt_ARAdjustmentPostingSp(PDisplayDetail,
				                                                                   PStartingCustomer,
				                                                                   PEndingCustomer,
				                                                                   PStartingBankCode,
				                                                                   PEndingBankCode,
				                                                                   PStartingReceiptDate,
				                                                                   PEndingReceiptDate,
				                                                                   PStartingChkNumber,
				                                                                   PEndingChkNumber,
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
