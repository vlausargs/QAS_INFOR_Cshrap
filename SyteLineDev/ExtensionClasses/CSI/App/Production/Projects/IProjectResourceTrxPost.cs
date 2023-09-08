//PROJECT NAME: Production
//CLASS NAME: IProjectResourceTrxPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjectResourceTrxPost
	{
		(int? ReturnCode, string Infobar) ProjectResourceTrxPostSp(string PProjNum,
		int? PTaskNum,
		int? PSeqNum,
		string PItem,
		decimal? PQty,
		string CurWhse,
		string PCostCode,
		string PLoc1,
		string PLot1,
		DateTime? PTransDate,
		string PTranType,
		string PNonInvAcct,
		string PNonInvAcctUnit1,
		string PNonInvAcctUnit2,
		string PNonInvAcctUnit3,
		string PNonInvAcctUnit4,
		decimal? PNonInvCost,
		string PPoNum,
		int? PPoLine,
		int? PPoRel,
		string PRefType,
		string CallArg = "",
		string ControlPrefix = null,
		string ControlSite = null,
		int? ControlYear = null,
		int? ControlPeriod = null,
		decimal? ControlNumber = null,
		string Infobar = null,
		string PImportDocId1 = null,
		string DocumentNum = null);
	}
}

