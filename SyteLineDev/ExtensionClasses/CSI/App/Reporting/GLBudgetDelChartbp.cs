//PROJECT NAME: Reporting
//CLASS NAME: GLBudgetDelChartbp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class GLBudgetDelChartbp : IGLBudgetDelChartbp
	{
		readonly IApplicationDB appDB;
		
		public GLBudgetDelChartbp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GLBudgetDelChartbpSp(
			string pHierarchy,
			string Infobar)
		{
			HierarchyType _pHierarchy = pHierarchy;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GLBudgetDelChartbpSp";
				
				appDB.AddCommandParameter(cmd, "pHierarchy", _pHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
