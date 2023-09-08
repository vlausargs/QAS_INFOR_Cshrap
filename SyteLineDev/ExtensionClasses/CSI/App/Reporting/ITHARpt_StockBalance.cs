//PROJECT NAME: Reporting
//CLASS NAME: ITHARpt_StockBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ITHARpt_StockBalance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THARpt_StockBalanceSp(DateTime? pStartDate = null,
		DateTime? pEndDate = null,
		string pStartItem = null,
		string pEndItem = null,
		string pWhseStarting = null,
		string pWhseEnding = null,
		string pLocStarting = null,
		string pLocEnding = null,
		int? pSumDtl = 0,
		string pSite = null);
	}
}

