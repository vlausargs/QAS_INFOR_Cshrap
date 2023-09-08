//PROJECT NAME: ReportExt
//CLASS NAME: SLMasterPlanningReport.cs

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
    [IDOExtensionClass("SLMasterPlanningReport")]
    public class SLMasterPlanningReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MasterPlanningSp([Optional] string PlannerCodeStarting,
		[Optional] string PlannerCodeEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] int? MPSItemsOnly,
		[Optional] int? DisplayMPSExceptions,
		[Optional] int? DisplayHeader,
		[Optional] string pSite,
		[Optional] string MessageLanguage)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MasterPlanningExt = new Rpt_MasterPlanningFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MasterPlanningExt.Rpt_MasterPlanningSp(PlannerCodeStarting,
				PlannerCodeEnding,
				ItemStarting,
				ItemEnding,
				MPSItemsOnly,
				DisplayMPSExceptions,
				DisplayHeader,
				pSite,
				MessageLanguage);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
