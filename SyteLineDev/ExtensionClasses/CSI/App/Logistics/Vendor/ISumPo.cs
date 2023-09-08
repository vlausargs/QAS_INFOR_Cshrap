//PROJECT NAME: Logistics
//CLASS NAME: ISumPo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ISumPo
	{
		(int? ReturnCode, string Infobar) SumPoSp(string PoNum,
		string Infobar,
		int? CurrencyPlaces = null,
		string PoVendLcrNum = null,
		string PoVendNum = null);
	}
}

