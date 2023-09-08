//PROJECT NAME: ReportExt
//CLASS NAME: SLGenerateOrderPickList.cs

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
    [IDOExtensionClass("SLGenerateOrderPickList")]
    public class SLGenerateOrderPickList : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_GenerateOrderPickListSp([Optional] string PSessionIdChar,
		[Optional] string PStartCoNum,
		[Optional] string PEndCoNum,
		[Optional] DateTime? PStartDueDate,
		[Optional] DateTime? PEndDueDate,
		[Optional] string PStartWhse,
		[Optional] string PEndWhse,
		[Optional] string PStartCustNum,
		[Optional] string PEndCustNum,
		[Optional] int? PStartCustSeq,
		[Optional] int? PEndCustSeq,
		[Optional] string PParmsSite,
		[Optional] DateTime? PPostDate,
		[Optional] int? PPostMatlIssues,
		[Optional] int? PBarLoc,
		[Optional] int? PShowExternal,
		[Optional] int? PShowInternal,
		[Optional] int? PDisplayHeader,
		[Optional] int? PPrintBc,
		[Optional] int? PPrint80,
		[Optional] string PDetSummBoth,
		[Optional] string PPrItemCi,
		[Optional] int? PPrSerialNumbers,
		[Optional] int? PPrPlanItemMatl,
		[Optional] int? PPrStdOrderText,
		[Optional] int? PDisplayDescription,
		[Optional] int? PListByLoc,
		[Optional] string PPickwarn,
		[Optional] int? PSuppressErrorWhenCustomerLcrNotReqd,
		[Optional] int? PSkipOrderLineCycCnt,
		[Optional] int? PProcessBatchId,
		[Optional] int? TaskId,
		[Optional] int? pPrintManufacturerItem,
		[Optional] int? DueDateStartingOffset,
		[Optional] int? DueDateEndingOffset,
		[Optional] int? PostDateOffset,
		[Optional] string pSite,
		[Optional] decimal? UserID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_GenerateOrderPickListExt = new Rpt_GenerateOrderPickListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_GenerateOrderPickListExt.Rpt_GenerateOrderPickListSp(PSessionIdChar,
				PStartCoNum,
				PEndCoNum,
				PStartDueDate,
				PEndDueDate,
				PStartWhse,
				PEndWhse,
				PStartCustNum,
				PEndCustNum,
				PStartCustSeq,
				PEndCustSeq,
				PParmsSite,
				PPostDate,
				PPostMatlIssues,
				PBarLoc,
				PShowExternal,
				PShowInternal,
				PDisplayHeader,
				PPrintBc,
				PPrint80,
				PDetSummBoth,
				PPrItemCi,
				PPrSerialNumbers,
				PPrPlanItemMatl,
				PPrStdOrderText,
				PDisplayDescription,
				PListByLoc,
				PPickwarn,
				PSuppressErrorWhenCustomerLcrNotReqd,
				PSkipOrderLineCycCnt,
				PProcessBatchId,
				TaskId,
				pPrintManufacturerItem,
				DueDateStartingOffset,
				DueDateEndingOffset,
				PostDateOffset,
				pSite,
				UserID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
