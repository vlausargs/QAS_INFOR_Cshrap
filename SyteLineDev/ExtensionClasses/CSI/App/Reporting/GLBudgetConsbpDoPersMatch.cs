//PROJECT NAME: Reporting
//CLASS NAME: GLBudgetConsbpDoPersMatch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class GLBudgetConsbpDoPersMatch : IGLBudgetConsbpDoPersMatch
	{
		readonly IApplicationDB appDB;
		
		public GLBudgetConsbpDoPersMatch(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GLBudgetConsbpDoPersMatchSp(
			string ReportsToSite,
			string pTgHierarchy,
			int? StartFiscalYear,
			DateTime? StartPeriodsPerStartDate,
			string Infobar)
		{
			SiteType _ReportsToSite = ReportsToSite;
			HierarchyType _pTgHierarchy = pTgHierarchy;
			FiscalYearType _StartFiscalYear = StartFiscalYear;
			DateType _StartPeriodsPerStartDate = StartPeriodsPerStartDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GLBudgetConsbpDoPersMatchSp";
				
				appDB.AddCommandParameter(cmd, "ReportsToSite", _ReportsToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTgHierarchy", _pTgHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartFiscalYear", _StartFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPeriodsPerStartDate", _StartPeriodsPerStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
