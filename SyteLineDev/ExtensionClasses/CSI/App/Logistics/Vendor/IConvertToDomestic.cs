//PROJECT NAME: Logistics
//CLASS NAME: IConvertToDomestic.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IConvertToDomestic
	{
		(int? ReturnCode, decimal? PPlanCostDom,
		string Infobar) ConvertToDomesticSp(string PVendNum,
		string PCurrCode,
		decimal? PPlanCostDom,
		string Infobar);
	}
}

