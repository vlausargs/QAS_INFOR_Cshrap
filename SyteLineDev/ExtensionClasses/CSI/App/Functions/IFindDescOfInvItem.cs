//PROJECT NAME: Data
//CLASS NAME: IFindDescOfInvItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFindDescOfInvItem
	{
		string FindDescOfInvItemFn(
			string TCoNum,
			int? TCoLine,
			int? TCoRelease,
			string TItem);
	}
}

