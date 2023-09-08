//PROJECT NAME: ReportExt
//CLASS NAME: SLFiscalReportingSystemReport.cs

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
    [IDOExtensionClass("SLFiscalReportingSystemReport")]
    public class SLFiscalReportingSystemReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_FiscalReportingSystemReportSp([Optional] string StartingFiscalReportingSystem,
		                                                   [Optional] string EndingFiscalReportingSystem,
		                                                   [Optional] string StartingVendor,
		                                                   [Optional] string EndingVendor,
		                                                   [Optional] string CurrentYear,
		                                                   [Optional] byte? DisplayHeader,
		                                                   [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_FiscalReportingSystemReportExt = new Rpt_FiscalReportingSystemReportFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_FiscalReportingSystemReportExt.Rpt_FiscalReportingSystemReportSp(StartingFiscalReportingSystem,
				                                                                                   EndingFiscalReportingSystem,
				                                                                                   StartingVendor,
				                                                                                   EndingVendor,
				                                                                                   CurrentYear,
				                                                                                   DisplayHeader,
				                                                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
