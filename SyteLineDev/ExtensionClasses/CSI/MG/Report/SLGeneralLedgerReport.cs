//PROJECT NAME: ReportExt
//CLASS NAME: SLGeneralLedgerReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.Data.RecordSets;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLGeneralLedgerReport")]
    public class SLGeneralLedgerReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_GeneralLedgerbyAccountSp([Optional] DateTime? SPerDate,
		                                              [Optional] DateTime? EPerDate,
		                                              [Optional] byte? ShowAllTrx,
		                                              [Optional] string SortByTrx,
		                                              [Optional] string SecondSortBy,
		                                              [Optional] byte? ShowDetail,
		                                              [Optional] byte? AnalyticalLedger,
		                                              [Optional] string ChartType,
		                                              [Optional] string SAcct,
		                                              [Optional] string EAcct,
		                                              [Optional] string SiteGroup,
		                                              [Optional] short? SPerDateOffset,
		                                              [Optional] short? EPerDateOffset,
		                                              [Optional] byte? ShowInternal,
		                                              [Optional] byte? ShowExternal,
		                                              [Optional] byte? DisplayHeader,
		                                              [Optional] string PSAcctUnit1,
		                                              [Optional] string PEAcctUnit1,
		                                              [Optional] string PSAcctUnit2,
		                                              [Optional] string PEAcctUnit2,
		                                              [Optional] string PSAcctUnit3,
		                                              [Optional] string PEAcctUnit3,
		                                              [Optional] string PSAcctUnit4,
		                                              [Optional] string PEAcctUnit4,
		                                              [Optional] byte? SeparateDrCrAmounts,
		                                              [Optional] string pSite,
		                                              [Optional] string FirstUnitSort,
		                                              [Optional] string SecondUnitSort,
		                                              [Optional] string ThirdUnitSort,
		                                              [Optional] string FourthUnitSort)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_GeneralLedgerbyAccountExt = new Rpt_GeneralLedgerbyAccountFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_GeneralLedgerbyAccountExt.Rpt_GeneralLedgerbyAccountSp(SPerDate,
				                                                                         EPerDate,
				                                                                         ShowAllTrx,
				                                                                         SortByTrx,
				                                                                         SecondSortBy,
				                                                                         ShowDetail,
				                                                                         AnalyticalLedger,
				                                                                         ChartType,
				                                                                         SAcct,
				                                                                         EAcct,
				                                                                         SiteGroup,
				                                                                         SPerDateOffset,
				                                                                         EPerDateOffset,
				                                                                         ShowInternal,
				                                                                         ShowExternal,
				                                                                         DisplayHeader,
				                                                                         PSAcctUnit1,
				                                                                         PEAcctUnit1,
				                                                                         PSAcctUnit2,
				                                                                         PEAcctUnit2,
				                                                                         PSAcctUnit3,
				                                                                         PEAcctUnit3,
				                                                                         PSAcctUnit4,
				                                                                         PEAcctUnit4,
				                                                                         SeparateDrCrAmounts,
				                                                                         pSite,
				                                                                         FirstUnitSort,
				                                                                         SecondUnitSort,
				                                                                         ThirdUnitSort,
				                                                                         FourthUnitSort);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
