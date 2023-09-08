//PROJECT NAME: ReportExt
//CLASS NAME: SLEstimatesByProfitReport.cs

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
    [IDOExtensionClass("SLEstimatesByProfitReport")]
    public class SLEstimatesByProfitReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EstimatesByProfitSp([Optional, DefaultParameterValue("WQPH")] string EstimateStatus,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintCost,
		[Optional] string OrderStarting,
		[Optional] string OrderEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] DateTime? QuoteDateStarting,
		[Optional] DateTime? QuoteDateEnding,
		[Optional] short? QuoteDateStartingOffset,
		[Optional] short? QuoteDateEndingOffset,
		[Optional] DateTime? ExpireDateStarting,
		[Optional] DateTime? ExpireDateEnding,
		[Optional] short? ExpireDateStartingOffset,
		[Optional] short? ExpireDateEndingOffset,
		[Optional, DefaultParameterValue((byte)1)] byte? CoShowInternal,
		[Optional, DefaultParameterValue((byte)1)] byte? CoShowExternal,
		[Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional] string StartProspect,
		[Optional] string EndProspect,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_EstimatesByProfitExt = new Rpt_EstimatesByProfitFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_EstimatesByProfitExt.Rpt_EstimatesByProfitSp(EstimateStatus,
				                                                               PrintCost,
				                                                               OrderStarting,
				                                                               OrderEnding,
				                                                               CustomerStarting,
				                                                               CustomerEnding,
				                                                               QuoteDateStarting,
				                                                               QuoteDateEnding,
				                                                               QuoteDateStartingOffset,
				                                                               QuoteDateEndingOffset,
				                                                               ExpireDateStarting,
				                                                               ExpireDateEnding,
				                                                               ExpireDateStartingOffset,
				                                                               ExpireDateEndingOffset,
				                                                               CoShowInternal,
				                                                               CoShowExternal,
				                                                               DisplayHeader,
				                                                               StartProspect,
				                                                               EndProspect,
				                                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
