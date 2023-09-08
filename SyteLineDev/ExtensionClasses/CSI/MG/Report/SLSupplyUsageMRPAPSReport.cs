//PROJECT NAME: ReportExt
//CLASS NAME: SLSupplyUsageMRPAPSReport.cs

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
    [IDOExtensionClass("SLSupplyUsageMRPAPSReport")]
    public class SLSupplyUsageMRPAPSReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SupplyUsageMrpApsSp([Optional] string PlannerCodeStarting,
		[Optional] string PlannerCodeEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string Source,
		[Optional] int? DisplayHeader,
		[Optional] int? ALTNO,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SupplyUsageMrpApsExt = new Rpt_SupplyUsageMrpApsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SupplyUsageMrpApsExt.Rpt_SupplyUsageMrpApsSp(PlannerCodeStarting,
				PlannerCodeEnding,
				ItemStarting,
				ItemEnding,
				Source,
				DisplayHeader,
				ALTNO,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
