//PROJECT NAME: ReportExt
//CLASS NAME: SLPlanningBOMReport.cs

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
    [IDOExtensionClass("SLPlanningBOMReport")]
    public class SLPlanningBOMReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PlanningBOMSP(string ItemStarting,
		string ItemEnding,
		string ProductCodeStarting,
		string ProductCodeEnding,
		string MaterialType,
		string ABCCode,
		DateTime? EffectiveDate,
		[Optional] int? EffectiveDateOffset,
		int? IndentedLevelView,
		int? PageBetweenItems,
		int? ShowPrice,
		int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PlanningBOMExt = new Rpt_PlanningBOMFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PlanningBOMExt.Rpt_PlanningBOMSP(ItemStarting,
				ItemEnding,
				ProductCodeStarting,
				ProductCodeEnding,
				MaterialType,
				ABCCode,
				EffectiveDate,
				EffectiveDateOffset,
				IndentedLevelView,
				PageBetweenItems,
				ShowPrice,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
