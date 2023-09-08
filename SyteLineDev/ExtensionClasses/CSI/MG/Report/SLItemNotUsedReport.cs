//PROJECT NAME: ReportExt
//CLASS NAME: SLItemNotUsedReport.cs

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
    [IDOExtensionClass("SLItemNotUsedReport")]
    public class SLItemNotUsedReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemNotUsedSp([Optional, DefaultParameterValue("ABCDEFGHILMNOPRSTW")] string TransactionType,
		[Optional, DefaultParameterValue("IORPJTSKWCF")] string RefType,
		[Optional] DateTime? TransDateStarting,
		[Optional] DateTime? TransDateEnding,
		[Optional] string WarehouseStarting,
		[Optional] string WarehouseEnding,
		[Optional] string ProductCodeStarting,
		[Optional] string ProductCodeEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string LocationStarting,
		[Optional] string LocationEnding,
		[Optional] string PlannerCodeStarting,
		[Optional] string PlannerCodeEnding,
		[Optional] decimal? TransNumStarting,
		[Optional] decimal? TransNumEnding,
		[Optional] string ReasonCodeStarting,
		[Optional] string ReasonCodeEnding,
		[Optional] short? TransDateStartingOffset,
		[Optional] short? TransDateEndingOffset,
		[Optional] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemNotUsedExt = new Rpt_ItemNotUsedFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemNotUsedExt.Rpt_ItemNotUsedSp(TransactionType,
				                                                   RefType,
				                                                   TransDateStarting,
				                                                   TransDateEnding,
				                                                   WarehouseStarting,
				                                                   WarehouseEnding,
				                                                   ProductCodeStarting,
				                                                   ProductCodeEnding,
				                                                   ItemStarting,
				                                                   ItemEnding,
				                                                   LocationStarting,
				                                                   LocationEnding,
				                                                   PlannerCodeStarting,
				                                                   PlannerCodeEnding,
				                                                   TransNumStarting,
				                                                   TransNumEnding,
				                                                   ReasonCodeStarting,
				                                                   ReasonCodeEnding,
				                                                   TransDateStartingOffset,
				                                                   TransDateEndingOffset,
				                                                   DisplayHeader,
				                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
