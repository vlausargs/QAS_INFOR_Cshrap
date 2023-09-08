//PROJECT NAME: Logistics
//CLASS NAME: IInvPostingLockJourn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvPostingLockJourn
	{
		(int? ReturnCode, Guid? PJHeaderRowPointer,
		string Infobar) InvPostingLockJournSp(Guid? PSessionID,
		decimal? PUserID,
		Guid? PJHeaderRowPointer,
		string Infobar,
		string ToSite = null,
		int? LockJournal = 1);
	}
}

