//PROJECT NAME: Data
//CLASS NAME: ITH_GetBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITH_GetBalance
	{
		(int? ReturnCode,
			decimal? Qty,
			decimal? Amount,
			string Infobar) TH_GetBalanceSp(
			DateTime? PeriodEnding,
			string pItem,
			string pWhse,
			string pLoc,
			string pLot,
			decimal? Qty,
			decimal? Amount,
			string Infobar);
	}
}

