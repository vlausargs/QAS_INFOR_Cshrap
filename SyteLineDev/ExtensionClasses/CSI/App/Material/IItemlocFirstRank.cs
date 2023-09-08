//PROJECT NAME: Material
//CLASS NAME: IItemlocFirstRank.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemlocFirstRank
	{
		(int? ReturnCode, string Loc) ItemlocFirstRankSp(string Item,
		string Whse,
		string Site = null,
		string Loc = null);
	}
}

