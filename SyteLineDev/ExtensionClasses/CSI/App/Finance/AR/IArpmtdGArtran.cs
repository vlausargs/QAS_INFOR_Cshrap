//PROJECT NAME: Finance
//CLASS NAME: IArpmtdGArtran.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtdGArtran
	{
		(int? ReturnCode,
			decimal? ExchRate,
			int? UpdateExchRate,
			string Infobar) ArpmtdGArtranSp(
			string SiteRef,
			string CustNum,
			string InvNum,
			int? SetActive,
			int? AddMode,
			decimal? ArpmtdExchRate,
			decimal? ArpmtExchRate,
			decimal? ExchRate,
			int? UpdateExchRate,
			string Infobar);
	}
}

