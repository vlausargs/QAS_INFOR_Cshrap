//PROJECT NAME: ReportExt
//CLASS NAME: SLEDIPurchaseOrderRequirementReport.cs

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
    [IDOExtensionClass("SLEDIPurchaseOrderRequirementReport")]
    public class SLEDIPurchaseOrderRequirementReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EDIPurchaseOrderRequirementSp([Optional] string CustomerStarting,
		                                                   [Optional] string CustomerEnding,
		                                                   [Optional] DateTime? ReceiveDateStarting,
		                                                   [Optional] DateTime? ReceiveDateEnding,
		                                                   [Optional] string OrderStarting,
		                                                   [Optional] string OrderEnding,
		                                                   [Optional] string TransactionCode,
		                                                   [Optional] string SummaryOrDetail,
		                                                   [Optional] short? ReceiveDateStartingOffset,
		                                                   [Optional] short? ReceiveDateEndingOffset,
		                                                   [Optional] byte? DisplayHeader,
		                                                   [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_EDIPurchaseOrderRequirementExt = new Rpt_EDIPurchaseOrderRequirementFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_EDIPurchaseOrderRequirementExt.Rpt_EDIPurchaseOrderRequirementSp(CustomerStarting,
				                                                                                   CustomerEnding,
				                                                                                   ReceiveDateStarting,
				                                                                                   ReceiveDateEnding,
				                                                                                   OrderStarting,
				                                                                                   OrderEnding,
				                                                                                   TransactionCode,
				                                                                                   SummaryOrDetail,
				                                                                                   ReceiveDateStartingOffset,
				                                                                                   ReceiveDateEndingOffset,
				                                                                                   DisplayHeader,
				                                                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
