//PROJECT NAME: Logistics
//CLASS NAME: IARFinChgPostLockJourn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARFinChgPostLockJourn
	{
		(int? ReturnCode, Guid? PJHeaderRowPointer,
		string Infobar) ARFinChgPostLockJournSp(Guid? PSessionID,
		decimal? PUserID,
		Guid? PJHeaderRowPointer,
		string Infobar);
	}
}

