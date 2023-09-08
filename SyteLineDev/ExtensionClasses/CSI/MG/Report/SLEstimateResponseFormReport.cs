//PROJECT NAME: ReportExt
//CLASS NAME: SLEstimateResponseFormReport.cs

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
    [IDOExtensionClass("SLEstimateResponseFormReport")]
    public class SLEstimateResponseFormReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EstimateResponseFormSp([Optional, DefaultParameterValue((byte)1)] byte? EstimateText,
		[Optional, DefaultParameterValue((byte)1)] byte? StdOrderText,
		[Optional, DefaultParameterValue("E")] string ConfigDetails,
		[Optional] string PrintItemType,
		[Optional] byte? PrintLineReleaseText,
		[Optional] byte? PrintBillTo,
		[Optional] byte? PrintShipTo,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintPlanningItemMaterials,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintEuroTotal,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintPrice,
		[Optional, DefaultParameterValue((byte)0)] byte? DisplayHeader,
		[Optional] string EstimateStarting,
		[Optional] string EstimateEnding,
		[Optional, DefaultParameterValue((byte)1)] byte? ShowInternal,
		[Optional, DefaultParameterValue((byte)1)] byte? ShowExternal,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintItemOverview,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintDrawingNumber,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintEndUserItem,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintHeaderOnAllPages,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintDueDate,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintProjectedDate,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_EstimateResponseFormExt = new Rpt_EstimateResponseFormFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_EstimateResponseFormExt.Rpt_EstimateResponseFormSp(EstimateText,
				                                                                     StdOrderText,
				                                                                     ConfigDetails,
				                                                                     PrintItemType,
				                                                                     PrintLineReleaseText,
				                                                                     PrintBillTo,
				                                                                     PrintShipTo,
				                                                                     PrintPlanningItemMaterials,
				                                                                     PrintEuroTotal,
				                                                                     PrintPrice,
				                                                                     DisplayHeader,
				                                                                     EstimateStarting,
				                                                                     EstimateEnding,
				                                                                     ShowInternal,
				                                                                     ShowExternal,
				                                                                     PrintItemOverview,
				                                                                     PrintDrawingNumber,
				                                                                     PrintEndUserItem,
				                                                                     PrintHeaderOnAllPages,
				                                                                     PrintDueDate,
				                                                                     PrintProjectedDate,
				                                                                     pSite,
				                                                                     BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
