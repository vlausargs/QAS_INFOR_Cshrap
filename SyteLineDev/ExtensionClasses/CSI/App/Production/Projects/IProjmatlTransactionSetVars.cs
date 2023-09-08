//PROJECT NAME: Production
//CLASS NAME: IProjmatlTransactionSetVars.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjmatlTransactionSetVars
	{
		(int? ReturnCode, int? TSeqNum,
		string Infobar) ProjmatlTransactionSetVarsSp(string SET,
		string PProjNum,
		int? PTaskNum,
		int? PSeqNum,
		string PItem,
		string PItemDesc,
		decimal? PQty,
		decimal? PQtyConv,
		string PUM,
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
		int? CreateMatl,
		int? TSeqNum,
		string Infobar,
		string PImportDocId1,
		string DocumentNum = null);
	}
}

