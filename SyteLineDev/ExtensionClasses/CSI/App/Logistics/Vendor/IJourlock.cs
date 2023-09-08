//PROJECT NAME: Logistics
//CLASS NAME: IJourlock.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IJourlock
	{
		(int? ReturnCode, string Infobar) JourlockSp(string Id,
		decimal? LockUserid,
		int? LockJournal,
		string Infobar);
	}
}

