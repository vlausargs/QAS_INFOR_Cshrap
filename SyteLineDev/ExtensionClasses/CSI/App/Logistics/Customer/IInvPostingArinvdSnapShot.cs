//PROJECT NAME: Logistics
//CLASS NAME: IInvPostingArinvdSnapShot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvPostingArinvdSnapShot
	{
		(int? ReturnCode, string Infobar) InvPostingArinvdSnapShotSp(Guid? PSessionID,
		string Infobar,
		string ToSite = null);
	}
}

