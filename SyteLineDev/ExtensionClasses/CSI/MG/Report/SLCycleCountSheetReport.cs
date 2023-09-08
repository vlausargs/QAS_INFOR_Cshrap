//PROJECT NAME: ReportExt
//CLASS NAME: SLCycleCountSheetReport.cs

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
    [IDOExtensionClass("SLCycleCountSheetReport")]
    public class SLCycleCountSheetReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CycleCountSheetSp([Optional] string CycleType,
		                                       [Optional] string ABCCode,
		                                       [Optional] string SortBy,
		                                       [Optional, DefaultParameterValue((byte)0)] byte? PageBreak,
		[Optional, DefaultParameterValue((byte)0)] byte? pr_cut_off_qty,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string LocStarting,
		[Optional] string LocEnding,
		[Optional] string ProductCodeStarting,
		[Optional] string ProductCodeEnding,
		[Optional] string PlanCodeStarting,
		[Optional] string PlanCodeEnding,
		[Optional] byte? PrintBarcodeFormat,
		[Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional] string Whse,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintPieces,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CycleCountSheetExt = new Rpt_CycleCountSheetFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CycleCountSheetExt.Rpt_CycleCountSheetSp(CycleType,
				                                                           ABCCode,
				                                                           SortBy,
				                                                           PageBreak,
				                                                           pr_cut_off_qty,
				                                                           ItemStarting,
				                                                           ItemEnding,
				                                                           LocStarting,
				                                                           LocEnding,
				                                                           ProductCodeStarting,
				                                                           ProductCodeEnding,
				                                                           PlanCodeStarting,
				                                                           PlanCodeEnding,
				                                                           PrintBarcodeFormat,
				                                                           DisplayHeader,
				                                                           Whse,
				                                                           PrintPieces,
				                                                           BGSessionId,
				                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
