//PROJECT NAME: ReportExt
//CLASS NAME: SLPORequisitionReport.cs

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
	[IDOExtensionClass("SLPORequisitionReport")]
	public class SLPORequisitionReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PORequisitionSp([Optional] string ReqStat,
		[Optional] string ReqitemStat,
		[Optional] string QuotedTp,
		[Optional] string SortBy,
		[Optional] string StartReqNum,
		[Optional] string EndReqNum,
		[Optional] int? StartReqLine,
		[Optional] int? EndReqLine,
		[Optional] string StartVendor,
		[Optional] string EndVendor,
		[Optional] string StartBuyer,
		[Optional] string EndBuyer,
		[Optional] string StartApprover,
		[Optional] string EndApprover,
		[Optional] string StartRequester,
		[Optional] string EndRequester,
		[Optional] string StartReqCode,
		[Optional] string EndReqCode,
		[Optional] DateTime? StartDueDate,
		[Optional] DateTime? EndDueDate,
		[Optional] DateTime? StartRelDate,
		[Optional] DateTime? EndRelDate,
		[Optional] int? StartDueDateOffset,
		[Optional] int? EndDueDateOffset,
		[Optional] int? StartRelDateOffset,
		[Optional] int? EndRelDateOffset,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional] int? DisplayHeader,
		[Optional] string PMessageLanguage,
		[Optional] int? TransDomCurr,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PORequisitionExt = new Rpt_PORequisitionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PORequisitionExt.Rpt_PORequisitionSp(ReqStat,
				ReqitemStat,
				QuotedTp,
				SortBy,
				StartReqNum,
				EndReqNum,
				StartReqLine,
				EndReqLine,
				StartVendor,
				EndVendor,
				StartBuyer,
				EndBuyer,
				StartApprover,
				EndApprover,
				StartRequester,
				EndRequester,
				StartReqCode,
				EndReqCode,
				StartDueDate,
				EndDueDate,
				StartRelDate,
				EndRelDate,
				StartDueDateOffset,
				EndDueDateOffset,
				StartRelDateOffset,
				EndRelDateOffset,
				PrintCost,
				DisplayHeader,
				PMessageLanguage,
				TransDomCurr,
				BGSessionId,
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
