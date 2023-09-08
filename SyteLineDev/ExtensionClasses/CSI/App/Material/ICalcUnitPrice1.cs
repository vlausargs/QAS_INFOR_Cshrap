//PROJECT NAME: Material
//CLASS NAME: ICalcUnitPrice1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICalcUnitPrice1
	{
		(int? ReturnCode, decimal? PUnitPrice1,
		decimal? UnitCost,
		string Prodcode,
		string Pricecode,
		string PricecodeDesc,
		decimal? CurUCost) CalcUnitPrice1Sp(string PCurrCode,
		decimal? PUnitPrice1,
		string PItem = null,
		decimal? UnitCost = null,
		string Prodcode = null,
		string Pricecode = null,
		string PricecodeDesc = null,
		decimal? CurUCost = null);
	}
}

