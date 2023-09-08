//PROJECT NAME: Logistics
//CLASS NAME: IVoidAppmtChecksToPrintPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoidAppmtChecksToPrintPost
	{
		(int? ReturnCode, string Infobar) VoidAppmtChecksToPrintPostSp(Guid? PSessionID,
		decimal? PUserID,
		string PPayCode,
		string PBankCode,
		string Infobar);
	}
}

