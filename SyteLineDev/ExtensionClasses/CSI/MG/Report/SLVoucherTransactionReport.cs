//PROJECT NAME: ReportExt
//CLASS NAME: SLVoucherTransactionReport.cs

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
    [IDOExtensionClass("SLVoucherTransactionReport")]
    public class SLVoucherTransactionReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VoucherTransactionSp([Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] string NameStarting,
		[Optional] string NameEnding,
		[Optional] int? PrintVoucherTotal,
		[Optional] int? VoucherStarting,
		[Optional] int? VoucherEnding,
		[Optional] DateTime? DueDateStarting,
		[Optional] DateTime? DueDateEnding,
		[Optional] DateTime? DistDateStarting,
		[Optional] DateTime? DistDateEnding,
		[Optional] int? DueDateStartingOffset,
		[Optional] int? DueDateEndingOffset,
		[Optional] int? DistDateStartingOffset,
		[Optional] int? DistDateEndingOffset,
		[Optional] string SortBy,
		[Optional] string AuthStatus,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VoucherTransactionExt = new Rpt_VoucherTransactionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VoucherTransactionExt.Rpt_VoucherTransactionSp(VendorStarting,
				VendorEnding,
				NameStarting,
				NameEnding,
				PrintVoucherTotal,
				VoucherStarting,
				VoucherEnding,
				DueDateStarting,
				DueDateEnding,
				DistDateStarting,
				DistDateEnding,
				DueDateStartingOffset,
				DueDateEndingOffset,
				DistDateStartingOffset,
				DistDateEndingOffset,
				SortBy,
				AuthStatus,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
