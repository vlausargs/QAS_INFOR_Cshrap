//PROJECT NAME: Logistics
//CLASS NAME: IARFinanceChargePostBG.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARFinanceChargePostBG
	{
		int? ARFinanceChargePostBGSp(string pStartingCustNum = null,
		string pEndingCustNum = null,
		int? pDisplayHeader = null,
		string pSessionIdChar = null,
		DateTime? pCutoffDate = null,
		int? pCutoffDateOffset = null,
		string pSite = null,
		decimal? pUserId = null);
	}
}

