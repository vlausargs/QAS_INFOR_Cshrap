//PROJECT NAME: ReportExt
//CLASS NAME: SLDunningReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLDunningReport")]
    public class SLDunningReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_DunningSp([Optional] string PStartingCustomer,
		                               [Optional] string PEndingCustomer,
		                               [Optional] string PDunningGroup,
		                               [Optional] int? PStartingDunningStage,
		                               [Optional] int? PEndingDunningStage,
		                               [Optional] string PSiteGroup,
		                               [Optional, DefaultParameterValue((byte)0)] byte? PCommit,
		[Optional] DateTime? PCutoffDate,
		[Optional] short? PCutoffDateOffset,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_DunningExt = new Rpt_DunningFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_DunningExt.Rpt_DunningSp(PStartingCustomer,
				                                           PEndingCustomer,
				                                           PDunningGroup,
				                                           PStartingDunningStage,
				                                           PEndingDunningStage,
				                                           PSiteGroup,
				                                           PCommit,
				                                           PCutoffDate,
				                                           PCutoffDateOffset,
				                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
