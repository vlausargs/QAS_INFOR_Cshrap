//PROJECT NAME: ReportExt
//CLASS NAME: SLItemProductCodeCustomerSalesAnalysisReport.cs

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
    [IDOExtensionClass("SLItemProductCodeCustomerSalesAnalysisReport")]
    public class SLItemProductCodeCustomerSalesAnalysisReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemProductCodeCustomerSalesAnalysisSp([Optional] string CustomerStarting,
		                                                            [Optional] string CustomerEnding,
		                                                            [Optional] string ProductCodeStarting,
		                                                            [Optional] string ProductCodeEnding,
		                                                            [Optional] string ItemStarting,
		                                                            [Optional] string ItemEnding,
		                                                            [Optional] DateTime? TransDateStarting,
		                                                            [Optional] short? TransDateStartingOffset,
		                                                            [Optional] DateTime? TransDateEnding,
		                                                            [Optional] short? TransDateEndingOffset,
		                                                            [Optional, DefaultParameterValue((byte)0)] byte? SumCorpCust,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintPrice,
		[Optional] string SiteGroup,
		[Optional] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemProductCodeCustomerSalesAnalysisExt = new Rpt_ItemProductCodeCustomerSalesAnalysisFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemProductCodeCustomerSalesAnalysisExt.Rpt_ItemProductCodeCustomerSalesAnalysisSp(CustomerStarting,
				                                                                                                     CustomerEnding,
				                                                                                                     ProductCodeStarting,
				                                                                                                     ProductCodeEnding,
				                                                                                                     ItemStarting,
				                                                                                                     ItemEnding,
				                                                                                                     TransDateStarting,
				                                                                                                     TransDateStartingOffset,
				                                                                                                     TransDateEnding,
				                                                                                                     TransDateEndingOffset,
				                                                                                                     SumCorpCust,
				                                                                                                     PrintPrice,
				                                                                                                     SiteGroup,
				                                                                                                     DisplayHeader,
				                                                                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
