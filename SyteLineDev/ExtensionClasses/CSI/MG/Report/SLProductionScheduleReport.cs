//PROJECT NAME: ReportExt
//CLASS NAME: SLProductionScheduleReport.cs

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
    [IDOExtensionClass("SLProductionScheduleReport")]
    public class SLProductionScheduleReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProductionScheduleSp([Optional] string StartScheduleID,
		[Optional] string EndScheduleID,
		[Optional] string StartItem,
		[Optional] string EndItem,
		[Optional] DateTime? StartDate,
		[Optional] DateTime? EndDate,
		[Optional, DefaultParameterValue("R")] string SchIDStatus,
		[Optional, DefaultParameterValue("R")] string SchRelStatus,
		[Optional, DefaultParameterValue("D")] string BinType,
		[Optional, DefaultParameterValue("D")] string SumOrDetail,
		[Optional] int? StartDateOffset,
		[Optional] int? EndDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProductionScheduleExt = new Rpt_ProductionScheduleFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProductionScheduleExt.Rpt_ProductionScheduleSp(StartScheduleID,
				EndScheduleID,
				StartItem,
				EndItem,
				StartDate,
				EndDate,
				SchIDStatus,
				SchRelStatus,
				BinType,
				SumOrDetail,
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
