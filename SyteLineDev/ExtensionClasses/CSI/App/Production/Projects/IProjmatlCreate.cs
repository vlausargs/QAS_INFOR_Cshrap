//PROJECT NAME: Production
//CLASS NAME: IProjmatlCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjmatlCreate
	{
		(int? ReturnCode, int? TSeqNum,
		string Infobar) ProjmatlCreateSp(string TProjNum,
		int? TTaskNum,
		string TCostCode,
		string TItem,
		string TItemDesc,
		decimal? TQty,
		decimal? TQtyConv,
		string TUM,
		string TWhse,
		decimal? TNonInvCost,
		int? TSeqNum,
		string Infobar);
	}
}

