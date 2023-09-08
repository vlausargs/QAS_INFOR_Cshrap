//PROJECT NAME: Data
//CLASS NAME: IItemQtySerialValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemQtySerialValid
	{
		(int? ReturnCode,
			string Infobar) ItemQtySerialValidSp(
			string Item,
			decimal? Qty,
			string Infobar,
			string Site = null);
	}
}

