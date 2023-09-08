//PROJECT NAME: Material
//CLASS NAME: IASNUpdateValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IASNUpdateValue
	{
		(int? ReturnCode, decimal? PValueAmount) ASNUpdateValueSp(string PTrnNum,
		string PBolNum,
		decimal? PValueAmount);
	}
}

