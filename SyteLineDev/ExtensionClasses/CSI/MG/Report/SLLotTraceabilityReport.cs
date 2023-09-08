//PROJECT NAME: ReportExt
//CLASS NAME: SLLotTraceabilityReport.cs

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
    [IDOExtensionClass("SLLotTraceabilityReport")]
    public class SLLotTraceabilityReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_LotTraceabilitySp([Optional] string PStartingItem,
		[Optional] string PEndingItem,
		[Optional] string PStartingLot,
		[Optional] string PEndingLot,
		[Optional, DefaultParameterValue("D")] string PSummaryDetail,
		[Optional, DefaultParameterValue("L")] string PSortBy,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string PMessageLanguage,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_LotTraceabilityExt = new Rpt_LotTraceabilityFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_LotTraceabilityExt.Rpt_LotTraceabilitySp(PStartingItem,
				PEndingItem,
				PStartingLot,
				PEndingLot,
				PSummaryDetail,
				PSortBy,
				PDisplayHeader,
				PMessageLanguage,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
