//PROJECT NAME: MG
//CLASS NAME: SLGeneralLedgerCheckInformationReport.cs

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
	[IDOExtensionClass("SLGeneralLedgerCheckInformationReport")]
	public class SLGeneralLedgerCheckInformationReport : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_GeneralLedgerCheckInformationSp([Optional] string AccountStarting,
			[Optional] string AccountEnding,
			[Optional] string PrintTrxText,
			[Optional] int? AnalyticalLedger,
			[Optional] string AcctUnit1Starting,
			[Optional] string AcctUnit1Ending,
			[Optional] string AcctUnit2Starting,
			[Optional] string AcctUnit2Ending,
			[Optional] string AcctUnit3Starting,
			[Optional] string AcctUnit3Ending,
			[Optional] string AcctUnit4Starting,
			[Optional] string AcctUnit4Ending,
			[Optional] DateTime? TransDateStarting,
			[Optional] DateTime? TransDateEnding,
			[Optional] string RefStarting,
			[Optional] string RefEnding,
			[Optional] string VendNumStarting,
			[Optional] string VendNumEnding,
			[Optional] string VoucherStarting,
			[Optional] string VoucherEnding,
			[Optional] DateTime? CheckDateStarting,
			[Optional] DateTime? CheckDateEnding,
			[Optional] int? CheckNumStarting,
			[Optional] int? CheckNumEnding,
			[Optional] decimal? TransNumStarting,
			[Optional] decimal? TransNumEnding,
			[Optional] int? TransDateStartingOffset,
			[Optional] int? TransDateEndingOffset,
			[Optional] int? CheckDateStartingOffset,
			[Optional] int? CheckDateEndingOffset,
			[Optional] int? ShowInternal,
			[Optional] int? ShowExternal,
			[Optional] int? DisplayHeader,
			[Optional] string pSite)
		{
			var iRpt_GeneralLedgerCheckInformationExt = new Rpt_GeneralLedgerCheckInformationFactory().Create(this, true);

			var result = iRpt_GeneralLedgerCheckInformationExt.Rpt_GeneralLedgerCheckInformationSp(AccountStarting,
				AccountEnding,
				PrintTrxText,
				AnalyticalLedger,
				AcctUnit1Starting,
				AcctUnit1Ending,
				AcctUnit2Starting,
				AcctUnit2Ending,
				AcctUnit3Starting,
				AcctUnit3Ending,
				AcctUnit4Starting,
				AcctUnit4Ending,
				TransDateStarting,
				TransDateEnding,
				RefStarting,
				RefEnding,
				VendNumStarting,
				VendNumEnding,
				VoucherStarting,
				VoucherEnding,
				CheckDateStarting,
				CheckDateEnding,
				CheckNumStarting,
				CheckNumEnding,
				TransNumStarting,
				TransNumEnding,
				TransDateStartingOffset,
				TransDateEndingOffset,
				CheckDateStartingOffset,
				CheckDateEndingOffset,
				ShowInternal,
				ShowExternal,
				DisplayHeader,
				pSite);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
	}
}
