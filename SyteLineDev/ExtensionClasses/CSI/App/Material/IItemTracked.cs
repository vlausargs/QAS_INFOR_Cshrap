//PROJECT NAME: Material
//CLASS NAME: IItemTracked.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemTracked
	{
		(int? ReturnCode, int? SerialTracked,
		int? LotTracked,
		string Infobar) ItemTrackedSp(string Item,
		int? SerialTracked,
		int? LotTracked,
		string Infobar);
	}
}

