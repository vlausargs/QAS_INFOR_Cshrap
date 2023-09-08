//PROJECT NAME: ReportExt
//CLASS NAME: SLCHSBankBookReport.cs

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
    [IDOExtensionClass("SLCHSBankBookReport")]
    public class SLCHSBankBookReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_PrintBankBookSp(string PBankCode,
		                                        DateTime? PDateFrom,
		                                        DateTime? PDateTo,
		                                        [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_PrintBankBookExt = new CHSRpt_PrintBankBookFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_PrintBankBookExt.CHSRpt_PrintBankBookSp(PBankCode,
				                                                             PDateFrom,
				                                                             PDateTo,
				                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
