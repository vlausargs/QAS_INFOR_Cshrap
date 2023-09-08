//PROJECT NAME: ReportExt
//CLASS NAME: SLPOFundsCommittedReport.cs

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
    [IDOExtensionClass("SLPOFundsCommittedReport")]
    public class SLPOFundsCommittedReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_POFundsCommittedSp([Optional] string pPoType,
		[Optional] string pPoitemStat,
		[Optional] string pPoStat,
		[Optional] int? pPrintVendItem,
		[Optional] int? pSortByCurrCode,
		[Optional] int? pTransDomCurr,
		[Optional] int? pShowDetail,
		[Optional] int? pUseHistRate,
		[Optional] string pStartPoNum,
		[Optional] string pEndPoNum,
		[Optional] int? pStartPoLine,
		[Optional] int? pEndPoLine,
		[Optional] string pStartVendor,
		[Optional] string pEndVendor,
		[Optional] DateTime? pStartOrderDate,
		[Optional] DateTime? pEndOrderDate,
		[Optional] string pStartVendOrder,
		[Optional] string pEndVendOrder,
		[Optional] string pStartItem,
		[Optional] string pEndItem,
		[Optional] string pStartVendItem,
		[Optional] string pEndVendItem,
		[Optional] DateTime? pStartDueDate,
		[Optional] DateTime? pEndDueDate,
		[Optional] DateTime? pStartRecvDate,
		[Optional] DateTime? pEndRecvDate,
		[Optional] string pStartCurrCode,
		[Optional] string pEndCurrCode,
		[Optional] int? pStartOrderDateOffset,
		[Optional] int? pEndOrderDateOffset,
		[Optional] int? pStartDueDateOffset,
		[Optional] int? pEndDueDateOffset,
		[Optional] int? pStartRecvDateOffset,
		[Optional] int? pEndRecvDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] int? pStartPoRel,
		[Optional] int? pEndPoRel,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_POFundsCommittedExt = new Rpt_POFundsCommittedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_POFundsCommittedExt.Rpt_POFundsCommittedSp(pPoType,
				pPoitemStat,
				pPoStat,
				pPrintVendItem,
				pSortByCurrCode,
				pTransDomCurr,
				pShowDetail,
				pUseHistRate,
				pStartPoNum,
				pEndPoNum,
				pStartPoLine,
				pEndPoLine,
				pStartVendor,
				pEndVendor,
				pStartOrderDate,
				pEndOrderDate,
				pStartVendOrder,
				pEndVendOrder,
				pStartItem,
				pEndItem,
				pStartVendItem,
				pEndVendItem,
				pStartDueDate,
				pEndDueDate,
				pStartRecvDate,
				pEndRecvDate,
				pStartCurrCode,
				pEndCurrCode,
				pStartOrderDateOffset,
				pEndOrderDateOffset,
				pStartDueDateOffset,
				pEndDueDateOffset,
				pStartRecvDateOffset,
				pEndRecvDateOffset,
				DisplayHeader,
				pStartPoRel,
				pEndPoRel,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
