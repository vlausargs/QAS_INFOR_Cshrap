//PROJECT NAME: Data
//CLASS NAME: IItemLowLvl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemLowLvl
	{
		(int? ReturnCode,
			int? Sequence,
			string Infobar) ItemLowLvlSp(
			int? LowLevel,
			string Job,
			int? Suffix,
			int? ListAfter,
			int? FromItemLow,
			string RootItem,
			int? Sequence,
			string Infobar);
	}
}

