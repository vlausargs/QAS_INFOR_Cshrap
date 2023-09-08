//PROJECT NAME: THLOC
//CLASS NAME: ITHACreateStockBalanceCons.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.THLOC
{
	public interface ITHACreateStockBalanceCons
	{
		(int? ReturnCode, string Infobar) THACreateStockBalanceConsSp(DateTime? pStartDate,
		DateTime? pEndDate,
		string pStartItem,
		string pEndItem,
		string pWhseStarting,
		string pWhseEnding,
		string pLocStarting,
		string pLocEnding,
		string Infobar);
	}
}

