//PROJECT NAME: Logistics
//CLASS NAME: IAPVchPostingAptrxdSnapShot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAPVchPostingAptrxdSnapShot
	{
		(int? ReturnCode, string Infobar) APVchPostingAptrxdSnapShotSp(Guid? PSessionID,
		string Infobar);
	}
}

