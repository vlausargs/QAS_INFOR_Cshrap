//PROJECT NAME: ReportExt
//CLASS NAME: SLPOVoucherRegisterByAccountReport.cs

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
    [IDOExtensionClass("SLPOVoucherRegisterByAccountReport")]
    public class SLPOVoucherRegisterByAccountReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_POVoucherRegisterbyAccountSp([Optional] string StartAccount,
		[Optional] string EndAccount,
		[Optional] string StartItem,
		[Optional] string EndItem,
		[Optional] DateTime? StartInvDate,
		[Optional] DateTime? EndInvDate,
		[Optional, DefaultParameterValue(1)] int? TransDomCurr,
		[Optional] int? StartVoucher,
		[Optional] int? EndVoucher,
		[Optional] string StartVendor,
		[Optional] string EndVendor,
		[Optional] string StartPO,
		[Optional] string EndPO,
		[Optional] string StartGRN,
		[Optional] string EndGRN,
		[Optional] int? StartDateOffset,
		[Optional] int? EndDateOffset,
		[Optional] int? PDisplayHeader,
		[Optional] string PMessageLanguage,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_POVoucherRegisterbyAccountExt = new Rpt_POVoucherRegisterbyAccountFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_POVoucherRegisterbyAccountExt.Rpt_POVoucherRegisterbyAccountSp(StartAccount,
				EndAccount,
				StartItem,
				EndItem,
				StartInvDate,
				EndInvDate,
				TransDomCurr,
				StartVoucher,
				EndVoucher,
				StartVendor,
				EndVendor,
				StartPO,
				EndPO,
				StartGRN,
				EndGRN,
				StartDateOffset,
				EndDateOffset,
				PDisplayHeader,
				PMessageLanguage,
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
