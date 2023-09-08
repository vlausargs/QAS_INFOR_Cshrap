//PROJECT NAME: Logistics
//CLASS NAME: ICalcUpdCOFreightCharge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICalcUpdCOFreightCharge
	{
		(int? ReturnCode, decimal? COFreightChargeAmt,
		string Infobar) CalcUpdCOFreightChargeSp(string CoNum,
		string COShipMethod = null,
		decimal? COFreightChargeAmt = 0,
		string CalledByCO = null,
		string Infobar = null);
	}
}

