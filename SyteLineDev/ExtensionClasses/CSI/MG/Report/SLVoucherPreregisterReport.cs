//PROJECT NAME: ReportExt
//CLASS NAME: SLVoucherPreregisterReport.cs

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
    [IDOExtensionClass("SLVoucherPreregisterReport")]
    public class SLVoucherPreregisterReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VoucherPreregisterSp([Optional] int? PreregisterStarting,
		[Optional] int? PreregisterEnding,
		[Optional] string VendorNumStarting,
		[Optional] string VendorNumEnding,
		[Optional] string NameStarting,
		[Optional] string NameEnding,
		[Optional] DateTime? VoucherDateStarting,
		[Optional] DateTime? VoucherDateEnding,
		[Optional] string ExOptszSortPreVend,
		[Optional] string Status,
		[Optional] int? ExOptszShowDetail,
		[Optional] int? ExOptszTransDomCurr,
		[Optional] int? VoucherDateStartingOffset,
		[Optional] int? VoucherDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VoucherPreregisterExt = new Rpt_VoucherPreregisterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VoucherPreregisterExt.Rpt_VoucherPreregisterSp(PreregisterStarting,
				PreregisterEnding,
				VendorNumStarting,
				VendorNumEnding,
				NameStarting,
				NameEnding,
				VoucherDateStarting,
				VoucherDateEnding,
				ExOptszSortPreVend,
				Status,
				ExOptszShowDetail,
				ExOptszTransDomCurr,
				VoucherDateStartingOffset,
				VoucherDateEndingOffset,
				DisplayHeader,
				BGSessionId,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
