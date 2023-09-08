//PROJECT NAME: ReportExt
//CLASS NAME: SLDraftAgingReport.cs

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
	[IDOExtensionClass("SLDraftAgingReport")]
	public class SLDraftAgingReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_DraftAgingSp([Optional] string BegCusNum,
		[Optional] string EndCusNum,
		[Optional] DateTime? ExBegDueDate,
		[Optional] DateTime? ExEndDueDate,
		[Optional] int? ExBegDateOffset,
		[Optional] int? ExEndDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_DraftAgingExt = new Rpt_DraftAgingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_DraftAgingExt.Rpt_DraftAgingSp(BegCusNum,
				EndCusNum,
				ExBegDueDate,
				ExEndDueDate,
				ExBegDateOffset,
				ExEndDateOffset,
				DisplayHeader,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
