//PROJECT NAME: Logistics
//CLASS NAME: ICreateFixedAssetCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICreateFixedAssetCost
	{
		(int? ReturnCode,
			string Infobar) CreateFixedAssetCostSp(
			string FaNum,
			string VendNum,
			decimal? Amount,
			string PoNum,
			int? PoLine,
			string Infobar);
	}
}

