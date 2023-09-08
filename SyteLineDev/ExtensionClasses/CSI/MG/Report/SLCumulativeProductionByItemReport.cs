//PROJECT NAME: ReportExt
//CLASS NAME: SLCumulativeProductionByItemReport.cs

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
    [IDOExtensionClass("SLCumulativeProductionByItemReport")]
    public class SLCumulativeProductionByItemReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CumulativeProductionbyItemSp([Optional] string StartItem,
		                                                  [Optional] string EndItem,
		                                                  [Optional] string StartScheduleID,
		                                                  [Optional] string EndScheduleID,
		                                                  [Optional] DateTime? StartDate,
		                                                  [Optional] DateTime? EndDate,
		                                                  [Optional, DefaultParameterValue("R")] string SchIDStatus,
		[Optional, DefaultParameterValue("R")] string SchRelStatus,
		[Optional, DefaultParameterValue("D")] string BinType,
		[Optional] short? StartDateOffset,
		[Optional] short? EndDateOffset,
		[Optional] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CumulativeProductionbyItemExt = new Rpt_CumulativeProductionbyItemFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CumulativeProductionbyItemExt.Rpt_CumulativeProductionbyItemSp(StartItem,
				                                                                                 EndItem,
				                                                                                 StartScheduleID,
				                                                                                 EndScheduleID,
				                                                                                 StartDate,
				                                                                                 EndDate,
				                                                                                 SchIDStatus,
				                                                                                 SchRelStatus,
				                                                                                 BinType,
				                                                                                 StartDateOffset,
				                                                                                 EndDateOffset,
				                                                                                 DisplayHeader,
				                                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
