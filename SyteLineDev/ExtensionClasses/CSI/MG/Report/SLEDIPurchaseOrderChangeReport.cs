//PROJECT NAME: ReportExt
//CLASS NAME: SLEDIPurchaseOrderChangeReport.cs

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
    [IDOExtensionClass("SLEDIPurchaseOrderChangeReport")]
    public class SLEDIPurchaseOrderChangeReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EDIPurchaseOrderChangeSp([Optional] string StartCustomer,
		                                              [Optional] string EndCustomer,
		                                              [Optional] DateTime? StartReceiveDate,
		                                              [Optional] DateTime? EndReceiveDate,
		                                              [Optional] string StartOrder,
		                                              [Optional] string EndOrder,
		                                              [Optional, DefaultParameterValue("POC")] string TransactionCode,
		[Optional, DefaultParameterValue("D")] string SumOrDetail,
		[Optional] short? StartDateOffset,
		[Optional] short? EndDateOffset,
		[Optional] byte? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_EDIPurchaseOrderChangeExt = new Rpt_EDIPurchaseOrderChangeFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_EDIPurchaseOrderChangeExt.Rpt_EDIPurchaseOrderChangeSp(StartCustomer,
				                                                                         EndCustomer,
				                                                                         StartReceiveDate,
				                                                                         EndReceiveDate,
				                                                                         StartOrder,
				                                                                         EndOrder,
				                                                                         TransactionCode,
				                                                                         SumOrDetail,
				                                                                         StartDateOffset,
				                                                                         EndDateOffset,
				                                                                         DisplayHeader,
				                                                                         BGSessionId,
				                                                                         pSite,
				                                                                         BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
