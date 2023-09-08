//PROJECT NAME: ReportExt
//CLASS NAME: SL1099FormPrintingReport.cs

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
    [IDOExtensionClass("SL1099FormPrintingReport")]
    public class SL1099FormPrintingReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_1099FormPrintingSp([Optional] string ExOptszSiteGroup,
		                                        [Optional] string VendorNumStarting,
		                                        [Optional] string VendorNumEnding,
		                                        [Optional] decimal? ExOptgoMinPayments,
		                                        [Optional] byte? ExOptszUseLstYrPayRec,
		                                        [Optional] string ExOptprPaperTapeDisk,
		                                        [Optional] string PPhone,
		                                        [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_1099FormPrintingExt = new Rpt_1099FormPrintingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_1099FormPrintingExt.Rpt_1099FormPrintingSp(ExOptszSiteGroup,
				                                                             VendorNumStarting,
				                                                             VendorNumEnding,
				                                                             ExOptgoMinPayments,
				                                                             ExOptszUseLstYrPayRec,
				                                                             ExOptprPaperTapeDisk,
				                                                             PPhone,
				                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
