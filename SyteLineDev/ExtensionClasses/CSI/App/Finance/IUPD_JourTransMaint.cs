//PROJECT NAME: Finance
//CLASS NAME: IUPD_JourTransMaint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IUPD_JourTransMaint
	{
		int? UPD_JourTransMaintSp(string pJournalId,
		int? pSeq,
		DateTime? pTransDate,
		string pAcct,
		string pAcctUnit1,
		string pAcctUnit2,
		string pAcctUnit3,
		string pAcctUnit4,
		decimal? pDomAmount);
	}
}

