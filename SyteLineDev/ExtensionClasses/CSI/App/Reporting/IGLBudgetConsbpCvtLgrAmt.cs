//PROJECT NAME: Reporting
//CLASS NAME: IGlBudgetConsbpCvtLgrAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IGlBudgetConsbpCvtLgrAmt
	{
		(int? ReturnCode,
			string pWHierarchyTgOldMethod,
			int? pWHierarchyTgOldUseBuy,
			DateTime? pWHierarchyTgOldDate,
			decimal? pAmount,
			string rInfobar) GlBudgetConsbpCvtLgrAmtSp(
			string pCurrparmsCurrCode,
			DateTime? pTPerStartDate,
			DateTime? pTPerEndDate,
			Guid? pWHierarchyRowpointer,
			string pWHierarchySite,
			string pWHierarchyCurrCode,
			int? pWHierarchyTgUseBuyRate,
			string pWHierarchyTgTransMethod,
			DateTime? pWHierarchyTgCurrentDate,
			string pWHierarchyTgOldMethod,
			int? pWHierarchyTgOldUseBuy,
			DateTime? pWHierarchyTgOldDate,
			decimal? pAmount,
			string rInfobar);
	}
}

