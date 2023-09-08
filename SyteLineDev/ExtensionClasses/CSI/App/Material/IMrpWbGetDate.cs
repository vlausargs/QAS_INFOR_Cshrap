//PROJECT NAME: Material
//CLASS NAME: IMrpWbGetDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpWbGetDate
	{
		(int? ReturnCode, DateTime? ReleaseDate,
		string Infobar) MrpWbGetDateSp(string RefTab,
		string Item,
		string SupplySite,
		decimal? ReqdQty,
		DateTime? DueDate,
		DateTime? ReleaseDate,
		string Infobar);
	}
}

