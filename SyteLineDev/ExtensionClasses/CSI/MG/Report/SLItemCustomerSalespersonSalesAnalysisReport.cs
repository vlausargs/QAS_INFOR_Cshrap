//PROJECT NAME: ReportExt
//CLASS NAME: SLItemCustomerSalespersonSalesAnalysisReport.cs

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
    [IDOExtensionClass("SLItemCustomerSalespersonSalesAnalysisReport")]
    public class SLItemCustomerSalespersonSalesAnalysisReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemCustomerSalesPersonSalesAnalysisSp([Optional] string SalesPersonStarting,
		                                                            [Optional] string SalesPersonEnding,
		                                                            [Optional] string CustomerStarting,
		                                                            [Optional] string CustomerEnding,
		                                                            [Optional] DateTime? ExOptacAsOfDate,
		                                                            [Optional] short? ExOptacAsOfDateOffset,
		                                                            [Optional] byte? PageBetweenItems,
		                                                            [Optional, DefaultParameterValue((byte)0)] byte? PrintPrice,
		[Optional] byte? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemCustomerSalesPersonSalesAnalysisExt = new Rpt_ItemCustomerSalesPersonSalesAnalysisFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemCustomerSalesPersonSalesAnalysisExt.Rpt_ItemCustomerSalesPersonSalesAnalysisSp(SalesPersonStarting,
				                                                                                                     SalesPersonEnding,
				                                                                                                     CustomerStarting,
				                                                                                                     CustomerEnding,
				                                                                                                     ExOptacAsOfDate,
				                                                                                                     ExOptacAsOfDateOffset,
				                                                                                                     PageBetweenItems,
				                                                                                                     PrintPrice,
				                                                                                                     DisplayHeader,
				                                                                                                     BGSessionId,
				                                                                                                     TaskId,
				                                                                                                     pSite,
				                                                                                                     BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
