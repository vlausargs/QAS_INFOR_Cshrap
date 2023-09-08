//PROJECT NAME: ReportExt
//CLASS NAME: SLGeneralLedgerWorksheetReport.cs

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
    [IDOExtensionClass("SLGeneralLedgerWorksheetReport")]
    public class SLGeneralLedgerWorksheetReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_GeneralLedgerWorksheetsp([Optional] DateTime? ExOptacAsOfDate,
		                                              [Optional] string ExStartingAccount,
		                                              [Optional] string ExEndingAccount,
		                                              [Optional] string ExOptacChartType,
		                                              [Optional] byte? TAnalyticalLedger,
		                                              [Optional] short? DateOffset,
		                                              [Optional] byte? DisplayHeader,
		                                              [Optional, DefaultParameterValue((byte)0)] byte? SeparateDrCrAmounts,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_GeneralLedgerWorksheetExt = new Rpt_GeneralLedgerWorksheetFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_GeneralLedgerWorksheetExt.Rpt_GeneralLedgerWorksheetsp(ExOptacAsOfDate,
				                                                                         ExStartingAccount,
				                                                                         ExEndingAccount,
				                                                                         ExOptacChartType,
				                                                                         TAnalyticalLedger,
				                                                                         DateOffset,
				                                                                         DisplayHeader,
				                                                                         SeparateDrCrAmounts,
				                                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
