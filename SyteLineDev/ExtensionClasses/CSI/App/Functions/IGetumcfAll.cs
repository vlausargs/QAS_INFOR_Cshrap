//PROJECT NAME: Data
//CLASS NAME: IGetumcfAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetumcfAll
	{
		decimal? GetumcfAllFn(
			string OtherUM,
			string Item,
			string VendNum,
			string Area,
			string Site = null);
	}
}

