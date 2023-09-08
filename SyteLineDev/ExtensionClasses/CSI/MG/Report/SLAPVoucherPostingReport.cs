//PROJECT NAME: ReportExt
//CLASS NAME: SLAPVoucherPostingReport.cs

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
    [IDOExtensionClass("SLAPVoucherPostingReport")]
    public class SLAPVoucherPostingReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_APVoucherPostingSp([Optional] string StartingVendNum,
		                                        [Optional] string EndingVendNum,
		                                        [Optional] int? VoucherStarting,
		                                        [Optional] int? VoucherEnding,
		                                        [Optional] DateTime? DueDateStarting,
		                                        [Optional] DateTime? DueDateEnding,
		                                        [Optional] DateTime? DisDateStarting,
		                                        [Optional] DateTime? DisDateEnding,
		                                        [Optional] string AuthorizationStatus,
		                                        [Optional] string SortBy,
		                                        [Optional] byte? DisplayTotals,
		                                        [Optional] byte? DisplayHeader,
		                                        [Optional] byte? SeparateDrCrAmounts,
		                                        [Optional] string SessionIDChar,
		                                        [Optional] string BGSessionId,
		                                        [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_APVoucherPostingExt = new Rpt_APVoucherPostingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_APVoucherPostingExt.Rpt_APVoucherPostingSp(StartingVendNum,
				                                                             EndingVendNum,
				                                                             VoucherStarting,
				                                                             VoucherEnding,
				                                                             DueDateStarting,
				                                                             DueDateEnding,
				                                                             DisDateStarting,
				                                                             DisDateEnding,
				                                                             AuthorizationStatus,
				                                                             SortBy,
				                                                             DisplayTotals,
				                                                             DisplayHeader,
				                                                             SeparateDrCrAmounts,
				                                                             SessionIDChar,
				                                                             BGSessionId,
				                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
