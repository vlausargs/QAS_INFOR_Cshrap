//PROJECT NAME: Reporting
//CLASS NAME: GLBudgetConsbpPerMap.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class GLBudgetConsbpPerMap : IGLBudgetConsbpPerMap
	{
		readonly IApplicationDB appDB;
		
		public GLBudgetConsbpPerMap(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string rInfobar) GLBudgetConsbpPerMapSp(
			string pParmsSite,
			string pTgHierarchy,
			string rInfobar)
		{
			SiteType _pParmsSite = pParmsSite;
			HierarchyType _pTgHierarchy = pTgHierarchy;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GLBudgetConsbpPerMapSp";
				
				appDB.AddCommandParameter(cmd, "pParmsSite", _pParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTgHierarchy", _pTgHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (Severity, rInfobar);
			}
		}
	}
}
