//PROJECT NAME: ReportExt
//CLASS NAME: SLVoucherRegisterReport.cs

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
    [IDOExtensionClass("SLVoucherRegisterReport")]
    public class SLVoucherRegisterReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VoucherRegisterSp([Optional, DefaultParameterValue("P")] string Sortby,
		[Optional] int? PrintPoLineRel,
		[Optional] int? PrintGRN,
		[Optional] int? DisplayVoucherTotals,
		[Optional] int? StartingVoucher,
		[Optional] int? EndingVoucher,
		[Optional] DateTime? StartingInvoiceDate,
		[Optional] DateTime? EndingInvoiceDate,
		[Optional] string StartingVendor,
		[Optional] string EndingVendor,
		[Optional] string StartingName,
		[Optional] string EndingName,
		[Optional] string StartingPO,
		[Optional] string EndingPO,
		[Optional] string StartingGrn,
		[Optional] string EndingGrn,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] int? StartingInvDateOffSet,
		[Optional] int? EndingInvDateOffSet,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VoucherRegisterExt = new Rpt_VoucherRegisterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VoucherRegisterExt.Rpt_VoucherRegisterSp(Sortby,
				PrintPoLineRel,
				PrintGRN,
				DisplayVoucherTotals,
				StartingVoucher,
				EndingVoucher,
				StartingInvoiceDate,
				EndingInvoiceDate,
				StartingVendor,
				EndingVendor,
				StartingName,
				EndingName,
				StartingPO,
				EndingPO,
				StartingGrn,
				EndingGrn,
				DisplayHeader,
				TaskId,
				StartingInvDateOffSet,
				EndingInvDateOffSet,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
