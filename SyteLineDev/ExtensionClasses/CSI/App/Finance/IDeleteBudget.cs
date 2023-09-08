//PROJECT NAME: Finance
//CLASS NAME: IDeleteBudget.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IDeleteBudget
	{
		(int? ReturnCode, string Infobar) DeleteBudgetSp(int? FiscalYear,
		string Infobar);
	}
}

