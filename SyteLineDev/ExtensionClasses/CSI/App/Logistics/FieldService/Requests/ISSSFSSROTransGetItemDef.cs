//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransGetItemDef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransGetItemDef
	{
		(int? ReturnCode,
		string Origin,
		string CommCode,
		decimal? UnitWeight) SSSFSSROTransGetItemDefSp(
			string MatlItem,
			string Origin,
			string CommCode,
			decimal? UnitWeight);
	}
}

