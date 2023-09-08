//PROJECT NAME: Reporting
//CLASS NAME: IGLBudgetConsbpPerMap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IGLBudgetConsbpPerMap
	{
		(int? ReturnCode,
			string rInfobar) GLBudgetConsbpPerMapSp(
			string pParmsSite,
			string pTgHierarchy,
			string rInfobar);
	}
}

