//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSUpdateCHSPertot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface IEXTCHSUpdateCHSPertot
	{
		(int? ReturnCode,
			string InfoBar) EXTCHSUpdateCHSPertotSp(
			decimal? pLedgerDomAmount,
			string pLedgerRef,
			int? pPerSortMethod,
			string pCurrency,
			string pLedgerHierarchy,
			string pSF1,
			string pSF2,
			string pSF3,
			string pSF4,
			string pSF5,
			DateTime? pLedgerTransDate,
			decimal? pTransNum,
			decimal? pLedgerExchRate,
			string InfoBar);
	}
}

