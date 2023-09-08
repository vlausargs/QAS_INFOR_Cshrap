//PROJECT NAME: Material
//CLASS NAME: IMrpWbGetTransferInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpWbGetTransferInfo
	{
		(int? ReturnCode, string FromSite,
		string FromWhse,
		string ToWhse,
		decimal? UnitCost,
		int? LeadTime,
		string Infobar) MrpWbGetTransferInfoSp(string TrnNum,
		string Item,
		string FromSite,
		string FromWhse,
		string ToWhse,
		decimal? UnitCost,
		int? LeadTime,
		string Infobar);
	}
}

