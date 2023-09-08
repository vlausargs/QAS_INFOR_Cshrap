//PROJECT NAME: Data
//CLASS NAME: IGetSaleSumbyItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetSaleSumbyItem
	{
		(int? ReturnCode,
			decimal? Price,
			decimal? Qty) GetSaleSumbyItemSp(
			string Item,
			DateTime? RefDate,
			DateTime? SaleSumRefDate,
			int? SaleSumRefBucket,
			decimal? Price,
			decimal? Qty);
	}
}

