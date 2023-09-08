//PROJECT NAME: ReportExt
//CLASS NAME: CHSBankCompareReport.cs

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
    [IDOExtensionClass("CHSBankCompareReport")]
    public class CHSBankCompareReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_BankReconCompareSp(string PBankCode,
		                                           [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_BankReconCompareExt = new CHSRpt_BankReconCompareFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_BankReconCompareExt.CHSRpt_BankReconCompareSp(PBankCode,
				                                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
