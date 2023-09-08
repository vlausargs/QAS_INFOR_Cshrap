//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderPlannedMaterialRequirementReport.cs

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
	[IDOExtensionClass("SLServiceOrderPlannedMaterialRequirementReport")]
	public class SLServiceOrderPlannedMaterialRequirementReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSSRORpt_MatlRequirementSP([Optional] string PSRONumberStarting,
		[Optional] string PSRONumberEnding,
		[Optional] int? PSROLineNumberStarting,
		[Optional] int? PSROLineNumberEnding,
		[Optional] int? PSROOperNumberStarting,
		[Optional] int? PSROOperNumberEnding,
		[Optional] string PItemStarting,
		[Optional] string PItemEnding,
		[Optional, DefaultParameterValue(0)] int? PIncludePostedPlanned,
		ref string Infobar,
		[Optional, DefaultParameterValue(1)] int? PIncludeSRODemand,
		[Optional] string PCustNumStarting,
		[Optional] string PCustNumEnding,
		[Optional] string PProdCodeStarting,
		[Optional] string PProdCodeEnding,
		[Optional] DateTime? PSROLineDueDateStarting,
		[Optional] DateTime? PSROLineDueDateEnding,
		[Optional, DefaultParameterValue(0)] int? PShowShortages,
		[Optional, DefaultParameterValue("SRO")] string PSortby,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSRORpt_MatlRequirementExt = new SSSFSSRORpt_MatlRequirementFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSRORpt_MatlRequirementExt.SSSFSSRORpt_MatlRequirementSP(PSRONumberStarting,
				PSRONumberEnding,
				PSROLineNumberStarting,
				PSROLineNumberEnding,
				PSROOperNumberStarting,
				PSROOperNumberEnding,
				PItemStarting,
				PItemEnding,
				PIncludePostedPlanned,
				Infobar,
				PIncludeSRODemand,
				PCustNumStarting,
				PCustNumEnding,
				PProdCodeStarting,
				PProdCodeEnding,
				PSROLineDueDateStarting,
				PSROLineDueDateEnding,
				PShowShortages,
				PSortby,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
	}
}
