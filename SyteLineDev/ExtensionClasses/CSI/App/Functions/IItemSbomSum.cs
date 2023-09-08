//PROJECT NAME: Data
//CLASS NAME: IItemSbomSum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemSbomSum
	{
		(int? ReturnCode,
			string Infobar) ItemSbomSumSp(
			string CurItem,
			string Infobar,
			int? FromTemp = null,
			int? FromJobmatlTemp = null);
	}
}

