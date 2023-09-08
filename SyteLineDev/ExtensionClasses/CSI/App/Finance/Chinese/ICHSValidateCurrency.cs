//PROJECT NAME: Finance
//CLASS NAME: ICHSValidateCurrency.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSValidateCurrency
	{
		(int? ReturnCode,
			string Amt_Format,
			string Infobar) CHSValidateCurrencySp(
			string CurrCode,
			DateTime? TransDate,
			decimal? ExchRate,
			string Amt_Format,
			string Infobar);
	}
}

