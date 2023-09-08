//PROJECT NAME: Data
//CLASS NAME: IGetBaseQuantity.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetBaseQuantity
	{
		(int? ReturnCode,
			decimal? QtyInBase,
			string Infobar) GetBaseQuantitySp(
			string UM,
			string Item,
			string CustNum,
			decimal? QtyConv,
			decimal? QtyInBase,
			string Infobar,
			string Site = null);
	}
}

