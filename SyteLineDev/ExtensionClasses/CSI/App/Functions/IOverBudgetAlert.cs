//PROJECT NAME: Data
//CLASS NAME: IOverBudgetAlert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IOverBudgetAlert
	{
		(int? ReturnCode,
			string Infobar) OverBudgetAlertSp(
			string Infobar);
	}
}

