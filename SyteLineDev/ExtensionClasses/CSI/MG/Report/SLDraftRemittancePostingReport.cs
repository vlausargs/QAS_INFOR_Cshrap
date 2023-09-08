//PROJECT NAME: ReportExt
//CLASS NAME: SLDraftRemittancePostingReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Data.RecordSets;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLDraftRemittancePostingReport")]
    public class SLDraftRemittancePostingReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_DraftRemittancePostingSp([Optional] string PBankCode,
		                                              [Optional] string PStartingVendor,
		                                              [Optional] string PEndingVendor,
		                                              [Optional] byte? DisplayHeader,
		                                              [Optional] int? PDraftNumberStarting,
		                                              [Optional] int? PDraftNumberEnding,
		                                              [Optional] DateTime? PDueDateStarting,
		                                              [Optional] DateTime? PDueDateEnding,
		                                              [Optional] short? PDueDateStartingOffset,
		                                              [Optional] short? PDueDateEndingOffset,
		                                              [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_DraftRemittancePostingExt = new Rpt_DraftRemittancePostingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_DraftRemittancePostingExt.Rpt_DraftRemittancePostingSp(PBankCode,
				                                                                         PStartingVendor,
				                                                                         PEndingVendor,
				                                                                         DisplayHeader,
				                                                                         PDraftNumberStarting,
				                                                                         PDraftNumberEnding,
				                                                                         PDueDateStarting,
				                                                                         PDueDateEnding,
				                                                                         PDueDateStartingOffset,
				                                                                         PDueDateEndingOffset,
				                                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
