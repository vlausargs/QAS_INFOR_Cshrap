//PROJECT NAME: ReportExt
//CLASS NAME: SLVoucherRegisterbyAccountReport.cs

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
    [IDOExtensionClass("SLVoucherRegisterbyAccountReport")]
    public class SLVoucherRegisterbyAccountReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VoucherRegisterbyAccountSp([Optional] string StartingAccount,
		[Optional] string EndingAccount,
		[Optional] int? StartingVoucher,
		[Optional] int? EndingVoucher,
		[Optional] DateTime? StartingInvoiceDate,
		[Optional] DateTime? EndingInvoiceDate,
		[Optional] string StartingVendor,
		[Optional] string EndingVendor,
		[Optional] string StartingPO,
		[Optional] string EndingPO,
		[Optional] string StartingGrn,
		[Optional] string EndingGrn,
		[Optional] int? TransToDomCurr,
		[Optional] int? StartDateOffset,
		[Optional] int? EndDateOffset,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VoucherRegisterbyAccountExt = new Rpt_VoucherRegisterbyAccountFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VoucherRegisterbyAccountExt.Rpt_VoucherRegisterbyAccountSp(StartingAccount,
				EndingAccount,
				StartingVoucher,
				EndingVoucher,
				StartingInvoiceDate,
				EndingInvoiceDate,
				StartingVendor,
				EndingVendor,
				StartingPO,
				EndingPO,
				StartingGrn,
				EndingGrn,
				TransToDomCurr,
				StartDateOffset,
				EndDateOffset,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
