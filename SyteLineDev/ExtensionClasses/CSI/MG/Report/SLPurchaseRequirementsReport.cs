//PROJECT NAME: ReportExt
//CLASS NAME: SLPurchaseRequirementsReport.cs

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
    [IDOExtensionClass("SLPurchaseRequirementsReport")]
    public class SLPurchaseRequirementsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PurchaseRequirementsSp([Optional] string WhseStarting,
		[Optional] string WhseEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string ProductCodeStarting,
		[Optional] string ProductCodeEnding,
		[Optional] string PlanCodeStarting,
		[Optional] string PlanCodeEnding,
		[Optional] string MatlType,
		[Optional] string Source,
		[Optional] string Stocked,
		[Optional] string ABCCode,
		[Optional] int? ShowDepl,
		[Optional] int? ShowRepl,
		[Optional] int? TimePhaseDetail,
		[Optional] string COStatus,
		[Optional] string POStatus,
		[Optional] string PSStatus,
		[Optional] string JobStatus,
		[Optional] int? DisplayHeader,
		[Optional] string SROStatus,
		[Optional] int? IncOrderMinMult,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PurchaseRequirementsExt = new Rpt_PurchaseRequirementsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PurchaseRequirementsExt.Rpt_PurchaseRequirementsSp(WhseStarting,
				WhseEnding,
				ItemStarting,
				ItemEnding,
				ProductCodeStarting,
				ProductCodeEnding,
				PlanCodeStarting,
				PlanCodeEnding,
				MatlType,
				Source,
				Stocked,
				ABCCode,
				ShowDepl,
				ShowRepl,
				TimePhaseDetail,
				COStatus,
				POStatus,
				PSStatus,
				JobStatus,
				DisplayHeader,
				SROStatus,
				IncOrderMinMult,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
