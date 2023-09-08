//PROJECT NAME: Data
//CLASS NAME: IGetWksValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetWksValue
	{
		decimal? GetWksValueFn(
			string CoNum);
	}
}

