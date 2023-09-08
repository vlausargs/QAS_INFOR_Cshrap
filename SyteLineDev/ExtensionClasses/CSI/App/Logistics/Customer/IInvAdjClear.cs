//PROJECT NAME: Logistics
//CLASS NAME: IInvAdjClear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvAdjClear
	{
		(int? ReturnCode, string Infobar) InvAdjClearSp(string CoNum,
		decimal? UserId,
		Guid? SessionID,
		string Infobar);
	}
}

