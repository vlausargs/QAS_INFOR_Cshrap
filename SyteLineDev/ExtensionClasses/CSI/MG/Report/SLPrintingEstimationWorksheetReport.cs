//PROJECT NAME: ReportExt
//CLASS NAME: SLPrintingEstimationWorksheetReport.cs

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
    [IDOExtensionClass("SLPrintingEstimationWorksheetReport")]
    public class SLPrintingEstimationWorksheetReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PrintingEstimateWorksheetSp([Optional] string CoNum,
		[Optional, DefaultParameterValue(0)] int? CoLine,
		[Optional, DefaultParameterValue(0)] decimal? CompQty2,
		[Optional, DefaultParameterValue(0)] decimal? CompQty3,
		[Optional, DefaultParameterValue(0)] decimal? CompQty4,
		[Optional, DefaultParameterValue(0)] decimal? CompQty5,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PrintingEstimateWorksheetExt = new Rpt_PrintingEstimateWorksheetFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PrintingEstimateWorksheetExt.Rpt_PrintingEstimateWorksheetSp(CoNum,
				CoLine,
				CompQty2,
				CompQty3,
				CompQty4,
				CompQty5,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
