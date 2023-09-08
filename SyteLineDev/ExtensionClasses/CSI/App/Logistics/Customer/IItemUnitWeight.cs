//PROJECT NAME: Logistics
//CLASS NAME: IItemUnitWeight.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IItemUnitWeight
	{
		(int? ReturnCode, decimal? PUnitWeight,
		string Infobar) ItemUnitWeightSp(string PItem,
		decimal? PUnitWeight,
		string Infobar);
	}
}

