//PROJECT NAME: Material
//CLASS NAME: IWhseLocItemFirstLast.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IWhseLocItemFirstLast
	{
		(int? ReturnCode,
			int? FirstOfWhse,
			int? FirstOfLoc,
			int? FirstOfItem,
			int? LastOfWhse,
			int? LastOfLoc,
			int? LastOfItem) WhseLocItemFirstLastSp(
			int? FETCH_STATUS,
			string Whse,
			string Loc,
			string Item,
			string LastWhse,
			string LastLoc,
			string LastItem,
			int? FirstOfWhse,
			int? FirstOfLoc,
			int? FirstOfItem,
			int? LastOfWhse,
			int? LastOfLoc,
			int? LastOfItem);
	}
}

