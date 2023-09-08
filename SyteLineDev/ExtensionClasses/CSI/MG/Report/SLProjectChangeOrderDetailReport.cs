//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectChangeOrderDetailReport.cs

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
    [IDOExtensionClass("SLProjectChangeOrderDetailReport")]
    public class SLProjectChangeOrderDetailReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectChangeOrderDetailSp([Optional] string pChgStat,
		[Optional] string pPrChgTxtDet,
		[Optional] string pStartProjNum,
		[Optional] string pEndProjNum,
		[Optional] int? pStartChgNum,
		[Optional] int? pEndChgNum,
		[Optional] int? pStartTaskNum,
		[Optional] int? pEndTaskNum,
		[Optional] int? pStartSeq,
		[Optional] int? pEndSeq,
		[Optional] DateTime? pStartChgDate,
		[Optional] DateTime? pEndChgDate,
		[Optional] int? pStartChgDateOffset,
		[Optional] int? pEndChgDateOffset,
		[Optional, DefaultParameterValue(1)] int? Showinternal,
		[Optional, DefaultParameterValue(1)] int? ShowExternal,
		[Optional] int? DisplayHeader,
		[Optional] string PMessageLanguage,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjectChangeOrderDetailExt = new Rpt_ProjectChangeOrderDetailFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectChangeOrderDetailExt.Rpt_ProjectChangeOrderDetailSp(pChgStat,
				pPrChgTxtDet,
				pStartProjNum,
				pEndProjNum,
				pStartChgNum,
				pEndChgNum,
				pStartTaskNum,
				pEndTaskNum,
				pStartSeq,
				pEndSeq,
				pStartChgDate,
				pEndChgDate,
				pStartChgDateOffset,
				pEndChgDateOffset,
				Showinternal,
				ShowExternal,
				DisplayHeader,
				PMessageLanguage,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
