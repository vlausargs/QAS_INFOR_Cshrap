//PROJECT NAME: ReportExt
//CLASS NAME: SLRequestForQuoteByVendorReport.cs

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
    [IDOExtensionClass("SLRequestForQuoteByVendorReport")]
    public class SLRequestForQuoteByVendorReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRFQRpt_SendQuoteByVendorSp(string VendNum,
		                                               string StartingRFQ,
		                                               string EndingRFQ,
		                                               string StartingProdCode,
		                                               string EndingProdCode,
		                                               string StartingItem,
		                                               string EndingItem,
		                                               string DistMethod,
		                                               string SelectedRfqNumLine,
		                                               byte? PageBreak,
		                                               byte? Preview,
		                                               [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSRFQRpt_SendQuoteByVendorExt = new SSSRFQRpt_SendQuoteByVendorFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSRFQRpt_SendQuoteByVendorExt.SSSRFQRpt_SendQuoteByVendorSp(VendNum,
				                                                                           StartingRFQ,
				                                                                           EndingRFQ,
				                                                                           StartingProdCode,
				                                                                           EndingProdCode,
				                                                                           StartingItem,
				                                                                           EndingItem,
				                                                                           DistMethod,
				                                                                           SelectedRfqNumLine,
				                                                                           PageBreak,
				                                                                           Preview,
				                                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
