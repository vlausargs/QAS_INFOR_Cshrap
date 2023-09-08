//PROJECT NAME: Finance
//CLASS NAME: IExternalFinancialChk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExternalFinancialChk
	{
		(int? ReturnCode, int? ExtFinEnabled,
		int? ExtFinUseExternalAR,
		string ExtFinExtFinancial,
		string Infobar) ExternalFinancialChkSp(int? ExtFinEnabled,
		int? ExtFinUseExternalAR,
		string ExtFinExtFinancial,
		string Infobar);
	}
}

