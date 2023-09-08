//PROJECT NAME: POS
//CLASS NAME: ISSSPOSConPosP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSConPosP
	{
		(int? ReturnCode, string Infobar) SSSPOSConPosPSp(Guid? SessionId = null,
		string RequestingUser = null,
		decimal? UserID = null,
		string CalledFromForm = "POSCheckoutCheckin",
		string PartnerId = null,
		string Drawer = null,
		string Contract = null,
		DateTime? BilledThruDate = null,
		string InvNum = null,
		int? InvSeq = null,
		string InvCred = null,
		string Infobar = null);
	}
}

