//PROJECT NAME: Logistics
//CLASS NAME: IARPayPostLockJour.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARPayPostLockJour
	{
		(int? ReturnCode, string Infobar) ARPayPostLockJourSp(Guid? PSessionID,
		decimal? PUserID,
		string Infobar);
	}
}

