//PROJECT NAME: ReportExt
//CLASS NAME: SLIntraSiteTransferMasterDisplayReport.cs

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
    [IDOExtensionClass("SLIntraSiteTransferMasterDisplayReport")]
    public class SLIntraSiteTransferMasterDisplayReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_IntraSiteTransferMasterDisplaySp([Optional] string PlannerCodeStarting,
		                                                      [Optional] string PlannerCodeEnding,
		                                                      [Optional] string ItemStarting,
		                                                      [Optional] string ItemEnding,
		                                                      [Optional] string WhseStarting,
		                                                      [Optional] string WhseEnding,
		                                                      [Optional] byte? MPSItemsOnly,
		                                                      [Optional] byte? DisplayHeader,
		                                                      [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_IntraSiteTransferMasterDisplayExt = new Rpt_IntraSiteTransferMasterDisplayFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_IntraSiteTransferMasterDisplayExt.Rpt_IntraSiteTransferMasterDisplaySp(PlannerCodeStarting,
				                                                                                         PlannerCodeEnding,
				                                                                                         ItemStarting,
				                                                                                         ItemEnding,
				                                                                                         WhseStarting,
				                                                                                         WhseEnding,
				                                                                                         MPSItemsOnly,
				                                                                                         DisplayHeader,
				                                                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
