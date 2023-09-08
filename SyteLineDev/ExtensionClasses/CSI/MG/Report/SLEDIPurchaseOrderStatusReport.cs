//PROJECT NAME: ReportExt
//CLASS NAME: SLEDIPurchaseOrderStatusReport.cs

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
    [IDOExtensionClass("SLEDIPurchaseOrderStatusReport")]
    public class SLEDIPurchaseOrderStatusReport : ExtensionClassBase
    {
      

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EDIPurchaseOrderStatusSp([Optional] DateTime? OrderDateStarting,
		                                              [Optional] DateTime? OrderDateEnding,
		                                              [Optional] string CustomerStarting,
		                                              [Optional] string CustomerEnding,
		                                              [Optional] string OrderStarting,
		                                              [Optional] string OrderEnding,
		                                              [Optional] string CustPoStarting,
		                                              [Optional] string CustPoEnding,
		                                              [Optional] string ItemStarting,
		                                              [Optional] string ItemEnding,
		                                              [Optional] string CustItemStarting,
		                                              [Optional] string CustItemEnding,
		                                              [Optional] short? OrderDateStartingOffset,
		                                              [Optional] short? OrderDateEndingOffset,
		                                              [Optional] byte? ShowInternal,
		                                              [Optional] byte? ShowExternal,
		                                              [Optional] byte? DisplayHeader,
		                                              [Optional] string BGSessionId,
		                                              [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_EDIPurchaseOrderStatusExt = new Rpt_EDIPurchaseOrderStatusFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_EDIPurchaseOrderStatusExt.Rpt_EDIPurchaseOrderStatusSp(OrderDateStarting,
				                                                                         OrderDateEnding,
				                                                                         CustomerStarting,
				                                                                         CustomerEnding,
				                                                                         OrderStarting,
				                                                                         OrderEnding,
				                                                                         CustPoStarting,
				                                                                         CustPoEnding,
				                                                                         ItemStarting,
				                                                                         ItemEnding,
				                                                                         CustItemStarting,
				                                                                         CustItemEnding,
				                                                                         OrderDateStartingOffset,
				                                                                         OrderDateEndingOffset,
				                                                                         ShowInternal,
				                                                                         ShowExternal,
				                                                                         DisplayHeader,
				                                                                         BGSessionId,
				                                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
