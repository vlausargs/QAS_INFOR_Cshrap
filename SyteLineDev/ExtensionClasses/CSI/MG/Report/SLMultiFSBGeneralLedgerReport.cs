//PROJECT NAME: ReportExt
//CLASS NAME: SLMultiFSBGeneralLedgerReport.cs

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
    [IDOExtensionClass("SLMultiFSBGeneralLedgerReport")]
    public class SLMultiFSBGeneralLedgerReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MultiFSBGeneralLedgerbyAccountSp([Optional] DateTime? SPerDate,
		[Optional] DateTime? EPerDate,
		[Optional] int? ShowAllTrx,
		[Optional] string SortByTrx,
		[Optional] string SecondSortBy,
		[Optional] int? ShowDetail,
		[Optional] int? AnalyticalLedger,
		[Optional] string ChartType,
		[Optional] string SAcct,
		[Optional] string EAcct,
		[Optional] string SiteGroup,
		[Optional] int? SPerDateOffset,
		[Optional] int? EPerDateOffset,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] int? DisplayHeader,
		[Optional] string PSAcctUnit1,
		[Optional] string PEAcctUnit1,
		[Optional] string PSAcctUnit2,
		[Optional] string PEAcctUnit2,
		[Optional] string PSAcctUnit3,
		[Optional] string PEAcctUnit3,
		[Optional] string PSAcctUnit4,
		[Optional] string PEAcctUnit4,
		[Optional] string FirstUnitSort,
		[Optional] string SecondUnitSort,
		[Optional] string ThirdUnitSort,
		[Optional] string FourthUnitSort,
		[Optional] string FSBName,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MultiFSBGeneralLedgerbyAccountExt = new Rpt_MultiFSBGeneralLedgerbyAccountFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MultiFSBGeneralLedgerbyAccountExt.Rpt_MultiFSBGeneralLedgerbyAccountSp(SPerDate,
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
				FirstUnitSort,
				SecondUnitSort,
				ThirdUnitSort,
				FourthUnitSort,
				FSBName,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
