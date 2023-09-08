//PROJECT NAME: ReportExt
//CLASS NAME: SLMaterialUseUpReport.cs

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
    [IDOExtensionClass("SLMaterialUseUpReport")]
    public class SLMaterialUseUpReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MaterialUseUpSp(int? IncludeSupply,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string Whse,
		[Optional] DateTime? HardBreakDate,
		[Optional] string pSite,
		[Optional, DefaultParameterValue(0)] int? IncludePLNs)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MaterialUseUpExt = new Rpt_MaterialUseUpFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MaterialUseUpExt.Rpt_MaterialUseUpSp(IncludeSupply,
				ItemStarting,
				ItemEnding,
				Whse,
				HardBreakDate,
				pSite,
				IncludePLNs);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
