//PROJECT NAME: Logistics
//CLASS NAME: IGetEcvt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetEcvt
	{
		(int? ReturnCode, string EcCode,
		string Transport,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		string ShipSite) GetEcvtSp(string CustNum,
		int? CustSeq,
		string Shipcode,
		string EcCode,
		string Transport,
		int? SupplQtyReq = 0,
		decimal? SupplQtyConvFactor = 1M,
		string CoLcrNum = null,
		string ShipSite = null);
	}
}

