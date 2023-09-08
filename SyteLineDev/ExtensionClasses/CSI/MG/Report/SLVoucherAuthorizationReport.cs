//PROJECT NAME: ReportExt
//CLASS NAME: SLVoucherAuthorizationReport.cs

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
    [IDOExtensionClass("SLVoucherAuthorizationReport")]
    public class SLVoucherAuthorizationReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VoucherAuthorizationSp([Optional] int? POLineRel,
		[Optional] int? PrintGoodsReceiveNote,
		[Optional] int? DisplayVoucherTotal,
		[Optional] int? TransDomCurr,
		[Optional] int? PageBetweenAuth,
		[Optional] string SortBy,
		[Optional] string StartAuthorizer,
		[Optional] string EndAuthorizer,
		[Optional] int? StartVoucher,
		[Optional] int? EndVoucher,
		[Optional] DateTime? StartInvDate,
		[Optional] DateTime? EndInvDate,
		[Optional] string StartVendor,
		[Optional] string EndVendor,
		[Optional] string StartName,
		[Optional] string EndName,
		[Optional] string StartPO,
		[Optional] string EndPO,
		[Optional] string StartGRN,
		[Optional] string EndGRN,
		[Optional] int? StartDateOffset,
		[Optional] int? EndDateOffset,
		[Optional, DefaultParameterValue(1)] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VoucherAuthorizationExt = new Rpt_VoucherAuthorizationFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VoucherAuthorizationExt.Rpt_VoucherAuthorizationSp(POLineRel,
				PrintGoodsReceiveNote,
				DisplayVoucherTotal,
				TransDomCurr,
				PageBetweenAuth,
				SortBy,
				StartAuthorizer,
				EndAuthorizer,
				StartVoucher,
				EndVoucher,
				StartInvDate,
				EndInvDate,
				StartVendor,
				EndVendor,
				StartName,
				EndName,
				StartPO,
				EndPO,
				StartGRN,
				EndGRN,
				StartDateOffset,
				EndDateOffset,
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
