//PROJECT NAME: Reporting
//CLASS NAME: ICHSRpt_OutputLedger.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ICHSRpt_OutputLedger
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_OutputLedgerSp(DateTime? BegTransDate = null,
		DateTime? EndTransDate = null,
		decimal? BegTransNum = null,
		decimal? EndTransNum = null,
		string JournalId = null,
		string pSite = null);
	}
}

