//PROJECT NAME: Reporting
//CLASS NAME: GlBudgetConsbpCvtLgrAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class GlBudgetConsbpCvtLgrAmt : IGlBudgetConsbpCvtLgrAmt
	{
		readonly IApplicationDB appDB;
		
		public GlBudgetConsbpCvtLgrAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string rInfobar)
		{
			CurrCodeType _pCurrparmsCurrCode = pCurrparmsCurrCode;
			DateType _pTPerStartDate = pTPerStartDate;
			DateType _pTPerEndDate = pTPerEndDate;
			RowPointerType _pWHierarchyRowpointer = pWHierarchyRowpointer;
			SiteType _pWHierarchySite = pWHierarchySite;
			CurrCodeType _pWHierarchyCurrCode = pWHierarchyCurrCode;
			ListBuySellType _pWHierarchyTgUseBuyRate = pWHierarchyTgUseBuyRate;
			CurrTransMethodType _pWHierarchyTgTransMethod = pWHierarchyTgTransMethod;
			DateType _pWHierarchyTgCurrentDate = pWHierarchyTgCurrentDate;
			CurrTransMethodType _pWHierarchyTgOldMethod = pWHierarchyTgOldMethod;
			ListBuySellType _pWHierarchyTgOldUseBuy = pWHierarchyTgOldUseBuy;
			DateType _pWHierarchyTgOldDate = pWHierarchyTgOldDate;
			AmountType _pAmount = pAmount;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlBudgetConsbpCvtLgrAmtSp";
				
				appDB.AddCommandParameter(cmd, "pCurrparmsCurrCode", _pCurrparmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTPerStartDate", _pTPerStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTPerEndDate", _pTPerEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWHierarchyRowpointer", _pWHierarchyRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWHierarchySite", _pWHierarchySite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWHierarchyCurrCode", _pWHierarchyCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWHierarchyTgUseBuyRate", _pWHierarchyTgUseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWHierarchyTgTransMethod", _pWHierarchyTgTransMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWHierarchyTgCurrentDate", _pWHierarchyTgCurrentDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWHierarchyTgOldMethod", _pWHierarchyTgOldMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pWHierarchyTgOldUseBuy", _pWHierarchyTgOldUseBuy, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pWHierarchyTgOldDate", _pWHierarchyTgOldDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pAmount", _pAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pWHierarchyTgOldMethod = _pWHierarchyTgOldMethod;
				pWHierarchyTgOldUseBuy = _pWHierarchyTgOldUseBuy;
				pWHierarchyTgOldDate = _pWHierarchyTgOldDate;
				pAmount = _pAmount;
				rInfobar = _rInfobar;
				
				return (Severity, pWHierarchyTgOldMethod, pWHierarchyTgOldUseBuy, pWHierarchyTgOldDate, pAmount, rInfobar);
			}
		}
	}
}
