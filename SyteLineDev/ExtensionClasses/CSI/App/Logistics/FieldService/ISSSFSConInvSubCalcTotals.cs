//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubCalcTotals.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubCalcTotals
	{
		(int? ReturnCode, decimal? oSubTotal,
		decimal? oTotSurcharge,
		decimal? oTotWaiver,
		decimal? oSalesTax1,
		decimal? oSalesTax2,
		decimal? oTotBilled,
		decimal? oBalance,
		decimal? oPayments,
		string Infobar) SSSFSConInvSubCalcTotalsSp(Guid? SessionId,
		string iContract,
		DateTime? iInvDate,
		string iInvNum,
		string iMode = null,
		decimal? oSubTotal = null,
		decimal? oTotSurcharge = null,
		decimal? oTotWaiver = null,
		decimal? oSalesTax1 = null,
		decimal? oSalesTax2 = null,
		decimal? oTotBilled = null,
		decimal? oBalance = null,
		decimal? oPayments = null,
		string Infobar = null);
	}
}

