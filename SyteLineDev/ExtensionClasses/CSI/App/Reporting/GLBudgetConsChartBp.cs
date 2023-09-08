//PROJECT NAME: Reporting
//CLASS NAME: GLBudgetConsChartBp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class GLBudgetConsChartBp : IGLBudgetConsChartBp
	{
		readonly IApplicationDB appDB;
		
		public GLBudgetConsChartBp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string rInfobar) GLBudgetConsChartBpSp(
			Guid? pChartBpRowPointer,
			int? pTgPeriodsMatch,
			string pCurrparmsCurrCode,
			string rInfobar)
		{
			RowPointerType _pChartBpRowPointer = pChartBpRowPointer;
			ByteType _pTgPeriodsMatch = pTgPeriodsMatch;
			CurrCodeType _pCurrparmsCurrCode = pCurrparmsCurrCode;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GLBudgetConsChartBpSp";
				
				appDB.AddCommandParameter(cmd, "pChartBpRowPointer", _pChartBpRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTgPeriodsMatch", _pTgPeriodsMatch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrparmsCurrCode", _pCurrparmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (Severity, rInfobar);
			}
		}
	}
}
