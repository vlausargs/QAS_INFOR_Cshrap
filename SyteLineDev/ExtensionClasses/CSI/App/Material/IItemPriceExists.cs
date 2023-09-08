//PROJECT NAME: Material
//CLASS NAME: IItemPriceExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemPriceExists
	{
		(int? ReturnCode, string Infobar) ItemPriceExistsSp(string Item,
		string Infobar,
		string Site = null);
	}
}

