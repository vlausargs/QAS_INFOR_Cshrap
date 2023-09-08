//PROJECT NAME: ReportExt
//CLASS NAME: SLPOSReceiptReport.cs

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
    [IDOExtensionClass("SLPOSReceiptReport")]
    public class SLPOSReceiptReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSPOSRpt_POSInc_RSp(string tPrintInvNum,
		                                      string tPrintPosmNum,
		                                      byte? tTransDomCurr,
		                                      string ParmCurrCode,
		                                      [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSPOSRpt_POSInc_RExt = new SSSPOSRpt_POSInc_RFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSPOSRpt_POSInc_RExt.SSSPOSRpt_POSInc_RSp(tPrintInvNum,
				                                                         tPrintPosmNum,
				                                                         tTransDomCurr,
				                                                         ParmCurrCode,
				                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
