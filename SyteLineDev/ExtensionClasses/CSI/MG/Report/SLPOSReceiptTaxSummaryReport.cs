//PROJECT NAME: ReportExt
//CLASS NAME: SLPOSReceiptTaxSummaryReport.cs

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
    [IDOExtensionClass("SLPOSReceiptTaxSummaryReport")]
    public class SLPOSReceiptTaxSummaryReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSPOSRpt_TaxSumRSp(string InvNum,
		                                     int? InvSeq,
		                                     [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSPOSRpt_TaxSumRExt = new SSSPOSRpt_TaxSumRFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSPOSRpt_TaxSumRExt.SSSPOSRpt_TaxSumRSp(InvNum,
				                                                       InvSeq,
				                                                       pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
