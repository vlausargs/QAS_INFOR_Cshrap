//PROJECT NAME: Reporting
//CLASS NAME: IRpt_GeneralLedgerCheckInformationCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_GeneralLedgerCheckInformationCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		string Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_GeneralLedgerCheckInformationSp(string AltExtGenSp, string AccountStarting, string AccountEnding, string PrintTrxText, int? AnalyticalLedger, string AcctUnit1Starting, string AcctUnit1Ending, string AcctUnit2Starting, string AcctUnit2Ending, string AcctUnit3Starting, string AcctUnit3Ending, string AcctUnit4Starting, string AcctUnit4Ending, DateTime? TransDateStarting, DateTime? TransDateEnding, string RefStarting, string RefEnding, string VendNumStarting, string VendNumEnding, string VoucherStarting, string VoucherEnding, DateTime? CheckDateStarting, DateTime? CheckDateEnding, int? CheckNumStarting, int? CheckNumEnding, decimal? TransNumStarting, decimal? TransNumEnding, int? TransDateStartingOffset, int? TransDateEndingOffset, int? CheckDateStartingOffset, int? CheckDateEndingOffset, int? ShowInternal, int? ShowExternal, int? DisplayHeader, string pSite);
	}
}

