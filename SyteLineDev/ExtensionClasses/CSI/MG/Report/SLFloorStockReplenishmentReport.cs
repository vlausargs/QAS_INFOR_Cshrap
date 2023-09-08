//PROJECT NAME: ReportExt
//CLASS NAME: SLFloorStockReplenishmentReport.cs

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
	[IDOExtensionClass("SLFloorStockReplenishmentReport")]
	public class SLFloorStockReplenishmentReport : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable FloorStkReplenCel06RPSp(string pStartJob,
		                                         string pEndJob,
		                                         short? pStartJobSuffix,
		                                         short? pEndJobSuffix,
		                                         string pStartPsNum,
		                                         string pEndPsNum,
		                                         string pStartItem,
		                                         string pEndItem,
		                                         string pStartJobMatlItem,
		                                         string pEndJobMatlItem,
		                                         DateTime? pStartDate,
		                                         DateTime? pEndDate,
		                                         string pStartWc,
		                                         string pEndWc,
		                                         byte? pSubtractFlrQty,
		                                         string pPostMat,
		                                         string pWhse,
		                                         byte? pBarCode,
		                                         string pConsolidateBy,
		                                         byte? pDisplayReportHeader,
		                                         string Infobar,
		                                         [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iFloorStkReplenCel06RPExt = new FloorStkReplenCel06RPFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iFloorStkReplenCel06RPExt.FloorStkReplenCel06RPSp(pStartJob,
				                                                               pEndJob,
				                                                               pStartJobSuffix,
				                                                               pEndJobSuffix,
				                                                               pStartPsNum,
				                                                               pEndPsNum,
				                                                               pStartItem,
				                                                               pEndItem,
				                                                               pStartJobMatlItem,
				                                                               pEndJobMatlItem,
				                                                               pStartDate,
				                                                               pEndDate,
				                                                               pStartWc,
				                                                               pEndWc,
				                                                               pSubtractFlrQty,
				                                                               pPostMat,
				                                                               pWhse,
				                                                               pBarCode,
				                                                               pConsolidateBy,
				                                                               pDisplayReportHeader,
				                                                               Infobar,
				                                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
