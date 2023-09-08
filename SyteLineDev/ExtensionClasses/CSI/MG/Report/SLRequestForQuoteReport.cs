//PROJECT NAME: ReportExt
//CLASS NAME: SLRequestForQuoteReport.cs

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
    [IDOExtensionClass("SLRequestForQuoteReport")]
    public class SLRequestForQuoteReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRFQRpt_SendQuoteSp(string RfqNum,
		                                       int? RfqLine,
		                                       int? RfqSeq,
		                                       byte? Resend,
		                                       byte? Preview,
		                                       [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSRFQRpt_SendQuoteExt = new SSSRFQRpt_SendQuoteFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSRFQRpt_SendQuoteExt.SSSRFQRpt_SendQuoteSp(RfqNum,
				                                                           RfqLine,
				                                                           RfqSeq,
				                                                           Resend,
				                                                           Preview,
				                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
