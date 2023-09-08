//PROJECT NAME: Reporting
//CLASS NAME: GLBudgetConsChartBpUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class GLBudgetConsChartBpUpdate : IGLBudgetConsChartBpUpdate
	{
		readonly IApplicationDB appDB;
		
		public GLBudgetConsChartBpUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GLBudgetConsChartBpUpdateSp(
			string pAcct,
			string pUnit1,
			string pUnit2,
			string pUnit3,
			string pUnit4,
			int? pChartBpFiscalYear,
			string pHierarchy,
			string Infobar,
			int? Period,
			decimal? ChartBpBudget__1,
			decimal? ChartBpBudget__2,
			decimal? ChartBpBudget__3,
			decimal? ChartBpBudget__4,
			decimal? ChartBpBudget__5,
			decimal? ChartBpBudget__6,
			decimal? ChartBpBudget__7,
			decimal? ChartBpBudget__8,
			decimal? ChartBpBudget__9,
			decimal? ChartBpBudget__10,
			decimal? ChartBpBudget__11,
			decimal? ChartBpBudget__12,
			decimal? ChartBpBudget__13,
			decimal? ChartBpPlan__1,
			decimal? ChartBpPlan__2,
			decimal? ChartBpPlan__3,
			decimal? ChartBpPlan__4,
			decimal? ChartBpPlan__5,
			decimal? ChartBpPlan__6,
			decimal? ChartBpPlan__7,
			decimal? ChartBpPlan__8,
			decimal? ChartBpPlan__9,
			decimal? ChartBpPlan__10,
			decimal? ChartBpPlan__11,
			decimal? ChartBpPlan__12,
			decimal? ChartBpPlan__13,
			decimal? ChartBpActual__1,
			decimal? ChartBpActual__2,
			decimal? ChartBpActual__3,
			decimal? ChartBpActual__4,
			decimal? ChartBpActual__5,
			decimal? ChartBpActual__6,
			decimal? ChartBpActual__7,
			decimal? ChartBpActual__8,
			decimal? ChartBpActual__9,
			decimal? ChartBpActual__10,
			decimal? ChartBpActual__11,
			decimal? ChartBpActual__12,
			decimal? ChartBpActual__13,
			Guid? SessionID)
		{
			AcctType _pAcct = pAcct;
			UnitCode1Type _pUnit1 = pUnit1;
			UnitCode2Type _pUnit2 = pUnit2;
			UnitCode3Type _pUnit3 = pUnit3;
			UnitCode4Type _pUnit4 = pUnit4;
			FiscalYearType _pChartBpFiscalYear = pChartBpFiscalYear;
			HierarchyType _pHierarchy = pHierarchy;
			InfobarType _Infobar = Infobar;
			FinPeriodType _Period = Period;
			AmountType _ChartBpBudget__1 = ChartBpBudget__1;
			AmountType _ChartBpBudget__2 = ChartBpBudget__2;
			AmountType _ChartBpBudget__3 = ChartBpBudget__3;
			AmountType _ChartBpBudget__4 = ChartBpBudget__4;
			AmountType _ChartBpBudget__5 = ChartBpBudget__5;
			AmountType _ChartBpBudget__6 = ChartBpBudget__6;
			AmountType _ChartBpBudget__7 = ChartBpBudget__7;
			AmountType _ChartBpBudget__8 = ChartBpBudget__8;
			AmountType _ChartBpBudget__9 = ChartBpBudget__9;
			AmountType _ChartBpBudget__10 = ChartBpBudget__10;
			AmountType _ChartBpBudget__11 = ChartBpBudget__11;
			AmountType _ChartBpBudget__12 = ChartBpBudget__12;
			AmountType _ChartBpBudget__13 = ChartBpBudget__13;
			AmountType _ChartBpPlan__1 = ChartBpPlan__1;
			AmountType _ChartBpPlan__2 = ChartBpPlan__2;
			AmountType _ChartBpPlan__3 = ChartBpPlan__3;
			AmountType _ChartBpPlan__4 = ChartBpPlan__4;
			AmountType _ChartBpPlan__5 = ChartBpPlan__5;
			AmountType _ChartBpPlan__6 = ChartBpPlan__6;
			AmountType _ChartBpPlan__7 = ChartBpPlan__7;
			AmountType _ChartBpPlan__8 = ChartBpPlan__8;
			AmountType _ChartBpPlan__9 = ChartBpPlan__9;
			AmountType _ChartBpPlan__10 = ChartBpPlan__10;
			AmountType _ChartBpPlan__11 = ChartBpPlan__11;
			AmountType _ChartBpPlan__12 = ChartBpPlan__12;
			AmountType _ChartBpPlan__13 = ChartBpPlan__13;
			AmountType _ChartBpActual__1 = ChartBpActual__1;
			AmountType _ChartBpActual__2 = ChartBpActual__2;
			AmountType _ChartBpActual__3 = ChartBpActual__3;
			AmountType _ChartBpActual__4 = ChartBpActual__4;
			AmountType _ChartBpActual__5 = ChartBpActual__5;
			AmountType _ChartBpActual__6 = ChartBpActual__6;
			AmountType _ChartBpActual__7 = ChartBpActual__7;
			AmountType _ChartBpActual__8 = ChartBpActual__8;
			AmountType _ChartBpActual__9 = ChartBpActual__9;
			AmountType _ChartBpActual__10 = ChartBpActual__10;
			AmountType _ChartBpActual__11 = ChartBpActual__11;
			AmountType _ChartBpActual__12 = ChartBpActual__12;
			AmountType _ChartBpActual__13 = ChartBpActual__13;
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GLBudgetConsChartBpUpdateSp";
				
				appDB.AddCommandParameter(cmd, "pAcct", _pAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUnit1", _pUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUnit2", _pUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUnit3", _pUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUnit4", _pUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pChartBpFiscalYear", _pChartBpFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHierarchy", _pHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##1", _ChartBpBudget__1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##2", _ChartBpBudget__2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##3", _ChartBpBudget__3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##4", _ChartBpBudget__4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##5", _ChartBpBudget__5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##6", _ChartBpBudget__6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##7", _ChartBpBudget__7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##8", _ChartBpBudget__8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##9", _ChartBpBudget__9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##10", _ChartBpBudget__10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##11", _ChartBpBudget__11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##12", _ChartBpBudget__12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpBudget##13", _ChartBpBudget__13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##1", _ChartBpPlan__1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##2", _ChartBpPlan__2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##3", _ChartBpPlan__3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##4", _ChartBpPlan__4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##5", _ChartBpPlan__5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##6", _ChartBpPlan__6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##7", _ChartBpPlan__7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##8", _ChartBpPlan__8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##9", _ChartBpPlan__9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##10", _ChartBpPlan__10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##11", _ChartBpPlan__11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##12", _ChartBpPlan__12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpPlan##13", _ChartBpPlan__13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##1", _ChartBpActual__1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##2", _ChartBpActual__2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##3", _ChartBpActual__3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##4", _ChartBpActual__4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##5", _ChartBpActual__5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##6", _ChartBpActual__6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##7", _ChartBpActual__7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##8", _ChartBpActual__8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##9", _ChartBpActual__9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##10", _ChartBpActual__10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##11", _ChartBpActual__11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##12", _ChartBpActual__12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartBpActual##13", _ChartBpActual__13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
