//PROJECT NAME: DataCollection
//CLASS NAME: IDccoP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccoP
	{
		(int? ReturnCode, string Infobar) DccoPSp(int? FromEdi = 0,
		decimal? ProcessId = null,
		DateTime? PostDate = null,
		string Infobar = null,
		string DocumentNum = null);
	}
}

