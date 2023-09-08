//PROJECT NAME: ReportExt
//CLASS NAME: SLProductionCostbyWorkCenterReport.cs

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
    [IDOExtensionClass("SLProductionCostbyWorkCenterReport")]
    public class SLProductionCostbyWorkCenterReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_productionCostbyWorkCenterSp([Optional] string StartingWorkCenter,
		[Optional] string EndingWorkCenter,
		[Optional] DateTime? StartingTransDate,
		[Optional] DateTime? EndingTransDate,
		[Optional] int? StartingTransDateOffset,
		[Optional] int? EndingTransDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_productionCostbyWorkCenterExt = new Rpt_productionCostbyWorkCenterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_productionCostbyWorkCenterExt.Rpt_productionCostbyWorkCenterSp(StartingWorkCenter,
				EndingWorkCenter,
				StartingTransDate,
				EndingTransDate,
				StartingTransDateOffset,
				EndingTransDateOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
