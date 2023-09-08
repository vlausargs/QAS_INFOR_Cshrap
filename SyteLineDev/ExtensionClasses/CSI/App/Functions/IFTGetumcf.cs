//PROJECT NAME: Data
//CLASS NAME: IFTGetumcf.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTGetumcf
	{
		decimal? FTGetumcfFn(
			string OtherUM,
			string Item,
			string VendNum,
			string Area);
	}
}

